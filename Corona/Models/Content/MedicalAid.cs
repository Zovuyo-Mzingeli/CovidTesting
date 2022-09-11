using System.Collections.Generic;

namespace Corona.Models
{
    public class MedicalAid
    {
        public string MedicalAidId { get; set; }
        public string MedicalName { get; set; }

        public virtual MedicalPlan MedicalPlan { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }


    }
}