using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Domain.Entities;

namespace UniversityInfo.Infrastructure
{
    public class UniversityInfoContext:DbContext
    {
        public UniversityInfoContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityDomain> UnivrsityDomains { get; set; }
        public DbSet<WebPage> WebPages { get; set; }
    }
}
