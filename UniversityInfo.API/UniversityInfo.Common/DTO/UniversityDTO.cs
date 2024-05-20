using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInfo.Common.DTO
{
    public class UniversityDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AlphaTwoCode { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public List<UniversityDomainDTO> Domains { get; set; }
        public List<WebPagesDTO> WebPages { get; set; }
    }
}
