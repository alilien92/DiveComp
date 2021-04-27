using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IDiverRepository
    {
        List<DiveModel> GetAllDivers();

        DiveModel Get1Diver(int id);

        bool AddDiver(DiveModel newDiver);

        bool RemoveDiver(int id);

        List<DiveModel> UpdateDiver(int id, DiveModel updatedDiver);
    }
}
