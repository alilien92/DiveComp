using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiveComp.Data.Models
{
    public class DiverModel
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage="First Name is Required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Name of Club is Required!")]
        public string Club { get; set; }
        [Required(ErrorMessage = "Country of diver is Required!")]
        public string Country { get; set; }

    }
}
