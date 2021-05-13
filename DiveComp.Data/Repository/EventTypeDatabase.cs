using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiveComp.Data.Helpers;

namespace DiveComp.Data.Repository
{
    public class EventTypeDatabase : IEventTypeRepo
    {
        private ModelContext db;

        public EventTypeDatabase(ModelContext _db) {
            this.db = _db;
        }

        public void AddNewEventType(EventTypeModel evt) {
            
            db.eventTypes.Add(evt);
            db.SaveChanges();

        }

        public List<EventTypeModel> GetAllEventTypes() {
            List<EventTypeModel> ETList = new List<EventTypeModel>();
            ProcedureHelper ph = new ProcedureHelper(db);
            ETList = ph.spGetAllEventTypes();
            return ETList;
          
        }
      
    }
}

