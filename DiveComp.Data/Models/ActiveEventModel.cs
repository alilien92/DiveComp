using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveComp.Data.Models
{
    public class ActiveEventModel
    {
        public int Id { get; set; }

        public EventTypeModel Type { get; set; }

        public List<DiverModel> diverlist { get; set; }

        public List<LeaderBoardModel> leaderboard { get; set; }
    }
}
