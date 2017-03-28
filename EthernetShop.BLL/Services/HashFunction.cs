using EthernetShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EthernetShop.BLL.Services
{
    public static class HashFunction
    {
        public static string HashFunc(string inputString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            return BitConverter.ToString(checkSum).Replace("-", String.Empty);
        }
    }
}
