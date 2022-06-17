using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Identity
{
    //Middleware will also be used for Authentication processes
    public interface IJWTAuthenticationService
    {
       string Authenticate(string username, string password);
    }
}
