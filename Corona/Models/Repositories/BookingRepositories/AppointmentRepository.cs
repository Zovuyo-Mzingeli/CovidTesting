using Corona.Data;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.BookingRepositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly CoronaContext context;

        public AppointmentRepository(CoronaContext context)
        {
            this.context = context;
        }
        public void AddAppointment(RequestTest appointment)
        {
            context.tblRequestTest.Add(appointment);
            context.SaveChanges();
        }

    }
}
