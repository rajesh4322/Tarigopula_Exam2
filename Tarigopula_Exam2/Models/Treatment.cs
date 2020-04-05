using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tarigopula_Exam02.Models
{
    public class Treatment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TreatmentID { get; set; }
        public string Title { get; set; }
        public string Treament_Description { get; set; }

        public virtual ICollection<Patient_Treatment> Patient_Treatment { get; set; }
    }
}