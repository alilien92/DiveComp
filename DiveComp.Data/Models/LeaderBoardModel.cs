using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class LeaderBoardModel
    {
        public string ContestName { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Club { get; set; }
        public float Score { get; set; }
    }
}
