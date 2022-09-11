using Corona.Data;
using Corona.Models;
using Corona.Models.Content;
using Corona.Models.Repositories.FavouriteSuburbs;
using Corona.Models.ViewModel.SuburbViewModel;
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
    public class FavouriteSuburbController : BaseController
    {
        private UserManager<ApplicationUser> userManager;
        private readonly CoronaContext _context;
        private IFavouriteSuburbRepository favouriteSuburbRepository;

        public FavouriteSuburbController(UserManager<ApplicationUser> userManager, CoronaContext context, IFavouriteSuburbRepository favouriteSuburbRepository)
        {
            this.userManager = userManager;
            _context = context;
            this.favouriteSuburbRepository = favouriteSuburbRepository;
                
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await userManager.GetUserAsync(HttpContext.User);
            var favourates = await favouriteSuburbRepository.FavouriteAsync(currentUser.Id);
            var FavourateViewModel = favourates.Select(a => new NurseFavouriteViewModel
            {
                NurseId = a.NurseId,
                SuburbId = a.Suburb.SuburbName
            }).ToList();
            return View(FavourateViewModel);
        }
        [HttpGet]
        public  IActionResult AddFavouriteSuburb()
        {
            PopulateSuburbDropDownList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFavouriteSuburb(NurseFavouriteViewModel model)
        {
            if(ModelState.IsValid)
            {
                PopulateSuburbDropDownList(model.SuburbId);

                try
                {
                    var currentUser = await userManager.GetUserAsync(HttpContext.User);
                    await favouriteSuburbRepository.AddFavouriteSuburb(
                        currentUser.Id,
                        model.SuburbId
                        );
                    Notify("Nurse Favourate suburb has been successfully added");
                    return RedirectToAction(nameof(FavouriteSuburbController.Index), "FavourateSuburb");
                }
                catch(Exception)
                {

                }  
            }

            PopulateSuburbDropDownList(model.SuburbId);
            return View(model);
        }
        private void PopulateSuburbDropDownList(object selectSuburbName = null)
        {
            var SuburbQuery = from d in _context.tblSuburb
                              orderby d.SuburbName
                              select d;

            ViewBag.SuburbId = new SelectList(SuburbQuery.AsNoTracking(), "SuburbId", "SuburbName", selectSuburbName);
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
