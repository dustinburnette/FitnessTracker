using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessTracker.Models
{
    public class ExerciseType
    {
        public int ExerciseTypeID { get; set; }
        [Display(Name = "Exercise Type")]
        public string Description { get; set; }
    }
}
