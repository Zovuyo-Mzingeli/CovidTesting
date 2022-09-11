using Corona.Data;
using Corona.Models;
using Corona.Models.Content;
using Corona.Models.Repositories.DependentRepository;
using Corona.Models.ViewModel.DedepentViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Controllers
{
    public class DependentController : BaseController
    {
        private UserManager<ApplicationUser> userManager;
        private IDependentRepository dependentRepository;
        private readonly CoronaContext _context;
        public DependentController(CoronaContext context, UserManager<ApplicationUser> userMgr, IDependentRepository repository)
        {
            _context = context;
            userManager = userMgr;
            dependentRepository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var dependents = await dependentRepository.DependeAsync(currentUser.Id);
            var patientViewModel = dependents.Select(a => new PatientViewModel
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                AddressLine1 = a.AddressLine1,
            }).ToList(); 
            return View(patientViewModel);
        }
        [HttpGet]
        public async  Task<IActionResult> AddDepedent()
        {
            PopulateSuburbDropDownList();
            PopulateCityDropDownList();
            PopulateMedicalAidDropDownList();
            PopulateMedicalPlanDropDownList();

            var user = await userManager.GetUserAsync(User);

            if(/*user.Idnumber == null &&*/ user.PhoneNumber == null)
            {
                Notify("A patient profile must be completed. Before a dependent can be added");
                return RedirectToAction(nameof(AccountController.EditUser), "Account");
            }
            else
            {
                 return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddDepedent(PatientViewModel model)
        {
            if(ModelState.IsValid)
                PopulateSuburbDropDownList(model.SuburbId);
                PopulateCityDropDownList(model.CityId);
                PopulateMedicalAidDropDownList(model.MedicalAidId);
                PopulateMedicalPlanDropDownList(model.MedicalPlanId);
            {


                try
                {
                    var currentUser = await userManager.GetUserAsync(HttpContext.User);
                    await dependentRepository.AddDependentAsync(

                        currentUser.Id,
                        model.Dob,
                        model.Idnumber,
                        model.FirstName, 
                        model.LastName,
                        model.Gender,
                        model.Email,
                        model.PhoneNumber,
                        model.AddressLine1,
                        model.AddressLine2,
                        model.CityId,
                        model.SuburbId,
                        model.PostalCode,
                        model.MedicalAidId,
                        model.MedicalAidNumber,
                        model.MedicalPlanId
                        );

                    Notify("A dependent has been successfully added");
                    return RedirectToAction(nameof(MainMembersController.Index), "MainMembers");
                }
                catch(Exception)
                {

                }
            }
            return View(model);
        }
        private void PopulateCityDropDownList(object selectCityName = null)
        {
            var CityQuery = from d in _context.tblCity
                            orderby d.CityName
                            select d;
            ViewBag.CityId = new SelectList(CityQuery.AsNoTracking(), "CityId", "CityName", selectCityName);

        }

        private void PopulateSuburbDropDownList(object selectedCity = null)
        {
            var SuburbQuery = from d in _context.tblSuburb
                              orderby d.SuburbName
                              select d;
            ViewBag.SuburbId = new SelectList(SuburbQuery.AsNoTracking(), "SuburbId", "SuburbName",
            selectedCity);
        }
        private void PopulateMedicalAidDropDownList(object selectMedicalAid = null)
        {
            var AidQuery = from d in _context.tblMedicalAid.Distinct().AsNoTracking()
                           orderby d.MedicalName
                           select d;

            ViewBag.MedicalAidId = new SelectList(AidQuery.AsNoTracking(), "MedicalAidId", "MedicalName", selectMedicalAid);


        }
        private void PopulateMedicalPlanDropDownList(object selectMedicalPlan = null)
        {
            var AidQuery = from d in _context.tblMedicalPlans.Distinct().AsNoTracking()
                           orderby d.PlanName
                           select d;

            ViewBag.MedicalPlanId = new SelectList(AidQuery.AsNoTracking(), "MedicalPlanId", "PlanName", selectMedicalPlan);


        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        
    }
}
