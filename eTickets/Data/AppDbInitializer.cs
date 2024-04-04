//using eTickets.Data.Enums;
//using eTickets.Data.Static;
//using eTickets.Models;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace eTickets.Data
//{
//    public class AppDbInitializer
//    {


//        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {

//                //Roles
//                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
//                if (!await roleManager.RoleExistsAsync(UserRoles.User))
//                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

//                //Users
//                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//                string adminUserEmail = "Nitishnayal123@gmail.com";

//                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
//                if (adminUser == null)
//                {
//                    var newAdminUser = new ApplicationUser()
//                    {
//                        FullName = "NitishNayal",
//                        UserName = "Nitish",
//                        Email = adminUserEmail,
//                        EmailConfirmed = true
//                    };
//                    await userManager.CreateAsync(newAdminUser, "Nitish@2024");
//                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
//                }



//            }
//        }
//    }
//}