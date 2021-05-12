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
        [Required(ErrorMessage = "Club that owns the contest is required!")]
        public string Club { get; set; }

    }
}
