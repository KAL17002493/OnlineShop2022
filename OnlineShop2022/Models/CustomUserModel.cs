using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop2022.Models
{
    public class CustomUserModel : IdentityUser
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string SName { get; set; }
    }
}
