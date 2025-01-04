using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS
{
    internal class UserConfig
    {
        public static string LoginURL { get; } = "https://anonymized.se/login";
        public static string Email { get; set; } = "";
        public static string OtherUserEmail { get; set; } = "";
        public static int DefaultWaitTime { get; } = 30;
    }
}