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
    public class UserService : BaseServices, IUserService
    {
        // Service Definitions
        private readonly Entities db;
        private static string _operatorRoleId;
        private static readonly object padlock = new object();
        //private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private const string _userKey = "FrameworkUser";
        private const string _impernatingUserKey = "FrameworkImpersonatingUser";
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // Service Methods

        public UserService()
        {
            // placeholder
        }



        /// <summary>
        /// Login user, The hash code generation is base on the original website. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pw"></param>
        /// <param name="rememberMe"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public LogInResult Login(string username, string pw, bool rememberMe = false, string session = "")
        {


            try
            {
                using (var db = new Entities())
                {
                    var usr = GetByName(username);
                    if (usr != null && usr.ID > 0)
                    {
                        if (usr.PASSWORDHASH == Authentication.ComputePasswordHash((int)usr.ID, pw))
                        {
                            HttpContext.Current.Session.Clear();

                            usr.LASTDATE = DateTime.Now;


                            db.SaveChanges();

                            FormsAuthentication.SetAuthCookie(usr.ID.ToString(), rememberMe);

                            HttpContext.Current.Session[_userKey] = usr;

                            return LogInResult.Success;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return LogInResult.DatabaseError;
            }

            return LogInResult.Failed;
        }

        /// <summary>
        /// Logoff User
        /// </summary>
        public void LogOff()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Clear();
        }

        /// <summary>
        /// Force a user to log off
        /// </summary>
        /// <param name="id"></param>
        public void ForceLogin(int id)
        {
            using (var db = new Entities())
            {
                var usr = GetByID(id);

                if (usr == null)
                    return;
                HttpContext.Current.Session.Clear();

                usr.LASTDATE = DateTime.Now;
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(usr.ID.ToString(), false);
                HttpContext.Current.Session[_userKey] = usr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void ImpersonateUser(int id)
        {
            var newUser = GetByID(id);
            var currentUser = GetCurrentUser();

            LogOff();

            FormsAuthentication.SetAuthCookie(newUser.ID.ToString(), false);
            HttpContext.Current.Session["ImpersonatedBy"] = currentUser;
            HttpContext.Current.Session[_userKey] = newUser;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CancelImpersonation()
        {
            var currentUser = (USER)HttpContext.Current.Session["ImpersonatedBy"];

            LogOff();

            FormsAuthentication.SetAuthCookie(currentUser.ID.ToString(), false);
            HttpContext.Current.Session[_userKey] = currentUser;
        }


        /// <summary>
        /// Get a user object by the userID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public USER GetByID(int ID)
        {

            using (var db = new Entities())
            {
                var user = db.USERS.Where(m => m.ID == ID).FirstOrDefault();
                return user;
            }

        }

        /// <summary>
        /// Get the user object by the user Name, which is the email address at this case.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public USER GetByName(string userName)
        {
            using (var db = new Entities())
            {
                var user = db.USERS.Where(m => m.EMAIL == userName).FirstOrDefault();
                return user;
            }
        }


    }
}