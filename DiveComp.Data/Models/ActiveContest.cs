using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveComp.Data.Models
{
    public class ActiveContest
    {
        public ContestModel contest { get; set; }
        
        public List<JudgeModel> judges { get; set; }
        public List<DiverModel> divers { get; set; }

        public List<LeaderBoardModel> leaderboard { get; set; }
    }
}
