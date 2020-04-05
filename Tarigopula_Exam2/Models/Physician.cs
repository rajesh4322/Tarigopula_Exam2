using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarigopula_Exam02.Models
{
    public class Physician
    {
        public int PhysicianID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Patient_Treatment> Patient_Treatment { get; set; }
    }
}