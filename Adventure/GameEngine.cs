using System;
using System.Collections.Generic;
using System.Linq;

namespace Adventure
{
    public class GameEngine
    {
        private ICommand[] cmdList;
        private IConsoleWrapper console;

        public GameEngine(IConsoleWrapper console, ICommand[] cmdList)
        {
            this.cmdList = cmdList;
            this.console = console;
        }

        public void RunLoop()
        {
            string currentLine;
            do
            {
                console.Write("> ");
                currentLine = console.ReadLine();

                ICommand cmd = cmdList.FirstOrDefault(m => m.IsValid(currentLine));
                if (cmd != null) cmd.Execute(currentLine);
                else if (currentLine != "exit") console.WriteLine("Unknown Command");
            } while (currentLine != "exit");

        }
    }
}
