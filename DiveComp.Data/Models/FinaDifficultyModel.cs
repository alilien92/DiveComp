using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class FinaDifficultyModel
    {
        public int Id { get; set; }
        
        public int DiveCodeNumber { get; set; }
        
        public float Height { get; set; }

        public string DiveVariation { get; set; }
       
        public float STR { get; set; }
        
        public float Pike { get; set; }
        
        public float Tuck { get; set; }
        
        public float Free { get; set; }

        
    }
    
}
