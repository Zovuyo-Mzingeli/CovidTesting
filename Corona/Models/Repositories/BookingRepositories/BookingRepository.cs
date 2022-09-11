using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Corona.Data;
using Corona.Models.Content;
using Corona.Models.ViewModels.AppointmentViewMole;

namespace Corona.Models.Repositories.BookingRepositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly CoronaContext context;

        public BookingRepository(CoronaContext context)
        {
            this.context = context;
        }
        
        public async Task AddAsync(string AddressLine1, string AddressLine2, string SuburbId, string DependentId, string PatientId)
        {
            var requestTest = new RequestTest
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                SuburbId = SuburbId,
                DependentId = DependentId,
                RequestorId = PatientId,
            };
            await context.tblRequestTest.AddAsync(requestTest);
            await context.SaveChangesAsync();
        }

        public RequestTest ApproveAndSchedule(RequestTest appointment)
        {
            var appointments = context.tblRequestTest.Attach(appointment);
            appointments.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return appointment; ;
        }

        public RequestTest GetRequestById(string RequestId)
        {
            return context.tblRequestTest.FirstOrDefault(a => a.RequestId == RequestId);
        }
    }
}
