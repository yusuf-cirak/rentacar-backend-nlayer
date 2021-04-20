using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) // Verdiğimiz şifrenin hash'ini ve salt'ını oluşturacak.
        { // out keyword'ünü dışarıya verilecek değer olarak düşünebiliriz.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; // Her kullanıcı için bir key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // string'i byte çevirme yöntemi. byte[] array'i tanımladığımız için
            }                                                                      // convert yapmamız şart.
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // Burada out olmamalı çünkü burada değeri biz vereceğiz.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //computedHash = hesaplanan hash
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }


        }

    }
}