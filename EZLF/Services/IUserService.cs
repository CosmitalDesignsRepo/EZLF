﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZLF.Models;
using EZLF.Class.Helpers;

namespace EZLF.Services
{
    public interface IUserService
    {

        #region Login Related

        LogInResult Login(string userName, string password, bool rememberMe = false, string sess = "");
        void LogOff();
        void ForceLogin(int id);
        void ImpersonateUser(int id);
        void CancelImpersonation();

        #endregion

        #region Password Related



        #endregion

        #region Register User

        USER UpdateUser(USER user);
        USER CreateUser(USER user);
        #endregion

        // function headers for IUserService
        USER GetByID(int ID);
        USER GetByName(string userName);




        //Get countries
        List<LT_COUNTRY> GetCountries();
        //Get states
        List<LT_STATEPROV> GetStates();
    }
}