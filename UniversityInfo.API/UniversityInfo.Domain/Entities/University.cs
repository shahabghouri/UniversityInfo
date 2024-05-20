using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInfo.Domain.Entities
{
    public class University
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AlphaTwoCode { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        //public long UnivrsityDomainId { get; set; }
        //[ForeignKey("UnivrsityDomainId")]
        public virtual ICollection<UniversityDomain> Domains { get; set; }
        //public long WebPageId { get; set; }
        //[ForeignKey("WebPageId")]
        public virtual ICollection<WebPage> WebPages { get; set; }
    }
}
