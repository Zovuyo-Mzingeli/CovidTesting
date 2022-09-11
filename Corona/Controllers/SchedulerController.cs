using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Corona.Data;
using Corona.Extensions;
using Corona.Models;
using Corona.Models.Content;
using Corona.Models.Repositories.BookingRepositories;
using Corona.Models.ViewModels;
using Corona.Models.ViewModels.AssignSpecialistViewModel;
using Corona.Models.ViewModels.DoctorViewModel;
using Corona.Models.ViewModels.PatientViewModel;
using Corona.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Controllers
{
    public class SchedulerController : BaseController
    {
        private readonly CoronaContext context;
        private readonly IBookingRepository bookingRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;

        public SchedulerController(CoronaContext context, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            this.context = context;
            this.bookingRepository = bookingRepository;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }
       
       
       
        [HttpGet]
        public async Task<IActionResult> RequestAppointment()
        {
            GetPatientByName();
            PopulateSuburbDropDownList();
            var user = await userManager.GetUserAsync(User);
            if (user.Idnumber == null || user.Dob == null || user.PhoneNumber == null)
            {
                Notify("Please complete your personal information in order to make  an appoIntment", notificationType: NotificationType.warning);
                return RedirectToAction(nameof(AccountController.EditUser), "Account");
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> RequestAppointment(PatientAppointmentFormViewModel model)
        {
            GetPatientByName();
            PopulateSuburbDropDownList();
            if (ModelState.IsValid)
            
                try
                {
                    var currentUser = await userManager.GetUserAsync(HttpContext.User);

                    await bookingRepository
                    .AddAsync(
                      model.AddressLine1,
                        model.AddressLine2,
                        model.SuburbId,
                        model.DependentId,
                        currentUser.Id);
                    Notify("You just made a booking! Please keep track of your status!");
                    return RedirectToAction(nameof(SchedulerController.RequestAppointment), "Scheduler");
                }
                catch (Exception)
                {
                    Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
                }
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConfirmAppointment()
        {
            return View();
        }
        private void GetPatientByName(object selectedPatient = null)
        {
            var patientQuery = from d in context.tblDependent
                               orderby d.LastName
                              select d;
            ViewBag.PatientId = new SelectList(patientQuery.AsNoTracking(), "DependentId", "LastName",
            selectedPatient);
        }
        private void PopulateSuburbDropDownList(object selectedCity = null)
        {
            var SuburbQuery = from d in context.tblSuburb
                              orderby d.SuburbName
                              select d;
            ViewBag.SuburbId = new SelectList(SuburbQuery.AsNoTracking(), "SuburbId", "SuburbName",
            selectedCity);
        }
    }
}