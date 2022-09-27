using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagersystem
{
    internal class Menu
    {
        static public void MainMenu()
        {
            Console.WriteLine("1. Create a Box");
            Console.WriteLine("2. Change a Box");
            Console.WriteLine("3. Delete a Box");
            Console.WriteLine("4. Show a Box");
            Console.WriteLine("5. Show all Boxes");
            Console.WriteLine("6. Quit");
        }

        static public void Options()
        {
            Console.WriteLine("1. Search Box with ID");
            Console.WriteLine("2. Search Box with Index");
            Console.WriteLine("3. Back to main menu");
        }
    }
}
