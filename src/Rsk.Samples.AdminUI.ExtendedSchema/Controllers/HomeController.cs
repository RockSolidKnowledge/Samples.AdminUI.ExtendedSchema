using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.AdminUI.ExtendedSchema.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ExtendedUser> userManager;
        private readonly ExtendedDbContext context;

        public HomeController(UserManager<ExtendedUser> userManager, ExtendedDbContext context)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IActionResult> Index()
        {
            await Seed();

            List<ExtendedUser> foundUsers = userManager.Users
                .Include(x => x.Department)
                .Where(x => x.DepartmentId == 1)
                .ToList();

            return View(foundUsers);
        }

        private async Task Seed()
        {
            if (!context.Departments.Any())
            {
                context.Departments.Add(new Department {Id = 1, Name = "Software Engineering"});
                context.SaveChanges();
            }

            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(new ExtendedUser
                {
                    UserName = "scott",
                    DepartmentId = 1
                }, "Password123!");
            }
        }
    }
}