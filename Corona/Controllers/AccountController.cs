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
using Corona.Models.Repositories.ProfileImage;
using Corona.Models.ViewModels;
using Corona.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserValidator<ApplicationUser> userValidator;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IPasswordValidator<ApplicationUser> passwordValidator;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly CoronaContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserValidator<ApplicationUser> userValidator, RoleManager<ApplicationRole> roleManager,
            IPasswordValidator<ApplicationUser> passwordValidator, IPasswordHasher<ApplicationUser> passwordHasher,
            IEmailSender emailSender,ILogger<AccountController> logger, IUnitOfWork unitOfWork, CoronaContext context, IWebHostEnvironment hostEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userValidator = userValidator;
            this.roleManager = roleManager;
            this.passwordValidator = passwordValidator;
            this.passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.context = context;
            webHostEnvironment = hostEnvironment;
        }
       //[Authorize(Roles = "Patient")]
        public IActionResult Index()
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
                    UserName = userModel.FirstName
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
                    
                    ///var callbackUrl = Url.EmailConfirmationLink(user.Id, ctoken, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(user.Email, ctokenlink);

                    var isSave = await userManager.AddToRoleAsync(user, role: "Patient");

                    //var addClaimResilt = await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));

                    await signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");

                    Notify("Hi " + user.UserName + " your account was created successfully! Please check your emails to confirm your account");

                    return RedirectToAction(nameof(AccountController.Login), "Account");
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
                            _logger.LogInformation("User logged in.");
                            //return RedirectToAction(nameof(AdministrationController.Index), "Administration");
                            return RedirectToLocal();
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
            PopulateMedicalSchemeDropDownList();
            PopulateSuburbDropDownList();
            PopulateMedicalPlanDropDownList();
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            var model = new EditUserViewModel
            {
                Dob = user.Dob,
                Email = user.Email,
                Idnumber = user.Idnumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                SuburbId = user.SuburbId,
                MedicalAidId = user.MedicalAidId,
                PlanId = user.PlanId,
                MedicalAidNumber = user.MedicalAidNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {

            //string uniqueFileName = UploadedFile(model);
            PopulateSuburbDropDownList();
            if (!ModelState.IsValid)
            {
                //Notify("All field are required", notificationType: NotificationType.warning);
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
            user.Email = model.Email;
            user.Idnumber = model.Idnumber;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.AddressLine1 = model.AddressLine1;
            user.AddressLine2 = model.AddressLine2;
            user.SuburbId = model.SuburbId;
            user.MedicalAidId = model.MedicalAidId;
            user.MedicalAidNumber = model.MedicalAidNumber;
            user.PlanId = model.PlanId;

            PopulateSuburbDropDownList(model.SuburbId);
            PopulateMedicalSchemeDropDownList(model.MedicalAidId);
            PopulateMedicalPlanDropDownList(model.PlanId);

            await userManager.UpdateAsync(user);

            await signInManager.RefreshSignInAsync(user);
            Notify("Your profile was updated successfully");
            return RedirectToAction(nameof(MainMembersController.Index), "MainMembers");
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
       
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private IActionResult RedirectToLocal()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(AdministrationController.Index), "Administration");
            }
            else if (User.IsInRole("Patient"))
            {
                return RedirectToAction(nameof(MainMembersController.Index), "MainMembers");
            }
            else if (User.IsInRole("Nurse"))
            {
                return RedirectToAction(nameof(NurseController.Index), "Nurse");
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
        
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        private void PopulateSuburbDropDownList(object selectedCity = null)
        {
            var SuburbQuery = from d in context.tblSuburb
                            orderby d.SuburbName
                            select d;
            ViewBag.SuburbId = new SelectList(SuburbQuery.AsNoTracking(), "SuburbId", "SuburbName",
            selectedCity);
        }
        private void PopulateMedicalSchemeDropDownList(object selectedCity = null)
        {
            var MedicalAidQuery = from d in context.tblMedicalAid
                              orderby d.MedicalName
                              select d;
            ViewBag.MedicalAidId = new SelectList(MedicalAidQuery.AsNoTracking(), "MedicalAidId", "MedicalName",
            selectedCity);
        }
        private void PopulateMedicalPlanDropDownList(object selectedCity = null)
        {
            var PlanQuery = from d in context.tblMedicalPlans
                              orderby d.PlanName
                              select d;
            ViewBag.MedicalPlanId = new SelectList(PlanQuery.AsNoTracking(), "MedicalPlanId", "PlanName",
            selectedCity);
        }
        [HttpGet]
        public IActionResult Helper()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FAQs()
        {
            return View();
        }
    }
}