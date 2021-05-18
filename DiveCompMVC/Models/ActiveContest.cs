using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveCompMVC.Models
{
    public class ActiveContest
    {
        public int ID { get; set; }
        
        public List<DiverModel> divers { get; set; }
    }
}
