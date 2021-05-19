using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DiveComp.Data.Models
{
    public class ContestModel
    {
        public int Id { get; set; }
       
        [Required (ErrorMessage = "Name of Contest is required!")]
        public string Name { get; set; }

        public int Nr_Jumps { get; set; }
        
        public int TypeId { get; set; }
        public virtual EventTypeModel Type { get; set; }

    }
}
