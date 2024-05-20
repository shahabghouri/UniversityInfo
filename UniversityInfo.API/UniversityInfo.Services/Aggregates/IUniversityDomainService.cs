using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Common.DTO;

namespace UniversityInfo.Services.Aggregates
{
    public interface IUniversityDomainService
    {
        Task<List<UniversityDomainDTO>> Get(long UniversityId);
        Task<UniversityDomainDTO> Add(UniversityDomainDTO  universityDomainDTO);
        Task<UniversityDomainDTO> Edit(UniversityDomainDTO universityDomainDTO);
    }
}
