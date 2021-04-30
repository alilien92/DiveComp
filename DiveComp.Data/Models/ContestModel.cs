using System;
using System.Collections.Generic;
using System.Text;


namespace DiveComp.Data.Models
{
    public class ContestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int clubId { get; set; }

        //foreign keys
        public virtual ClubModel Club { get; set; }
    }
}
