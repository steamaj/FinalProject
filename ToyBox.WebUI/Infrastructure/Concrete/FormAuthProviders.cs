using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ToyBox.WebUI.Infrastructure.Abstract;

namespace ToyBox.WebUI.Infrastructure.Concrete
{
    public class FormAuthProviders : IAuthProviders
    {
        public bool Authenticate(string email, string password)
        {
            bool result = FormsAuthentication.Authenticate(email, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(email, false);
            }
            return result;
        }
    }
}