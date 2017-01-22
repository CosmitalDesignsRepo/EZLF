using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZLF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
using EZLF.Class.Helpers;
using EZLF.Class;

namespace EZLF.Services
{
    public class BaseServices
    {
        private const string _userKey = "FrameworkUser";


        public int GetUserID()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return 0;

            return HttpContext.Current.User.Identity.Name.IntParse();
        }


        public USER GetCurrentUser()
        {
            var user = new USER();

            if (HttpContext.Current.Request.IsAuthenticated)
            {
                if (HttpContext.Current.Session[_userKey] != null)
                    user = (USER)HttpContext.Current.Session[_userKey];
                else
                {
                    user = GetUser(HttpContext.Current.User.Identity.Name.IntParse());
                    HttpContext.Current.Session[_userKey] = user;
                }
            }

            return user;
        }

        public USER GetUser(int id)
        {
            using (var db = new Entities())
            {
                var user = db.USERS.Where(m => m.ID == id).FirstOrDefault();
                return user;
            }

        }

        public void RefreshCurrentUser()
        {
            HttpContext.Current.Session[_userKey] = GetUser(HttpContext.Current.User.Identity.Name.IntParse());
        }


    }
}