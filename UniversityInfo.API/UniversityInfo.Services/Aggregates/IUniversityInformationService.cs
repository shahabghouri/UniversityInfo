using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Common.DTO;
using UniversityInfo.Domain.Entities;

namespace UniversityInfo.Services.Aggregates
{
    public interface IUniversityInformationService
    {
        Task<List<UniversityDTO>> Get(string Country);
        Task<UniversityDTO> Add(UniversityDTO universityDTO);
        Task<UniversityDTO> Edit(long id,UniversityDTO universityDTO);
        Task AddBatch(List<BatchUniversityDTO> universityDTO);
        Task<UniversityDTO> GetByName(string? name);
    }
}
