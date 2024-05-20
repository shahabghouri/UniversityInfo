using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Common.DTO;

namespace UniversityInfo.Services.Aggregates
{
    public interface IWebPagesService
    {
        Task<List<WebPagesDTO>> Get(long UniversityId);
        Task<WebPagesDTO> Add(WebPagesDTO  webPagesDTO);
        Task<WebPagesDTO> Edit(WebPagesDTO webPagesDTO);
    }
}
