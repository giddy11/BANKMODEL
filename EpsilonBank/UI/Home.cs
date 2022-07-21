using EpsilonBank.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonBank.UI
{
    public static class Home
    {
        public static void HomePage()
        {
            Console.Clear();
            Console.WriteLine("@**************************************************************************@");
            Console.WriteLine("Welcome to Epsilon Bank! Giving platinum experiences one customer at a time");
            Console.WriteLine("@**************************************************************************@");


            Console.WriteLine(@"What would you like to do?
Chhose an option to give instruction.
1: SignUp
2: SignIn
3: Exit Application");
            Console.WriteLine("Enter your desired option");
            var _option = Console.ReadLine();
            string error;
            while (!Validator.ValidateNumber(_option,out error) || (float.Parse(_option)<1 ||float.Parse(_option)>3))
            {
                Console.WriteLine("Enter your desired option");
                _option = Console.ReadLine();
            }

           float option = float.Parse(_option);

            if (option == 1)
            {
                LoginMenu.SignUp();
            }else if (option == 2)
            {
                LoginMenu.SignIn();
            }
            else
            {
                Environment.Exit(0);
            }

            

        }
    }
}
