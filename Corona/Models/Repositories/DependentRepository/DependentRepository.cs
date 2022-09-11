using AutoMapper.QueryableExtensions;
using Corona.Data;
using Corona.Models.Content;
using Corona.Models.ViewModel.DedepentViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.DependentRepository
{
    public class DependentRepository : IDependentRepository
    {

        public readonly CoronaContext context;

        public DependentRepository(CoronaContext context)
        {
            this.context = context;
        }

        public async Task AddDependentAsync(string PatientId, DateTime Dob, string Idnumber, string FirstName, string LastName,
            string Gender, string Email, string PhoneNumber, string AddressLine1, string AddressLine2, string CityId,
            string SuburbId, string PostalCode, string MedicalAidId, string MedicalAidNumber, string MedicalPlanId)
        {
            var Dependet = new Dependent
            {
                PatientId = PatientId,
                Dob = Dob,
                Idnumber = Idnumber,
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                Email = Email,
                PhoneNumber = PhoneNumber,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                CityId = CityId,
                SuburbId = SuburbId,
                PostalCode = PostalCode,
                MedicalAidId = MedicalAidId,
                MedicalAidNumber = MedicalAidNumber,
                MedicalPlanId = MedicalPlanId
            };
            await context.tblDependent.AddAsync(Dependet);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientViewModel>> AllAdependentAsync()
        {
            return await context
                .tblDependent
                .OrderByDescending(x => x.FirstName)
                .ProjectTo<PatientViewModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<PatientViewModel>> DependeAsync(string patientId)
        {
            return await context
                .tblDependent
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.FirstName)
                .ThenByDescending(a => a.LastName)
                .ProjectTo<PatientViewModel>()
                .ToListAsync();
        }

        public Dependent GetDependentById(string DependentId)
        {
            return context.tblDependent.FirstOrDefault(a => a.DependentId == DependentId);
        }
    }
}
