//using Brierley.ExtensionPropertyManager.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic;
//using Newtonsoft.Json.Linq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//namespace Brierley.ExtensionPropertyManager.ExtensionManagers
//{
//    public class ExtensionPropertyTransformer<TContext> : IExtensionPropertyTransformer<TContext> where TContext : ExtensionPropertyDbContext<TContext>
//    {
//        private readonly TContext context;

//        public ExtensionPropertyTransformer(TContext context)
//        {
//            this.context = context;
//        }

//        public async Task<string> TransformExtensionProperties(string extensionProperties, string targetTable, int ownerId)
//        {
//            var domain = await context.ExtensionDomains.FirstOrDefaultAsync(x => x.TargetTableName == targetTable && x.OwnerId == ownerId);
//            if (domain == null)
//            {
//                throw new KeyNotFoundException("Domain does not exist");
//            }
//            var extensionProps = await context.ExtensionProperties.Where(x => x.ExtensionDomainId == domain.ExtensionDomainId).ToListAsync();

//            if (extensionProperties.Any() && !string.IsNullOrEmpty(extensionProperties))
//            {
//                JObject jObject = new JObject(extensionProperties);
//                IList<JProperty> jProperties = jObject.Properties().ToList();
//                foreach (var jProperty in jProperties)
//                {
//                    var propMetadata = extensionProps.FirstOrDefault(x => x.ColumnName == jProperty.Name);
//                    if (propMetadata != null)
//                    {
//                        switch (propMetadata.DataType)
//                        {
//                            case "number":
//                                {
//                                    if(int.TryParse(jProperty.Value.ToString(),out int result))
//                                    {
//                                        jObject[jProperty.Name] = result > -1 ? result.ToString() : (-1).ToString();
//                                    }
//                                    break;
//                                }
//                            case "boolean":
//                                {
//                                    if (bool.TryParse(jProperty.Value.ToString(),out bool result))
//                                    {
//                                        jObject[jProperty.Name] =  result;
//                                    }
//                                    break;
//                                }
//                            case "string":
//                        }
//                    }
//                }
//            }

//        }
//    }
//}
