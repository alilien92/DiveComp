using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IEventTypeRepo
    {
        
        void AddNewEventType(EventTypeModel type);

        
        List<EventTypeModel> GetAllEventTypes();


        

    }
}
