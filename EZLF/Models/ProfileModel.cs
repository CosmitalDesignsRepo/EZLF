using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EZLF.Models
{
    public class EditProfileModel
    {
        public USER user { get; set; }
        public List<LT_COUNTRY> countries { get; set; }
        public List<LT_STATEPROV> states { get; set; }
    }
}