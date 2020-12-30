using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            // fetch-uje sve korisnike
            if (await userManager.Users.AnyAsync()) return;

            // cita sve iz JSON-a
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            // prebacuje u AppUser oblik
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name="Member"},
                new AppRole{Name="Admin"},
                new AppRole{Name="Moderator"}
            };

            foreach(var role in roles)
            {
                await roleManager.CreateAsync(role);
            }


            foreach(var user in users)
            {

                // prebacuje username u mala slova
                user.UserName = user.UserName.ToLower();

                // dodaje korisnika
                //await context.Users.AddAsync(user);

                await userManager.CreateAsync(user, "Passw0rd");
                await userManager.AddToRoleAsync(user, "Member");
            }
            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Passw0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });

            // cuva u bazi
            //await context.SaveChangesAsync();
        }
    }
}
