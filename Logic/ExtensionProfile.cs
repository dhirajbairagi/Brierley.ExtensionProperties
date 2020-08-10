using AutoMapper;
using Logic.ViewModels;
using Repository.Models;

namespace Logic
{
    public class ExtensionProfile : Profile
    {
        public ExtensionProfile()
        {
            CreateMap<ExtensionProperty, ExtensionPropertyDetails>().ReverseMap();
            CreateMap<ExtensionDomain, ExtensionDomainDetails>().ReverseMap();
        }
    }
}
