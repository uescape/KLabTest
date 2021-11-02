using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KLabTest.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please provide email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}
