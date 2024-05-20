using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityInfo.Domain.Entities
{
    public class WebPage
    {
        public long Id { get; set; }
        public string WebPageUrl { get; set; }
        public long UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }
    }
}
