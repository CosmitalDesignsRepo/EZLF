using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZLF.Models.Helper
{
    public class DBHelper
    {
        // Put all DB access routines here, so they can be written once and accessed from any class
        public static int GetActionCount()
        {
            int retVal = -1;

            using (var db = new Entities())
            {
                try
                {
                    var query = (from b in db.ASSOCIATIONS
                                select b).Count();

                    retVal = query;
                }
                catch
                {
                    // catch this
                }
            }

            return retVal;
        }
    }
}