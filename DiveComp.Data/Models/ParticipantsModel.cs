using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class ParticipantsModel
    {
        public int Id { get; set; }

        public int contestId { get; set; }

        public int diverId { get; set; }

        public float Score { get; set; }

        //foreign keys
        public virtual ContestModel Contest { get; set; } 

        public virtual DiverModel Diver { get; set; }
    }
}
