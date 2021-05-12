using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiveComp.Data.Models
{
    public class EventTypeModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "A Name of Event is Required!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage="A Height is Required!")]
        public float Height { get; set; }

    }
}
