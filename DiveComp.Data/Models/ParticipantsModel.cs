using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class ParticipantsModel
    {
        public int Id { get; set; }

        public int ContestId { get; set; }

        public int DiverId { get; set; }

        public float Score { get; set; }

        public int HasJumped { get; set; }

        //foreign keys
        public virtual ContestModel Contest { get; set; } 

        public virtual DiverModel Diver { get; set; }
    }
}
