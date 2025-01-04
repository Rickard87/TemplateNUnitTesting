using NUnitLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestSEFOS
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error: Exactly 2 arguments are required.");
                return 2; // Invalid argument error
            }

            foreach (var arg in args)
            {
                if (!IsValidEmail(arg))
                {
                    Console.WriteLine($"Error: Invalid email format: '{arg}'");
                    return 2;
                }
            }

            UserConfig.Email = args[0];
            UserConfig.OtherUserEmail = args[1];

            //return 0;
            return new AutoRun().Execute(new string[] { });
        }
        private static bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}