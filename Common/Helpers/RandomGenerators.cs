using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Customerize.Common.Helpers
{
    public class RandomGenerators
    {
        static long counter;
        public string CreateRandomString()
        {
            long count = System.Threading.Interlocked.Increment(ref counter);
            int CodeLength = 10;
            String _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
            Byte[] randomBytes = new Byte[CodeLength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            char[] chars = new char[CodeLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < CodeLength; i++)
            {
                while (randomBytes[i] > byte.MaxValue - (byte.MaxValue % allowedCharCount))
                {
                    byte[] tmp = new byte[1];
                    rng.GetBytes(tmp);
                    randomBytes[i] = tmp[0];
                }
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }
            byte[] buf = new byte[8];
            buf[0] = (byte)count;
            buf[1] = (byte)(count >> 8);
            buf[2] = (byte)(count >> 16);
            buf[3] = (byte)(count >> 24);
            buf[4] = (byte)(count >> 32);
            buf[5] = (byte)(count >> 40);
            buf[6] = (byte)(count >> 48);
            buf[7] = (byte)(count >> 56);
            return Convert.ToBase64String(buf) + new string(chars);
        }
        public string GenarateNumberCode()
        {
            long count = System.Threading.Interlocked.Increment(ref counter);

            var date = DateTime.Now.Year;
            var chars = "023ABCDEFG9";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string test = new string(stringChars) + date;
            return test;
        }
    }
}
