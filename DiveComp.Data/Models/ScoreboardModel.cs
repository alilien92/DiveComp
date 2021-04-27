using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class ScoreboardModel
    {
        public int Id { get; set; }
        
        public List<DiveModel> divelist { get; set; }
    }
}
