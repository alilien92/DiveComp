using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IContestRepo
    {

        bool CreateNewContest(ClubModel Club);

        ContestModel Get1Contest(int id);


    }
}
