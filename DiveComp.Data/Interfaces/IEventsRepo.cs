using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IEventsRepo
    {
        bool AddNewEvent(EventsModel evt);

        EventsModel GetEvent(int id);

    }
}
