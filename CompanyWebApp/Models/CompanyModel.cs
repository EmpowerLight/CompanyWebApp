using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApp.Models
{
    public class CompanyModel
    {
        [Key]
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public int MobileNumber { get; set; }
    }
}