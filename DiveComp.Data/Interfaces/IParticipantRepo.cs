using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IParticipantRepo
    {
        bool CreateNewParticipant(ContestModel contest, DiverModel diver);

        bool UpdateScore(int diverId, float newscore);

        List<DiverBoardModel> GetAllParticipants(int contestid);
    }
}
