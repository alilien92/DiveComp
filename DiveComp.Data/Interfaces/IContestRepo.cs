using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Interfaces
{
    public interface IContestRepo
    {

        bool CreateNewContest(ContestModel contest);

        ContestModel Get1Contest(int id);


    }
}
