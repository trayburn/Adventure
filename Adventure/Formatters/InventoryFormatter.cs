using System;
using Adventure.Data;
using Adventure;

namespace Adventure.Formatters
{
    public class InventoryFormatter : IFormatter
    {
        private IConsoleWrapper console;

        public InventoryFormatter(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Format(GameObject obj)
        {
            if (obj.Inventory.Count > 0)
            {
                console.WriteLine();
                console.WriteLine("Inventory:");
                var count = 0;
                foreach (var item in obj.Inventory)
                {
                    count++;
                    console.Write("{0,-20}", item.Name);
                    if ((count % 3) == 0)
                        console.WriteLine();
                }
                console.WriteLine();
            }
        }
    }
}
