using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        public CustomUserModel User { get; set; }

        public List<string> Roles { get; set; }
    }
}
