using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentLine;
            List<ICommand> cmdList = new List<ICommand>();
            cmdList.Add(new LaughCommand());

            do 
            {
                Console.Write("> ");
                currentLine = Console.ReadLine();

                ICommand cmd = cmdList.FirstOrDefault(m => m.IsValid(currentLine));
                if (cmd != null) cmd.Execute(currentLine);
            } while (currentLine != "exit");
        }
    }

    interface ICommand
    {
        bool IsValid(string cmd);
        void Execute(string cmd);
    }

    class LaughCommand : ICommand
    {

        public bool IsValid(string cmd)
        {
            return cmd == "lol";
        }

        public void Execute(string cmd)
        {
            Console.WriteLine("You laugh out loud!");
        }
    }
}
