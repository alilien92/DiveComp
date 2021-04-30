using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IParticipantsRepo
    {
        bool CreateNewParticipant(ContestModel contest, DiverModel diver);

        ParticipantsModel Get1Participant(int id);
    }
}
