using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.Utilities
{
    public static class AccountNumberGenerator
    {
        public static string GenerateAccountNumber()
        {
            StringBuilder num = new StringBuilder("222", 10);
            Random random = new Random();

            for (int i = 0; i < 7; i++)
            {
                int n = random.Next(0, 9);
                num.Append(n);
            }
            return num.ToString();
        }
    }
}
