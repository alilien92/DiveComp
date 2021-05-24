using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IFinaDifficultyRepo
    {
        
        List<FinaDifficultyModel> GetHeightDifficulty(float height);

        bool AddFinaDifficulty(FinaDifficultyModel newDifficulty);

        float DetermineDiveType(string type, float height, int dcn);

        void InsertFinaTable();

    }
}
