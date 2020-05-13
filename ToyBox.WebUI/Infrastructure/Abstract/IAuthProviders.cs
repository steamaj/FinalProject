using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyBox.WebUI.Infrastructure.Abstract
{
    public interface IAuthProviders
    {
        bool Authenticate(string email, string password);
    }
}
