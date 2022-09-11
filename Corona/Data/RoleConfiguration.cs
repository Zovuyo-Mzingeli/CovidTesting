using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Corona.Data
{
    public static class RoleConfiguration 
    {
        public static async Task Initial(RoleManager<IdentityRole>roleManager)
        {
            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("TrustedAdmin"))
            {
                var users = new IdentityRole("TrustedAdmin");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("Nurse"))
            {
                var users = new IdentityRole("Nurse");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("Doctor"))
            {
                var users = new IdentityRole("Doctor");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("Pharmacist"))
            {
                var users = new IdentityRole("Pharmacist");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("Patient"))
            {
                var users = new IdentityRole("Patient");
                await roleManager.CreateAsync(users);
            }
        }
    }
}
