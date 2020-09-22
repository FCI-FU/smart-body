using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart__Body.Models
{
    public class Training
    {
        public string tName { get; set; }
        public int NumOfTrainee { get; set; }
        public string tDescription { get; set; }
        public int tDuration { get; set; }
        public int coachID { get; set; }
    }
}