using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Corona.Data;
using Corona.Models;
using Corona.Models.Content;
using Corona.Models.Repositories.BookingRepositories;
using Corona.Models.ViewModels;
using Corona.Models.ViewModels.DoctorViewModel;
using Corona.Services;

namespace Corona.Controllers
{
    //[Authorize(Roles = "Nurse")]
    public class NurseController : BaseController
    {
        private readonly CoronaContext context;
        private readonly IBookingRepository bookingRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        public SignInManager<ApplicationUser> SignInManager { get; }

        public NurseController(CoronaContext context, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            this.context = context;
            this.bookingRepository = bookingRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var appts = await context.tblRequestTest.CountAsync();
            ViewBag.apptCount = appts;

            var unconfirmedAppts = await context
                      .tblRequestTest
                      .Where(a => a.Status == "New")
                      .OrderByDescending(a => a.RequestedDate)
                      .CountAsync();
            ViewBag.CountPendingAppts = unconfirmedAppts;

            var Appts = await context
                    .tblRequestTest
                    .Where(a => a.Status == "Scheduled")
                    .Where(a => a.NurseId == currentUser.Id && (a.RequestedDate == DateTime.Now.Date))
                    .OrderByDescending(a => a.RequestedDate)
                    .CountAsync();
            ViewBag.CountStaffAppts = Appts;

            var Appt = await context
                   .tblRequestTest
                   .Where(a => a.Status == "Scheduled")
                   .Where(a => a.NurseId == currentUser.Id && (a.RequestedDate == DateTime.Now.Date))
                   .OrderByDescending(a => a.RequestedDate)
                   .CountAsync();
            ViewBag.CountApptsTomoro = Appt;

            

            return View(context
                      .tblRequestTest
                      .Where(a => a.Status == "New")
                      .OrderByDescending(a => a.RequestedDate)
                      .Include(p => p.Requestor)
                      .Include(s => s.Suburb)
                      .AsNoTracking());
        }
        [HttpGet]
        public IActionResult AcceptRequest(string id, DoctorScheduleViewModel model)
        {
            //var request = context.tblRequestTest.Find(id);
            RequestTest request = bookingRepository.GetRequestById(id);
            if (request != null)
            {
                model.RequestId = request.RequestId;
                model.AddressLine1 = request.AddressLine1;
                model.AddressLine2 = request.AddressLine2;
                model.SuburbId = request?.Suburb?.SuburbName ?? "< No Suburb>";
                model.RequestorId = request?.Requestor?.FullName ?? "<Requestor Address>";
                model.Status = request.Status;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AcceptRequest(DoctorScheduleViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    RequestTest request = bookingRepository.GetRequestById(id);
                    var userId = userManager.GetUserId(HttpContext.User);

                    if (request != null)
                    {
                        request.Status = "Scheduled";
                        request.NurseId = userId;

                        var requestTest = new TestBooking
                        {
                            NurseId = userId,
                            RequestId = model.RequestId,
                            BookingDate = model.BookingDate,
                            TimeSlot = model.TimeSlot,
                            Status = "Scheduled",
                        };
                        bookingRepository.ApproveAndSchedule(request);
                        await context.tblTestBooking.AddAsync(requestTest);
                        await context.SaveChangesAsync();
                    }
                    ApplicationUser userr = await userManager.FindByIdAsync(request.RequestorId);
                    model = new DoctorScheduleViewModel
                    {
                        Email = userr.Email
                    };
                    var ctokenlink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = request.Requestor
                    }, protocol: HttpContext.Request.Scheme);

                    await emailSender.SendEmailConfirmationAppointmentAsync(userr.Email, ctokenlink);
                    Notify("Your scheduled was successfully accepted", notificationType: NotificationType.success);

                    return RedirectToAction(nameof(LogSchedular));
                }
                catch (Exception)
                {
                    Notify("Something went wrong! Please check the field(s) required", notificationType: NotificationType.error);
                }
            }
            return View();
        }
        public async Task<IActionResult> LogSchedular()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            return View(context.tblTestBooking
                .Where(a => a.Status == "Scheduled")
                    .Where(a => a.NurseId == currentUser.Id)
                    .OrderByDescending(a => a.BookingDate)
                    .Include(p => p.RequestTest)
                    .AsNoTracking());
        }

        public IActionResult FavSuburb()
        {
            var suburbs = context.tblSuburb.ToList();
            return View(suburbs);
        }

        [HttpGet]
        public IActionResult UserDetails()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction(nameof(AccountController.Index), "Account");
            }
            else
            {
                ApplicationUser user = userManager.FindByIdAsync(userId).Result;
                return View(user);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditUser()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            PopulateCityDropDownList();
            PopulateProvinceDropDownList();
            var model = new EditUserViewModel
            {
                Dob = user.Dob,
                Email = user.Email,
                Idnumber = user.Idnumber,
                LastName = user.LastName,
                FirstName = user.FirstName,
                PhoneNumber = user.PhoneNumber,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Notify("All field are required", notificationType: NotificationType.warning);
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var email = user.Email;
            if (model.Email != email)
            {
                var setEmailResult = await userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var phoneNumber = user.PhoneNumber;
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            user.Dob = model.Dob;
            user.Idnumber = model.Idnumber;
            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.AddressLine1 = model.AddressLine1;
            user.AddressLine2 = model.AddressLine2;
            PopulateCityDropDownList(model.CityId);
            //PopulateProvinceDropDownList(model.ProvinceId);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(UserDetails));
        }
        public IActionResult DoctorsReport()
        {
            return View();
        }
       
       
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private void PopulateProvinceDropDownList(object selectedProvince = null)
        {
            var provinceQuery = from d in context.tblProvince
                                orderby d.ProvinceName
                                select d;
            ViewBag.ProvinceId = new SelectList(provinceQuery.AsNoTracking(), "ProvinceId", "ProvinceName",
            selectedProvince);
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from k in context.tblCity
                            orderby k.CityName
                            select k;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
    }
}
