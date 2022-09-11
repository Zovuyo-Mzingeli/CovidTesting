using System.Linq;
using System.Threading.Tasks;
using Corona.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Corona.Controllers
{
    //[Authorize]
    public class UserRoleManagementController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserRoleManagementController(UserManager<ApplicationUser> userManager,
                                            RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var users = userManager.Users.ToList();
                return View(users);
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);

                ViewBag.UserName = user.UserName;

                var userRoles = await userManager.GetRolesAsync(user);

                return View(userRoles);
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            try
            {
                return RedirectToAction(nameof(DisplayRoles));
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string role)
        {
            try
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = role });
                return RedirectToAction(nameof(DisplayRoles));
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public IActionResult DisplayRoles()
        {
            try
            {
                var roles = roleManager.Roles.ToList();

                return View(roles);
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddUserToRole()
        {
            try
            {
                var users = userManager.Users.ToList();
                var roles = roleManager.Roles.ToList();

                ViewBag.Users = new SelectList(users, "Id", "UserName");
                ViewBag.Roles = new SelectList(roles, "Name", "Name");
                return View();
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRole userRole)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userRole.UserId);

                await userManager.AddToRoleAsync(user, userRole.RoleName);

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }

            return RedirectToAction(nameof(ClaimController.Index), "Claim");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string role,string userName)
        {
            try
            {
                var user = await userManager.FindByNameAsync(userName);

                var result = await userManager.RemoveFromRoleAsync(user, role);

                return RedirectToAction(nameof(Details), new { userId = user.Id });
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRole(string role)
        {
            try
            {
                var roleToDelete = await roleManager.FindByNameAsync(role);
                var result = await roleManager.DeleteAsync(roleToDelete);

                return RedirectToAction(nameof(DisplayRoles));
            }
            catch (System.Exception)
            {
                Notify("There must be a problem with you browser try go back and refresh", notificationType: NotificationType.error);
            }
            return View();
        }
    }
}