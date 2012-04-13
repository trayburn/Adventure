using System;
using System.Linq;
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
                    if (typeof(Exit).IsInstanceOfType(item) == false &&
                        typeof(Player).IsInstanceOfType(item) == false)
                    {
                        count++;
                        console.Write("{0,-20}", item.Name);
                        if ((count % 3) == 0)
                            console.WriteLine();
                    }
                }

                var nonHiddenExits = obj.Inventory.OfType<Exit>().Where(m => m.Statuses.Any(x => x.Value == "Hidden") == false);
                if (nonHiddenExits.Count() > 0)
                {
                    console.WriteLine();
                    console.WriteLine("Exits:");
                    count = 0;
                    foreach (var item in nonHiddenExits)
                    {
                        count++;
                        console.Write("{0,-20}", item.Name);
                        if ((count % 3) == 0)
                            console.WriteLine();
                    }
                }
                console.WriteLine();
            }
        }
    }
}
