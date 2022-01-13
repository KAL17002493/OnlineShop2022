using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomUserModel> _userManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<CustomUserModel> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
