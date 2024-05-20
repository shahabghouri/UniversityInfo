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
        [HttpPut]
        public async Task<IActionResult> Edit(UniversityDTO universityDTO)
        {
            var universityAfterEdit = await universityInformationService.Edit(universityDTO);
            return Ok(universityAfterEdit);
        }
    }
}
