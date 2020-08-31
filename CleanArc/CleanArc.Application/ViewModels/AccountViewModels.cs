using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArc.Application.ViewModels
{
    public class Register   
    {
        [Required]
        [MaxLength(150)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } 
    }
}
