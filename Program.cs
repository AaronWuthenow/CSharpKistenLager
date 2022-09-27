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
            public int Location;

            public Box(int boxID, int boxHeight, int boxWidth, int boxLength, int location)
            {
                this.ID = boxID;
                this.Height = boxHeight;
                this.Width = boxWidth;
                this.Length = boxLength;
                this.Volume = this.Width * this.Height * this.Length;
                this.Location = location;
            }
            public Box(int boxID = 0, int location = 0)
            {
                this.ID = boxID;
                this.Height = 0;
                this.Width = 0;
                this.Length = 0;
                this.Volume = 0;
                this.Location = location;
            }
        };

        static void showBox(Box inBox)
        {
            Console.Write($"\nID: {inBox.ID}\n"       +
                          $"Height: {inBox.Height}\n" +
                          $"Width: {inBox.Width}\n"   +
                          $"Lenght: {inBox.Length}\n" +
                          $"Volume: {inBox.Volume}\n" +
                          $"Location: {inBox.Location}\n"
                          );
        }

        static Box createBox(int location)
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
            
            Box myBox = new Box(boxID, boxHeight, boxWidth, boxLenght, location);

            showBox(myBox);
            
            return myBox;
        }

        static void deleteBox(Box[] boxArray, int location)
        {
            boxArray[location] = new Box();
        }

        static void Main(string[] args)
        {
            int opt, index;
            bool stop = false;
            Box[] boxes = new Box[75];
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new Box(0, i);
            }
            MainMenu:
            while (!stop)
            {
                Menu.MainMenu();
                opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1: // Create box
                        Console.WriteLine("Where should the Box be stored: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        Box userBox = createBox(index);
                        for (int i = 0; i < boxes.Length; i++)
                        {
                            if (i == index)
                                boxes[i] = userBox;
                        }
                        break;
                    case 3: // Delete box
                        DeleteMenu:
                        Menu.DeleteMenu();
                        opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1: // Delete with ID
                                Console.WriteLine("Please enter the Box ID");
                                int id = Convert.ToInt32(Console.ReadLine());
                                foreach (Box box in boxes)
                                    if (box.ID == id)
                                    {
                                        deleteBox(boxes, box.Location);
                                        showBox(box);
                                    }
                                Console.WriteLine("Box deleted");
                                goto DeleteMenu;
                            case 2: // Delete with Index
                                goto DeleteMenu;
                            case 3:
                                goto MainMenu;
                        }
                        break;
                    case 4: // show box
                        ShowMenu:
                        Menu.ShowMenu();
                        opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Which box to show (ID): ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                foreach (Box box in boxes)
                                {
                                    if (box.ID == id)
                                    {
                                        showBox(box);
                                    }
                                }
                                goto ShowMenu;
                            case 2:
                                Console.WriteLine("Where are we looking (location): ");
                                index = Convert.ToInt32(Console.ReadLine());
                                for (int i = 0; i < boxes.Length; i++)
                                {
                                    if (i == index)
                                    {
                                        showBox(boxes[i]);
                                    }
                                }
                                goto ShowMenu;
                            case 3:
                                goto MainMenu;
                        }
                        break;
                    case 5: // show all boxes
                        foreach (Box box in boxes)
                        {
                            showBox(box);
                        }
                        Console.WriteLine("\nPress any Key to Continue...");
                        Console.ReadKey();
                        break;
                    case 6:
                        stop = true;
                        break;
                }
            }
        }
    }
}
