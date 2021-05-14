using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiveComp.Data.Helpers;

namespace DiveComp.Data.Repository
{
    public class EventsDatabase : IEventsRepo
    {

        private ModelContext db;

        public EventsDatabase(ModelContext _db)
        {
            this.db = _db;
        }

        public void AddNewEvent(EventsModel evt)
        {
            EventsModel newevent = new EventsModel();
            newevent.Contest = evt.Contest;
            newevent.Type = evt.Type;
            db.events.Add(newevent);
            db.SaveChanges();
            
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

        public List<EventsModel> GetAllEvents(int contestid)
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            return entry.spGetEvents(contestid);
        }
        public int GetEventId(string name, int id) {
            ProcedureHelper ph = new ProcedureHelper(db);
            return ph.spGetEventId(name, id);
        }

        public List<ActiveEventModel> GetEventsForContest(int contestid)
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            return entry.spGetEventsForContest(contestid);
        }
    }
}
