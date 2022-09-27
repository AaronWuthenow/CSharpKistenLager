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
            WriteLine("------Main------");
            WriteLine("1. Create a Box");
            WriteLine("2. Change a Box");
            WriteLine("3. Delete a Box");
            WriteLine("4. Show a Box");
            WriteLine("5. Show all Boxes");
            WriteLine("6. Quit");
            WriteLine("----------------");
        }

        static public void ShowMenu()
        {
            WriteLine("------Show------");
            WriteLine("1. Search Box with ID");
            WriteLine("2. Search Box with Index");
            WriteLine("3. Back to main menu");
            WriteLine("----------------");
        }

        static public void DeleteMenu()
        {
            WriteLine("------Delete------");
            WriteLine("1. Delete Box with ID");
            WriteLine("2. Delete Box with Index");
            WriteLine("3. Back to main menu");
            WriteLine("------------------");
        }

        static public void ChangeMenu()
        {
            WriteLine("------Change------");
            WriteLine("What do you want to change");
            WriteLine("1. ID");
            WriteLine("2. Location");
            WriteLine("3. Height");
            WriteLine("4. Width");
            WriteLine("5. Length");
            WriteLine("6. Back to main menu");
            WriteLine("------------------");
        }
    }
}
