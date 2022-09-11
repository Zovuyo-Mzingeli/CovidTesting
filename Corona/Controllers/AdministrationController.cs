using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Corona.Data;
using Corona.Extensions;
using Corona.Models;
using Corona.Models.Repositories.BookingRepositories;
using Corona.Models.Repositories.ProfileImage;
using Corona.Models.ViewModels;
using Corona.Models.ViewModels.DoctorViewModel;
using Corona.Models.ViewModels.PatientViewModel;
using Corona.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Controllers
{
    //[Authorize(Roles = "Receptionist, Admin")]
    public class AdministrationController : BaseController
    {
        private readonly CoronaContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IBookingRepository bookingRepository;
        private readonly ILogger _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdministrationController(CoronaContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager,
            IPasswordValidator<ApplicationUser> passwordValidator, IPasswordHasher<ApplicationUser> passwordHasher,
           IBookingRepository bookingRepository, IEmailSender emailSender, ILogger<AccountController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.bookingRepository = bookingRepository;
            _emailSender = emailSender;
            _logger = logger;
            this.unitOfWork = unitOfWork;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var appts  = await context.tblRequestTest.CountAsync();
            ViewBag.apptCount = appts;

            //var unconfirmedAppts = await context
            //         .tblRequestTest
            //         .Where(a => a.isConfirmed == false)
            //         .OrderByDescending(a => a.Date)
            //         .ThenByDescending(a => a.startTime)
            //         .CountAsync();
            //ViewBag.CountPendingAppts = unconfirmedAppts;

            var patient = await userManager.GetUsersInRoleAsync("Patient");
            var patientsListItems = patient.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.PatCounter = patientsListItems;

            var nurse = await userManager.GetUsersInRoleAsync("Nurse");
            var nurseListItems = nurse.Select(nrs => new SelectListItem
            {
                Value = nrs.Id
            })
            .ToList().Count();

            ViewBag.NurseCounter = nurseListItems;

            List<RoleViewModel> listofUsers = new List<RoleViewModel>();

            var users = userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
            var roles = roleManager.Roles.ToList();

            foreach (var user in users)
            {
                RoleViewModel u = new RoleViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address1 = user.AddressLine1,
                    Address2 = user.AddressLine2,
                };
                foreach (var r in user.UserRoles)
                {
                    u.Roles.Add(r.UserId, roles.Where(x => x.Id == r.RoleId).First().Name);
                }
                listofUsers.Add(u);
            }
            return View(listofUsers);
        }
        [HttpGet]
        public IActionResult ManageUser()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Register(UserRegistrationModel userModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    UserName = userModel.FirstName,
                };
                var result = await userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var ctoken = userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                    var ctokenlink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = ctoken
                    }, protocol: HttpContext.Request.Scheme);

                    await _emailSender.SendEmailConfirmationAsync(user.Email, ctokenlink);
                    ViewBag.token = ctokenlink;

                    await signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");

                    Notify("Hi " + user.UserName + " your account was created successfully! Please check your emails to confirm your account");

                    return RedirectToAction(nameof(UsersController.Index), "Users");
                }
                AddErrorsFromResult(result);
            }
            return View(userModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel details, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await userManager.FindByEmailAsync(details.Email);
                    if (user != null)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, details.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            //_logger.LogInformation("User logged in.");
                            return RedirectToLocal(returnUrl);
                        }
                    }
                }
                catch (Exception)
                {
                    Notify("You don't have access, please use you credetials to login", notificationType: NotificationType.warning);
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                Notify("Invalid credetials! Your email or password is incorrect", notificationType: NotificationType.error);
            }
            return View(details);
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
            //string uniqueFileName = UploadedFile(model);
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
            //PopulateDepartmentDropDownList(model.DepartmentId);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id ={id} cannot be found";
                return View();
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction();
                }
            }
            return View();
        }
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(AdministrationController.ManageUser), "Administration");

                }
                else if (User.IsInRole("Patient"))
                {
                    return RedirectToAction(nameof(AccountController.Index), "Account");
                }
                else if (User.IsInRole("Nurse") || User.IsInRole("Doctor"))
                {
                    //return RedirectToAction(nameof(NurseController.), "Doctor");
                }
                
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }
        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            //EmailConfirmModel model = new EmailConfirmModel();

            if (userId == null || token == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            //if (result.Succeeded)
            //{
            //    model.EmailVerified = true;
            //}
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        public ViewResult ChangePassword(string userName)
        {
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel() { Email = userName };

            return View(resetPasswordViewModel);
        }
        private void PopulateCityDropDownList(object selectedCity = null)
        {
            var CityQuery = from d in context.tblCity
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName",
            selectedCity);
        }
    }
}