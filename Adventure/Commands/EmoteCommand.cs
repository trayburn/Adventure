using System;
using System.Linq;
using System.Collections.Generic;
using Adventure.Data;

namespace Adventure.Commands
{
    public class EmoteCommand : ICommand
    {
        private Dictionary<string, string> dict;
        private IConsoleWrapper console;

        public EmoteCommand(IConsoleWrapper console)
        {
            dict = new Dictionary<string, string>();
            AddCommand("LOL", "You laugh out loud!");
            AddCommand("fence", "You fence with {1}!");
            this.console = console;
        }

        private void AddCommand(string cmd, string msg)
        {
            dict.Add(cmd.ToLower(), msg);
        }

        public bool IsValid(string cmd)
        {
            string firstWord = cmd.Split(' ')[0];
            return dict.ContainsKey(firstWord.ToLower());
        }

        public void Execute(string cmd)
        {
            string[] words = cmd.Split(' ');
            console.WriteLine(dict[words[0].ToLower()], words);
        }
    }
}
