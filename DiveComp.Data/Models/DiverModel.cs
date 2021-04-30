using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiveComp.Data.Models
{
    public class DiverModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int clubId { get; set; }
        public string Country { get; set; }

        //foreign keys
        public virtual ClubModel Club { get; set; }
    }
}
