using Corona.Data;
using Corona.Models;
using Corona.Models.Repositories.DependentRepository;
using Corona.Models.ViewModel.DedepentViewModel;
using Corona.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Controllers
{
    public class MainMembersController : Controller
    {
        private readonly CoronaContext connContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IEmailSender emailSender;
        private IDependentRepository dependentRepository;

        public MainMembersController(CoronaContext connContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            ILogger<AccountController> logger, IEmailSender emailSender, IDependentRepository repository)
        {
            this.connContext = connContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            dependentRepository = repository;
        }
        public async Task<IActionResult> Index()
        {
            //var currentUser = await userManager.GetUserAsync(HttpContext.User);
            //var dependents = await dependentRepository.DependeAsync(currentUser.Id);
            //var patientViewModel = dependents.Select(a => new PatientViewModel
            //{
            //    FirstName = a.FirstName,
            //    LastName = a.LastName,
            //    PhoneNumber = a.PhoneNumber,
            //    AddressLine1 = a.AddressLine1,
            //}).ToList();
            //return View(patientViewModel);

            var userId = userManager.GetUserId(HttpContext.User);

            if (userId == null)
            {
                return RedirectToAction(nameof(AccountController.Login), "Accounts");
            }
            else
            {
                ApplicationUser user = userManager.FindByIdAsync(userId).Result;
                return View(user);
            }
        }

        private IActionResult View(ApplicationUser user, List<PatientViewModel> patientViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
