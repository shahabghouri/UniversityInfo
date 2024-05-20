using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Common.DTO;
using UniversityInfo.Domain.Entities;
using UniversityInfo.Infrastructure;
using UniversityInfo.Services.Aggregates;

namespace UniversityInfo.Services.Implements
{
    public class UniversityDomainService : IUniversityDomainService
    {
        private readonly UniversityInfoContext ctx;
        private readonly IMapper mapper;

        public UniversityDomainService(UniversityInfoContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<List<UniversityDomainDTO>> Get(long universityId)
        {
            var UnivrsityDomains = await ctx.UnivrsityDomains.Where(x => x.UniversityId == universityId).ToListAsync();
            var universityDomainsDTO = mapper.Map<List<UniversityDomainDTO>>(UnivrsityDomains);
            return universityDomainsDTO;
        }
        public async Task<UniversityDomainDTO> Add(UniversityDomainDTO universityDomainDTO)
        {
            var universityDomain = mapper.Map<UniversityDomain>(universityDomainDTO);
            await ctx.UnivrsityDomains.AddAsync(universityDomain);
            await ctx.SaveChangesAsync();
            return mapper.Map<UniversityDomainDTO>(universityDomain);
        }
        public async Task<UniversityDomainDTO> Edit(UniversityDomainDTO universityDomainDTO)
        {
            var universityDomain = mapper.Map<UniversityDomain>(universityDomainDTO);
            var universityOld = ctx.UnivrsityDomains.AsNoTracking().FirstOrDefault(x => x.Id == universityDomain.Id);
            if (universityOld == null)
            {
                throw new Exception("No Record Found Against that request");
                //throw new UserTypeException(ExceptionMessages.DataNotFoundExceptionMessage);
            }
            ctx.UnivrsityDomains.Update(universityDomain);
            ctx.Entry(universityDomain).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await ctx.SaveChangesAsync();
            return mapper.Map<UniversityDomainDTO>(universityDomain);
        }
    }
}
