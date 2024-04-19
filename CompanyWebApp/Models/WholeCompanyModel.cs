using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyWebApp.Models
{
    public class WholeCompanyModel
    {
        public CompanyModel Company { get; set; }

        public CompanyInfoModel CompanyInfo { get; set; }
    }
}