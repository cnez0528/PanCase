using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pancase.Models
{
    public class PancaseContext : DbContext
    {
        public PancaseContext (DbContextOptions<PancaseContext> options)
            : base(options)
        {
        }

        public DbSet<Pancase.Models.Customer> Customer { get; set; }
        public DbSet<Pancase.Models.Case> Case { get; set; }
    }
}
