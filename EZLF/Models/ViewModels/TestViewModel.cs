using EZLF.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZLF.Models.ViewModels
{
    public class TestViewModel
    {
        public int ActionCount { get; set; }

        public TestViewModel()
        {
            int aCount = DBHelper.GetActionCount();
            this.ActionCount = aCount;
        }
    }
}