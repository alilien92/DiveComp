using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiveComp.Data.Models
{
    public class DiverModel
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage="Error!")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Club { get; set; }

        public string Country { get; set; }

    }
}
