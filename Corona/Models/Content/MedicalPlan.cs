using System.Collections.Generic;

namespace Corona.Models
{
    public class MedicalPlan
    {
        public string MedicalPlanId { get; set; }
        public string PlanName { get; set; }
        public string MedicalAidId { get; set; }
        public virtual ICollection<MedicalAid> GetMedicalAids { get; set; }

    }
}