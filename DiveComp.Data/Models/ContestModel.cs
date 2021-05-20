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
        [Range(1, 8)]
        [Required(ErrorMessage = "Number of jumps is required!")]
        public int Nr_Jumps { get; set; }
        [Range(1, 10)]
        [Required(ErrorMessage = "Type of contest is required!")]
        public int TypeId { get; set; }
        public virtual EventTypeModel Type { get; set; }

    }
}
