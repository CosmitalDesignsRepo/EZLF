using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZLF.Class.Helpers
{
    public enum LogInResult
    {
        Success,
        Failed,
        RequirePasswordChange,
        DatabaseError
    }
}