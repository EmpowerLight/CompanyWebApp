using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApp.Models
{
    public class RegisterModel
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Password Should be more than 5 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        public int ContactNumber { get; set; }
    }
}