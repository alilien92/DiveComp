using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;
using System.Globalization;


namespace DiveCompMVC.Helpers
{
    public class RepoHelper
    {
        public IContestRepo contests;
        public IFinaDifficultyRepo fina;

        public RepoHelper(IFinaDifficultyRepo _fina, IContestRepo _contests)
        {
            this.fina = _fina;
            this.contests = _contests;
        }

        public ActiveContestVM RetrieveActiveContest(int id)
        {
            var cModel = contests.GetActiveContest(id);
            ActiveContestVM contest = new ActiveContestVM();
            contest.contest = cModel.contest;
            contest.divers = cModel.divers;
            contest.judges = cModel.judges;
            contest.leaderboard = cModel.leaderboard;
            contest.diffmods = fina.GetHeightDifficulty(contest.contest.Type.Height);
            return contest;
        }

        public float CalculateMedian(string s1, string s2, string s3)
        {
            float score1 = float.Parse(s1, CultureInfo.InvariantCulture.NumberFormat);
            float score2 = float.Parse(s2, CultureInfo.InvariantCulture.NumberFormat);
            float score3 = float.Parse(s3, CultureInfo.InvariantCulture.NumberFormat);

            float[] total = { score1, score2, score3 };

            float median = total.Average();



            return median;
        }

        
        
    }
}
