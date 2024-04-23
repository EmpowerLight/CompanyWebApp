using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWebApp.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public string PaymentType { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public int Cid { get; set; }

    }
}