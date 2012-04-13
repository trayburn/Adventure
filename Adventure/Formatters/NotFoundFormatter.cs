using System;
using System.Linq;
using Adventure.Data;

namespace Adventure.Formatters
{
    public class NotFoundFormatter : IFormatter
    {
        private IConsoleWrapper console;

        public NotFoundFormatter(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Format(GameObject obj)
        {
            console.WriteLine("I don't see that here");
        }
    }
}
