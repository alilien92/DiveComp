﻿using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IEventsRepo
    {
        void AddNewEvent(EventsModel evt);

        EventsModel GetEvent(int id);
        
        int GetEventId(string name, int id);

        List<EventsModel> GetAllEvents(int contestid);

        List<ActiveEventModel> GetEventsForContest(int contestid);

    }
}
