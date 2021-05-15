using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveComp.Data.Models;

namespace DiveCompMVC.Models
{
    public class ActiveContestModel
    {
        public ContestModel contest { get; set; }

        public List<JudgeModel> judge { get; set; }

        public List<ActiveEventModel> events { get; set; }
    }
}
