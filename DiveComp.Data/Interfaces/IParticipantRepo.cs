using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IParticipantRepo
    {
        bool CreateNewParticipant(EventsModel evt, DiverModel diver);

        void UpdateScore(int diverId, float newscore);

        List<LeaderBoardModel> GetAllParticipants(int eventId);

        bool DeleteParticipant(int id);

        List<LeaderBoardModel> GetContestResult(int contestid);

    }
}
