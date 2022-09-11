using Corona.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using Corona.Models;

namespace Corona.Controllers
{
    public class ClaimController : BaseController
    {
        private readonly CoronaContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimController(CoronaContext context,
                                UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var claims = _context.tblClaims.ToList();
            return View(claims);
        }

        public IActionResult New()
        {
            return View(new Models.Claim());
        }

        [HttpPost]
        public async Task<IActionResult> New(Models.Claim claim)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(claim);
                }
                else
                {
                    claim.ClaimValue = claim.ClaimValue.ToString();

                    _context.tblClaims.Add(claim);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AssignClaimToUser(string userId)
        {
            try
            {
                var claims = _context.tblClaims.ToList();
                claims = claims.Select(x =>
                {
                    x.ClaimType = $"Type = {x.ClaimType} and Value = {x.ClaimValue}";
                    return x;
                }).ToList();

                ViewBag.Claims = new SelectList(claims, "Id", "ClaimType");

                var user = await _userManager.FindByIdAsync(userId);
                ViewBag.UserName = user.UserName;
                ViewBag.UserId = userId;

                var userClaims = await _userManager.GetClaimsAsync(user);

                return View(userClaims);
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AssignClaimToUser(string userId,int claimId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var claim = _context.tblClaims.FirstOrDefault(x => x.Id == claimId);

                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(claim.ClaimType, claim.ClaimValue));

                return RedirectToAction(nameof(AssignClaimToUser), new { userId = userId });
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveClaimFromUser(string userId,string claimType,string claimValue)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                await _userManager.RemoveClaimAsync(user, new System.Security.Claims.Claim(claimType, claimValue));
                return RedirectToAction(nameof(AssignClaimToUser), new { userId = userId });
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var claim = _context.tblClaims.FirstOrDefault(x => x.Id == id);
                _context.tblClaims.Remove(claim);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }
    }
}