using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IJudgeRepo
    {
        List<JudgeModel> GetAllJudges();

        JudgeModel Get1Judge(int id);

        bool AddJudge(JudgeModel newJudge);

        List<JudgeModel> GetJudgesByContest(int contestid);

        bool RemoveJudge(int id);

        public List<JudgeModel> GetJudgesNotInContest(int contestId);

    }
}
