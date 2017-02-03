using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EZLF.Models
{
    public class HomeModel
    {
    }

    public class ContactModel
    {
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }

     
    }
}