using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IJudgeRepository
    {

        List<JudgeModel> GetAllJudges();

        JudgeModel Get1Judge(int id);

        bool AddJudge(JudgeModel newDiver);

        bool RemoveJudge(int id);

        List<JudgeModel> UpdateJudge(int id, JudgeModel updatedJudge);
    }
}
