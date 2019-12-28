using System.Text;
using System.Security.Cryptography;

namespace GameControllerProject.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToMD5(this string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            string password = (str += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
                sb.Append(item.ToString("x2"));

            return sb.ToString();

        }
    }
}
