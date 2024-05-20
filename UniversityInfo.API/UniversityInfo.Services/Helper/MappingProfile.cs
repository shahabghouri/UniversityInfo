using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Common.DTO;
using UniversityInfo.Domain.Entities;

namespace UniversityInfo.Services.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UniversityDTO, University>().ReverseMap();
            CreateMap<UniversityDomainDTO, UniversityDomain>().ReverseMap();
            CreateMap<WebPagesDTO, WebPage>().ReverseMap();
        }
    }
}
