using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IFinaDifficultyRepo
    {
        List<FinaDifficultyModel> GetAllFinaDifficulty();

        FinaDifficultyModel Get1Difficulty(int id);

        bool AddFinaDifficulty(FinaDifficultyModel newDifficulty);

        bool RemoveFinaDifficulty(int id);

        List<FinaDifficultyModel> UpdateFinaDifficulty(int id, FinaDifficultyModel updatedDifficulty);
    }
}
