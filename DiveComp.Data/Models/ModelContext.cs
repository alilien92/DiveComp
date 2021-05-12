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

        public DbSet<JudgeModel> judges { get; set; }

        public DbSet<JudgeParticipantModel> judgeParticipant { get; set; }

        public DbSet<FinaDifficultyModel> difficultyMods { get; set; }

        public DbSet<EventsModel> events { get; set; }
        
        public DbSet<EventTypeModel> eventTypes { get; set; }

    }
}
