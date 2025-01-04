using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS
{
    internal class Recipient
    {
        public static string InternalEmail { get; } = UserConfig.Email;
        public static string MessageSubject { get; } = "Säkert meddelande";
        public static string MessageBody { get; } = "Detta är ett säkert meddelande";
        public static string MeetingSubject { get; } = "Säkert möte";
        public static string MeetingBody { get; } = "Detta är ett säkert möte";
    }
}
