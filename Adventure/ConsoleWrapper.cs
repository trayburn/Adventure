using System;

namespace Adventure
{
    public class ConsoleWrapper : IConsoleWrapper
    {

        public void WriteLine(string msg = null, params object[] args)
        {
            Console.WriteLine(msg ?? "", args);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string msg, params object[] args)
        {
            Console.Write(msg, args);
        }
    }
}
