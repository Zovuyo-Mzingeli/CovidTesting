using Corona.Models.Content;
using Corona.Models.ViewModels.AppointmentViewMole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.BookingRepositories
{
    public interface IBookingRepository
    {
        Task AddAsync(string AddressLine1,
            string AddressLine2,
            string SuburbId,
            string DependentId,
            string RequestorId);

        RequestTest ApproveAndSchedule(RequestTest appointment);
        RequestTest GetRequestById(string RequestId);
    }
}
