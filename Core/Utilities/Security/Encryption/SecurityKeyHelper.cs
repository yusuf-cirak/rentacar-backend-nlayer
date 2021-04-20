using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        { //securityKey= mysupersecuritykey(WebAPI>appsettingsjson) tanımlaması ile arasındaki uyumu ve bağlantıyı oluşturduk.
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
