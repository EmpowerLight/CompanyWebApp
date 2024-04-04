using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApp.Models
{
    public class CompanyInfoModel
    {
        [Key]
        public int Cid { get; set; }
        public DateTime DateOfInstallation { get; set; } = DateTime.Now;

        public DateTime DateOfRenew { get; set; } = DateTime.Now;

        public string DisplayMessage { get; set; }

        public string Remarks { get; set; }

        public string Attachment { get; set; }
        [Required]
        public int Id { get; set; }
    }
}