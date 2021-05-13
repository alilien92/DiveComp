using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiveComp.Data.Models
{
    public class EventTypeModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Is it Men or Women who will participate in the event?")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Is it Springboard or Platform?")]
        public string Type { get; set; }
        
        [Required(ErrorMessage="What Height will the Eventgroup jump from?")]
        public float Height { get; set; }

    }
}
