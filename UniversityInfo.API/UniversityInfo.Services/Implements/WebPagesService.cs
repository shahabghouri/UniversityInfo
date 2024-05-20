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
    public class WebPagesService : IWebPagesService
    {
        private readonly UniversityInfoContext ctx;
        private readonly IMapper mapper;

        public WebPagesService(UniversityInfoContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<List<WebPagesDTO>> Get(long universityId)
        {
            var webPages = await ctx.WebPages.Where(x => x.UniversityId == universityId).ToListAsync();
            var webPagesDTO = mapper.Map<List<WebPagesDTO>>(webPages);
            return webPagesDTO;
        }
        public async Task<WebPagesDTO> Add(WebPagesDTO webPagesDTO)
        {
            var webPage = mapper.Map<WebPage>(webPagesDTO);
            await ctx.WebPages.AddAsync(webPage);
            await ctx.SaveChangesAsync();
            return mapper.Map<WebPagesDTO>(webPage);
        }
        public async Task<WebPagesDTO> Edit(WebPagesDTO webPagesDTO)
        {
            var webPage = mapper.Map<WebPage>(webPagesDTO);
            var webPageOld = ctx.WebPages.AsNoTracking().FirstOrDefault(x => x.Id == webPage.Id);
            if (webPageOld == null)
            {
                throw new Exception("No Record Found Against that request");
                //throw new UserTypeException(ExceptionMessages.DataNotFoundExceptionMessage);
            }
            ctx.WebPages.Update(webPage);
            ctx.Entry(webPage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await ctx.SaveChangesAsync();
            return mapper.Map<WebPagesDTO>(webPage);
        }
    }
}
