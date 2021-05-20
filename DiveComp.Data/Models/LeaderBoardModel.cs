using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class LeaderBoardModel
    {
        public int Id { get; set;  }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Club { get; set; }
        public float Score { get; set; }

        public int hasJumped { get; set; }
    }
}
