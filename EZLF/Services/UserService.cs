using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZLF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EZLF.Services
{
    public class UserService : IUserService
    {
        // Service Definitions
        private readonly Entities db;
        private static string _operatorRoleId;
        private static readonly object padlock = new object();
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        // Service Constructor
        public UserService(Entities db, IUserStore<USER> userStore, IRoleStore<IdentityRole, string> roleStore)
        {
            this.db = db;
            userManager = new UserManager<User>(userStore);
            roleManager = new RoleManager<IdentityRole>(roleStore);
            // Comment for commit
            // Comment for commit v2
            int temp = -1;

            if (_operatorRoleId == null)
            {
                lock (padlock)
                {
                    if (_operatorRoleId == null)
                    {
                        // ReSharper disable PossibleMultipleWriteAccessInDoubleCheckLocking
                        // _operatorRoleId = roleManager.FindByName(User.OPERATOR_ROLE).Id;
                        // ReSharper restore PossibleMultipleWriteAccessInDoubleCheckLocking
                    }
                }
            }
        }



        // Service Methods

        public UserService()
        {
            // placeholder
        }


        public USER GetByID(int ID)
        {
            USER retVal = new USER();



            return retVal;
        }

        public USER Login(string email, string password, string fbKey, string gpKey, string tuKey)
        {
            USER retVal = new USER();




            return retVal;
        }
    }
}