using System;

namespace Adventure
{
    public interface ICommand
    {
        bool IsValid(string cmd);
        void Execute(string cmd);
    }
}
