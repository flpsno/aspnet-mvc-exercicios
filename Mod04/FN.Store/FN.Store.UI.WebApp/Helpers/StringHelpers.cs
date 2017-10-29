using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FN.Store.UI.WebApp.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            texto += "|cf27eb87-1204-407e-b76c-7a865832f84A";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(System.Text.Encoding.GetEncoding(0).GetBytes(texto));
            var sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }

    }
}