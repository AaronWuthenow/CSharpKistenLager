using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagersystem
{
    internal class Program
    {
        struct Box
        {
            public int ID;
            public int Height;
            public int Width;
            public int Length;
            public int Volume;

            public Box(int boxID, int boxHeight, int boxWidth, int boxLength)
            {
                this.ID = boxID;
                this.Height = boxHeight;
                this.Width = boxWidth;
                this.Length = boxLength;
                this.Volume = this.Width * this.Height * this.Length;
            }
        };

        static void showBox(Box inBox)
        {
            Console.Write($"\nID: {inBox.ID}\n" +
                          $"Height: {inBox.Height}\n" +
                          $"Width: {inBox.Width}\n" +
                          $"Lenght: {inBox.Length}\n" +
                          $"Volume: {inBox.Volume}\n"
                          );
        }

        static Box createBox()
        {
            int boxID, boxHeight, boxWidth, boxLenght;
            Console.WriteLine("Please enter the Box ID: ");
            boxID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Box Height: ");
            boxHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Box Width: ");
            boxWidth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Box Lenght: ");
            boxLenght = Convert.ToInt32(Console.ReadLine());
            
            Box myBox = new Box(boxID, boxHeight, boxWidth, boxLenght);

            showBox(myBox);
            
            return myBox;
        }

        static void Menu()
        {
            Console.WriteLine("1. Create a Box");
            Console.WriteLine("2. Change a Box");
            Console.WriteLine("3. Delete a Box");
            Console.WriteLine("4. Show a Box");
            Console.WriteLine("5. Show all Boxes");
            Console.WriteLine("6. Quit");
        }

        static void Main(string[] args)
        {
            int opt, index;
            bool stop = false;
            Box[] boxes = new Box[75];

            Menu();
            opt = Convert.ToInt32(Console.ReadLine());
            
            while (!stop)
            {
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Where should the Box be stored: ");
                        index = Convert.ToInt32(Console.Read());
                        createBox();
                        // TODO: Add Box to Array
                        break;
                    case 4:
                        // TODO: Show the Box.
                    case 6:
                        stop = true;
                        break;
                }
            }

            Box myBox = createBox();

            Console.ReadKey();
        }
    }
}
