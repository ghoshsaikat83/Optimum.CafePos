using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Optimum.CafePos.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter {0}")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Enter {0}")]
        [Display(Name = "OTP")]
        public string OTP { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class SessionDataModel
    {
        public int LocationCode { get; set; }
        public string Mobile { get; set; }
        public string Fullname { get; set; }
    }
}
