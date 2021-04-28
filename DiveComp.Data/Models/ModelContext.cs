using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        public DbSet<DiveModel> divers { get; set; }

        public DbSet<JudgeModel> judges { get; set; }
        
        public DbSet<DiveVariationModel> diveVariations { get; set; }

    }
}
