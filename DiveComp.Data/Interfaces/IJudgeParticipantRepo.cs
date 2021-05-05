using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IJudgeParticipantRepo
    {
        bool CreateNewJudgeParticipant(ContestModel contest, JudgeModel judge);

        JudgeParticipantModel Get1JudgeParticipant(int id);

    }
}
