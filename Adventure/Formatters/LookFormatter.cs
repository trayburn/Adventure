using System;
using Adventure.Data;

namespace Adventure.Formatters
{
    public class LookFormatter : IFormatter
    {
        private IConsoleWrapper console;

        public LookFormatter(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Format(GameObject obj)
        {
            console.WriteLine(obj.Name);
            console.WriteLine(obj.Description);
        }
    }
}
