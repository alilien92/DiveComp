using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class DiverContext : DbContext
    {
        public DiverContext(DbContextOptions<DiverContext> options)
            : base(options)
        {

        }

        public DbSet<DiveModel> divers { get; set; }
    }
}
