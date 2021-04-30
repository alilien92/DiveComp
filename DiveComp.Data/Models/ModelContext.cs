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

        public DbSet<ContestModel> contests { get; set; }
        public DbSet<DiverModel> divers { get; set; }
        public DbSet<ParticipantsModel> participants { get; set; }

        public DbSet<DiveVariationModel> diveVariations { get; set; }





    }
}
