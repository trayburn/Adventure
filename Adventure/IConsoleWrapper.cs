using System;

namespace Adventure
{
    public interface IConsoleWrapper
    {
        void WriteLine(string msg = null, params object[] args);
        void Write(string msg, params object[] args);
        string ReadLine();
    }
}
