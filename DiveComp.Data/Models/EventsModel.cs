using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class EventsModel
    {
        public int Id { get; set; }

        public int ContestId { get; set; }

        public string Name { get; set; }

        //foreign key
        public virtual ContestModel Contest { get; set; }

    }
}
