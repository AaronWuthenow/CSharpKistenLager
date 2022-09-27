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

            public void updateVolume()
            {
                this.Volume = this.Height * this.Length * this.Width;
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
        static void changeBox(Box inBox, Box[] boxes)
        {
            ChangeMenu:
            Box box = inBox;
            Menu.ChangeMenu();
            int opt = Convert.ToInt32(Console.ReadLine());
            
            switch (opt)
            {
                case 1: // ID
                    Console.WriteLine("Please enter new ID: ");
                    inBox.ID = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2: // Location
                    int temp = inBox.Location;
                    Console.WriteLine("Please enter new Location: ");
                    inBox.Location = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < boxes.Length; i++)
                        if (i == inBox.Location)
                        {
                            boxes[i] = inBox;
                            deleteBox(boxes, temp);
                        }
                    break;
                case 3: // Height
                    Console.WriteLine("Please enter new Height: ");
                    inBox.Height = Convert.ToInt32(Console.ReadLine());
                    inBox.updateVolume();
                    break;
                case 4: // Width
                    Console.WriteLine("Please enter new Width: ");
                    inBox.Width = Convert.ToInt32(Console.ReadLine());
                    inBox.updateVolume();
                    break;
                case 5: // Length
                    Console.WriteLine("Please enter new Length: ");
                    inBox.Length = Convert.ToInt32(Console.ReadLine());
                    inBox.updateVolume();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Nothing selected");
                    goto ChangeMenu;
            }
            return;
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
                            if (i == index)
                                boxes[i] = userBox;
                        break;
                    case 2: // Change box
                        Console.WriteLine("Enter ID of Box");
                        int boxId = Convert.ToInt32(Console.ReadLine());
                        foreach (Box box in boxes)
                            if(box.ID == boxId)
                                changeBox(box, boxes);
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
