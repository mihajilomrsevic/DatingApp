using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            // fetch-uje sve korisnike
            if (await context.Users.AnyAsync()) return;

            // cita sve iz JSON-a
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            // prebacuje u AppUser oblik
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            if (users == null) return;

            foreach(var user in users)
            {
                // priprema random string za kriptovanje
                using var hmac = new HMACSHA512();

                // prebacuje username u mala slova
                user.UserName = user.UserName.ToLower();
                // priprema Hash od zadatakog stringa
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                // priprema kljuc 
                user.PasswordSalt = hmac.Key;

                // dodaje korisnika
               await context.Users.AddAsync(user);
            }

            // cuva u bazi
            await context.SaveChangesAsync();
        }
    }
}
