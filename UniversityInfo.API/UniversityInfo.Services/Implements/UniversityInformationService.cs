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

    public class UniversityInformationService : IUniversityInformationService
    {
        private readonly UniversityInfoContext ctx;
        private readonly IMapper mapper;

        public UniversityInformationService(UniversityInfoContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<List<UniversityDTO>> Get(string Country)
        {
            var universities = await ctx.Universities.Include(x => x.Domains).Include(x => x.WebPages).Where(x => x.Country == Country).ToListAsync();
            var universityDTO = mapper.Map<List<UniversityDTO>>(universities);
            return universityDTO;
        }
        public async Task<UniversityDTO> Add(UniversityDTO universityDTO)
        {
            var university = mapper.Map<University>(universityDTO);
            await ctx.Universities.AddAsync(university);
            await ctx.SaveChangesAsync();
            return mapper.Map<UniversityDTO>(university);
        }
        public async Task<UniversityDTO> Edit(long id,UniversityDTO universityDTO)
        {
            var university = mapper.Map<University>(universityDTO);
            var universityOld = ctx.Universities.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (universityOld == null)
            {
                throw new Exception("No Record Found Against that request");
            }
            universityOld.Name = string.IsNullOrEmpty(universityDTO.Name) ? universityOld.Name : universityDTO.Name;
            universityOld.AlphaTwoCode = string.IsNullOrEmpty(universityDTO.AlphaTwoCode) ? universityOld.AlphaTwoCode : universityDTO.AlphaTwoCode;
            universityOld.Country = string.IsNullOrEmpty(universityDTO.Country) ? universityOld.Country : universityDTO.Country;
            universityOld.StateProvince = string.IsNullOrEmpty(universityDTO.StateProvince) ? universityOld.StateProvince : universityDTO.StateProvince;
            if (universityDTO.Domains != null)
            {
                var domains = mapper.Map<List<UniversityDomain>>(universityDTO.Domains);
                ctx.UnivrsityDomains.UpdateRange(domains);
               // ctx.Entry(domains).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            if (universityDTO.Domains != null)
            {
                var webPages = mapper.Map<List<WebPage>>(universityDTO.WebPages);
                ctx.WebPages.UpdateRange(webPages);
                //ctx.Entry(webPages).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            ctx.Universities.Update(universityOld);
            ctx.Entry(universityOld).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await ctx.SaveChangesAsync();
            return mapper.Map<UniversityDTO>(universityOld);
        }

        public async Task AddBatch(List<BatchUniversityDTO> universityDTO)
        {
            foreach (var dto in universityDTO)
            {
                var universityOld = ctx.Universities.AsNoTracking().FirstOrDefault(x => x.Name == dto.Name);
                var university = new University()
                {
                    Name = dto.Name,
                    Country = dto.Country,
                    StateProvince = dto.StateProvince,
                    AlphaTwoCode = dto.AlphaTwoCode
                };
                if (universityOld != null)
                {
                    university.Id = universityOld.Id;
                    ctx.Universities.Update(university);
                    ctx.Entry(university).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    await ctx.Universities.AddAsync(university);
                    await ctx.SaveChangesAsync();
                    foreach (var domain in dto.Domains)
                    {
                        var websiteDomain = new UniversityDomain()
                        {
                            UniversityId = university.Id,
                            DomainName = domain
                        };
                        await ctx.UnivrsityDomains.AddAsync(websiteDomain);
                    }
                    foreach (var webpage in dto.WebPages)
                    {
                        var newWebPage = new WebPage()
                        {
                            UniversityId = university.Id,
                            WebPageUrl = webpage
                        };
                        await ctx.WebPages.AddAsync(newWebPage);
                    }

                }
            }
            await ctx.SaveChangesAsync();
        }

        public async Task<UniversityDTO> GetByName(string? name)
        {
            var university = await ctx.Universities.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
            return mapper.Map<UniversityDTO>(university);
        }
    }
}
