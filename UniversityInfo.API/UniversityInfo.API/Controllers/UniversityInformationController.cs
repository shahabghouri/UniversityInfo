using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityInfo.Common.DTO;
using UniversityInfo.Services.Aggregates;

namespace UniversityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityInformationController : ControllerBase
    {
        private readonly IUniversityInformationService universityInformationService;
        public UniversityInformationController(IUniversityInformationService universityInformationService)
        {
            this.universityInformationService = universityInformationService;
        }
        [HttpGet("{country}")]
        public async Task<IActionResult> Get(string country)
        {
            var universities = await universityInformationService.Get(country);
            return Ok(universities);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UniversityDTO universityDTO)
        {
            var universityAfterInsert = await universityInformationService.Add(universityDTO);
            return Ok(universityAfterInsert);
        }
        [HttpPost("Batch")]
        public async Task<IActionResult> AddBatch(List<BatchUniversityDTO> universityDTO)
        {
            await universityInformationService.AddBatch(universityDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id,UniversityDTO universityDTO)
        {
            var universityAfterEdit = await universityInformationService.Edit(id,universityDTO);
            return Ok(universityAfterEdit);
        }
        [HttpPut("EditByName")]
        public async Task<IActionResult> EditByName(UniversityDTO universityDTO)
        {
            var university = await universityInformationService.GetByName(universityDTO.Name);
            if (university == null)
            {
                throw new Exception("University Not Found");
            }
            var universityAfterEdit = await universityInformationService.Edit(university.Id,universityDTO);
            return Ok(universityAfterEdit);
        }
    }
}
