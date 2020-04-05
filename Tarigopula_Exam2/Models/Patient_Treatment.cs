using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarigopula_Exam02.Models
{
    public class Patient_Treatment
    {
        public int Patient_TreatmentID { get; set; }
        public int TreatmentID { get; set; }
        public int PhysicianID { get; set; }
        public DateTime Patient_Treatment_Date { get; set; }



        public virtual Treatment Treatment { get; set; }
        public virtual Physician Physician { get; set; }
    }
}