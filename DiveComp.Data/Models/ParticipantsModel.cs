﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class ParticipantsModel
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int DiverId { get; set; }

        public float Score { get; set; }

        //foreign keys
        public virtual EventsModel Event { get; set; } 

        public virtual DiverModel Diver { get; set; }
    }
}
