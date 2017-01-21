using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZLF.Models;

namespace EZLF.Services
{
    public interface IUserService
    {
        // function headers for IUserService
        USER GetByID(int ID);
        USER Login(string email, string password, string fbKey, string gpKey, string tuKey);
         
    }
}
