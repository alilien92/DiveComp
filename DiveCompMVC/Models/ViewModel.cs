using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveComp.Data.Models;

namespace DiveCompMVC.Models
{
    public class ViewModel {
        
        // ALL MODELS FOR VIEW
        public ContestModel Contests { get; set; }
        public DiverModel Divers { get; set; }
        public EventsModel Events { get; set; }
        
        public JudgeModel Judges {get; set;}
        
        public JudgeParticipantModel JudgeParticipants { get; set; }

        public LeaderBoardModel LeaderBoards { get; set; }

        public ParticipantsModel Participants { get; set; }

        //Lists for views
        public List<ContestModel> AllContests { get; set; }
        
        public List<DiverModel> AllDivers { get; set; }
        
        public List<EventsModel> AllEvents { get; set; }
       
        public List<JudgeModel> AllJudges { get; set; }
        
        public List<JudgeParticipantModel> AllJudgesParticipants { get; set; }
       
        public List<LeaderBoardModel> AllLeaderBoards { get; set; }
        
        public List<ParticipantsModel> AllParticipants { get; set; }

    }
}
