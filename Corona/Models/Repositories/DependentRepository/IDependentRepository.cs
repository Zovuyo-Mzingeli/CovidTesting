using Corona.Models.Content;
using Corona.Models.ViewModel.DedepentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.DependentRepository
{
    public interface IDependentRepository
    { 
        Task AddDependentAsync(
            string PatientId, 
            DateTime Dob,
            string Idnumber,
            string FirstName,
            string LastName,
            string Gender,
            string Email,
            string PhoneNumber,
            string AddressLine1,
            string AddressLine2,
            string CityId,
            string SuburbId,
            string PostalCode,
            string MedicalAidId,
            string MedicalAidNumber,
            string MedicalPlanId);
        Dependent GetDependentById(string DependentId);
        Task<IEnumerable<PatientViewModel>> DependeAsync(string patientId);

        Task<IEnumerable<PatientViewModel>> AllAdependentAsync();


    }
}
