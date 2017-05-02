using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessTracker.Models
{
    public class ExerciseSession
    {
        public int ExerciseSessionID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int ExerciseTypeID { get; set; }
        public virtual ExerciseType Exercise { get; set; }
    }
}