using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IDiveVariationRepository
    {
        List<DiveVariationModel> GetAllDiveVariation();

        DiveVariationModel Get1DiveVariation(int id);

        bool AddDiveVariation(DiveVariationModel newDiveVariation);

        bool RemoveDiveVariation(int id);

        List<DiveVariationModel> UpdateDiveVariation(int id, DiveVariationModel updatedDiveVariation);
    }
}
