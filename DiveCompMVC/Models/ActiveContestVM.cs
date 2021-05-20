using DiveComp.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveCompMVC.Models
{
    public class ActiveContestVM
    {
            public ContestModel contest { get; set; }

            public List<JudgeModel> judges { get; set; }
            public List<DiverModel> divers { get; set; }

            public List<LeaderBoardModel> leaderboard { get; set; }

            public DiverModel diver { get; set; }

            public string score1 { get; set; }
            public string score2 { get; set; }
            public string score3 { get; set; }

            public List<FinaDifficultyModel> diffmods { get; set; }

            public FinaDifficultyModel currentDiffMod { get; set; }

            public string divepos { get; set; }

            

    }
}
