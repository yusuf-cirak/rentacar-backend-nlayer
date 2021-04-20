using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType) 
        { 
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            // Buradaki soru işareti ifadenin null olabileceğini de belirtiyor.
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        { // Extension işlemi yapıyoruz. Var olan ClaimsPrincipal sınıfına kendi methodlarımızı ekliyoruz.
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
