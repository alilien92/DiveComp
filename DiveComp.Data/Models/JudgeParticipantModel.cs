using System;
using System.Collections.Generic;
using System.Text;

namespace DiveComp.Data.Models
{
    public class JudgeParticipantModel
    {
        public int Id { get; set; }

        public int contestId { get; set; }

        public int judgeId { get; set; }

        //Foreign keys
        public virtual ContestModel Contest { get; set; }

        public virtual JudgeModel Judge { get; set; }
    }
}
