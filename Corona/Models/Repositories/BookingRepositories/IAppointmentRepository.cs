using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.BookingRepositories
{
    public interface IAppointmentRepository
    {
        void AddAppointment(RequestTest appointment);
    }
}
