using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Material.Utils
{
    public class MD5Util
    {
        public static string GetMD5Hash(string Message, bool MD5_Mode)
        {
            try
            {
                byte[] result = Encoding.Default.GetBytes(Message);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] output = md5.ComputeHash(result);
                if (MD5_Mode == true) return BitConverter.ToString(output).Replace("-", "");//32位MD5值
                else return BitConverter.ToString(output, 4, 8).Replace("-", "");           //16位MD5值
            }
            catch 
            { 
                Console.WriteLine("MD5生成失败");
                return "";
            }
        }
    }
}
