using Nancy.Authentication.Basic;
using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo
{
    public class BasicUserValidator:IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            if (username == "linezero" && password == "demo")
            {
                return new BasicUser() { UserName = username };
            }
            return null;
        }
    }
}
