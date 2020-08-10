using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;

namespace Repository
{
    public class JwtTenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _context;

        public JwtTenantProvider(IHttpContextAccessor context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            IConfiguration _configuration = configuration;
        }

        public string GetConnectionString()
        {
            Claim tenantClaim = _context.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("tenant"));
            if (tenantClaim == null && _context.HttpContext.Items.ContainsKey("tenant"))
            {
                tenantClaim = new Claim("tenant", _context.HttpContext.Items["tenant"].ToString());
            }
            if (null == tenantClaim)
            {
                throw new ValidationException("Invalid tenant in token");
            }

            // DEV NOTE: we need to iron out supporting lists in kubernetes env. vars. so we can get away from hardcoding keys in here (same in Startup)
            switch (tenantClaim.Value.ToUpper())
            {
                case "BRIERLEY":
                    return Environment.GetEnvironmentVariable("Tenants__BRIERLEY");
                case "GAP":
                    return Environment.GetEnvironmentVariable("Tenants__GAP");
                case "HERTZ":
                    return Environment.GetEnvironmentVariable("Tenants__HERTZ");
            }
            throw new ValidationException("Invalid tenant configuration");
        }
    }
}
