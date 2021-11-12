using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GerenTarefas.Utils
{
    public class MD5Utils
    {
        public static string GerarHashMD5(string input)
        {
            MD5 md5Hash = MD5.Create();
            var bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBiulder = new StringBuilder();
            foreach(var b in bytes)
            {
                sBiulder.Append(b.ToString("X2"));
            }

            return sBiulder.ToString();
        }

        internal static object GerarHasMD5(string senha)
        {
            throw new NotImplementedException();
        }
    }
}
