using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        { //WebAPI'nin kullanabileceği jsonwebtoken'ların oluşturulabilmesi için, bir sisteme girebilmek için elimizde olanlardır.
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature); //Kullanılacak anahtar ve algoritma
            // mysupersecretsecuritykey'i byte[] haline getiriyoruz.
        }
    }
}
