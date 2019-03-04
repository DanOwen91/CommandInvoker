using System;
using System.Text;

namespace Logger
{
    public static class Logger
    {
        static Logger()
        {

        }

        public static void Log(LogLevel Level, string Message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("HH:mm MM/dd/yyyy"));
            sb.Append(DateTime.Now.ToString(Message));

            Console.WriteLine(sb.ToString());
        }
    }

    public enum LogLevel
    {
        Debug = 1,
        Critical,
        Error,
        Information,
    }
}
