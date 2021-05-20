using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IDiverRepo
    {

        bool CreateDiver(DiverModel diver);

        DiverModel Get1Diver(int id);

        List<DiverModel> GetDiverListByContest(int id);
        List<DiverModel> GetAllDivers();

        List<DiverModel> GetDiverListByContest(int id);


    }
}
