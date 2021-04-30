﻿using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IDiverRepo
    {

        bool CreateDiver(ClubModel Club);

        DiverModel Get1Diver(int id);


    }
}
