using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface ITowerRepo
    {
        List<TowerTypeModel> GetAllTowers();

        TowerTypeModel Get1Tower(int id);

        bool AddTower(TowerTypeModel newTower);

        bool RemoveTower(int id);

        List<TowerTypeModel> UpdateTower(int id, TowerTypeModel updatedTower);
    }
}
