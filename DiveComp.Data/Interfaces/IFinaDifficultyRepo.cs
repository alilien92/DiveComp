﻿using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IFinaDifficultyRepo
    {

        FinaDifficultyModel Get1Difficulty(int id);

        bool AddFinaDifficulty(FinaDifficultyModel newDifficulty);

        bool InsertFinaTable();
    }
}
