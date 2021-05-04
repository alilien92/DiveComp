using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiveComp.Data.Repository
{
    public class EventsDatabase : IEventsRepo
    {

        private ModelContext db;

        public EventsDatabase(ModelContext _db)
        {
            this.db = _db;
        }

        public bool AddNewEvent(EventsModel evt)
        {
            db.events.Add(evt);
            db.SaveChanges();
            if(db.events.Contains(evt))
            {
                return true;
            }
            return false;
        }

        public EventsModel GetEvent(int id)
        {
            EventsModel evt = db.events.FirstOrDefault(x => x.Id == id);
            if(evt != null)
            {
                return evt;
            }
            return null;
        }
    }
}
