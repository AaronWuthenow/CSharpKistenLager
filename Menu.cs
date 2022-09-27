using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lagersystem
{
    internal class Menu
    {
        static public void MainMenu()
        {
            WriteLine("------------------------");
            WriteLine("1. Create a Box");
            WriteLine("2. Change a Box");
            WriteLine("3. Delete a Box");
            WriteLine("4. Show a Box");
            WriteLine("5. Show all Boxes");
            WriteLine("6. Quit");
            WriteLine("------------------------");
        }

        static public void Options()
        {
            WriteLine("------------------------");
            WriteLine("1. Search Box with ID");
            WriteLine("2. Search Box with Index");
            WriteLine("3. Back to main menu");
            WriteLine("------------------------");
        }
    }
}
