using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IClubRepo
    {
        List<ClubModel> GetAllClubs();

        ClubModel Get1Club(int id);

        bool AddClub(ClubModel newClub);

        bool RemoveClub(int id);

        List<ClubModel> UpdateClub(int id, ClubModel updatedClub);
    }
}
