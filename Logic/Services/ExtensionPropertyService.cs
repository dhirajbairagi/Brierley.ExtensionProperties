﻿using AutoMapper;
using Logic.Interfaces;
using Logic.ViewModels;
using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ExtensionPropertyService : IExtensionPropertyService
    {
        private readonly IExtensionPropertyRepo _extensionPropertyRepo;
        private readonly IMapper _mapper;

        public ExtensionPropertyService(IExtensionPropertyRepo extensionPropertyRepo, IMapper mapper)
        {
            _extensionPropertyRepo = extensionPropertyRepo;
            _mapper = mapper;
        }

        public async Task<IList<ExtensionPropertyDetails>> CreateExtensionProperties(IList<ExtensionPropertyDetails> extensionProperties)
        {
            IList<ExtensionProperty> properties = _mapper.Map<IList<ExtensionProperty>>(extensionProperties);
            properties = await _extensionPropertyRepo.CreateExtensionProperties(properties);
            return _mapper.Map<IList<ExtensionPropertyDetails>>(properties);
        }
    }
}
