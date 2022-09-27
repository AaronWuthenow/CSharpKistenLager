using System;

namespace Lagersystem
{
    internal static class Program
    {
        private static void ShowBox(Box inBox)
        {
            Console.Write($"\nID: {inBox.ID}\n" +
                          $"Height: {inBox.Height}\n" +
                          $"Width: {inBox.Width}\n" +
                          $"Lenght: {inBox.Length}\n" +
                          $"Volume: {inBox.Volume}\n" +
                          $"Location: {inBox.Location}\n"
            );
        }

        private static Box CreateBox(int location)
        {
            Console.WriteLine("Please enter the Box ID: ");
            var boxId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Box Height: ");
            var boxHeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Box Width: ");
            var boxWidth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Box Lenght: ");
            var boxLenght = Convert.ToInt32(Console.ReadLine());

            var myBox = new Box(boxId, boxHeight, boxWidth, boxLenght, location);

            ShowBox(myBox);

            return myBox;
        }

        private static void DeleteBox(Box[] boxArray, int location)
        {
            boxArray[location] = new Box();
        }

        private static void ChangeBox(Box inBox, Box[] boxes)
        {
            ChangeMenu:
            Menu.ChangeMenu();
            var opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1: // ID
                    Console.WriteLine("Please enter new ID: ");
                    inBox.ID = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2: // Location
                    var temp = inBox.Location;
                    Console.WriteLine("Please enter new Location: ");
                    inBox.Location = Convert.ToInt32(Console.ReadLine());
                    for (var i = 0; i < boxes.Length; i++)
                        if (i == inBox.Location)
                        {
                            boxes[i] = inBox;
                            DeleteBox(boxes, temp);
                        }

                    break;
                case 3: // Height
                    Console.WriteLine("Please enter new Height: ");
                    inBox.Height = Convert.ToInt32(Console.ReadLine());
                    inBox.UpdateVolume();
                    break;
                case 4: // Width
                    Console.WriteLine("Please enter new Width: ");
                    inBox.Width = Convert.ToInt32(Console.ReadLine());
                    inBox.UpdateVolume();
                    break;
                case 5: // Length
                    Console.WriteLine("Please enter new Length: ");
                    inBox.Length = Convert.ToInt32(Console.ReadLine());
                    inBox.UpdateVolume();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Nothing selected");
                    goto ChangeMenu;
            }
        }

        private static void Main()
        {
            var stop = false;
            var boxes = new Box[75];
            for (var i = 0; i < boxes.Length; i++) boxes[i] = new Box(0, i);
            MainMenu:
            while (!stop)
            {
                Menu.MainMenu();
                var opt = Convert.ToInt32(Console.ReadLine());
                int index;
                switch (opt)
                {
                    case 1: // Create box
                        Console.WriteLine("Where should the Box be stored: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        var userBox = CreateBox(index);
                        for (var i = 0; i < boxes.Length; i++)
                            if (i == index)
                                boxes[i] = userBox;
                        break;
                    case 2: // Change box
                        Console.WriteLine("Enter ID of Box");
                        var boxId = Convert.ToInt32(Console.ReadLine());
                        foreach (var box in boxes)
                            if (box.ID == boxId)
                                ChangeBox(box, boxes);
                        break;
                    case 3: // Delete box
                        DeleteMenu:
                        Menu.DeleteMenu();
                        opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1: // Delete with ID
                                Console.WriteLine("Please enter the Box ID");
                                var id = Convert.ToInt32(Console.ReadLine());
                                foreach (var box in boxes)
                                    if (box.ID == id)
                                    {
                                        DeleteBox(boxes, box.Location);
                                        ShowBox(box);
                                    }

                                Console.WriteLine("Box deleted");
                                goto DeleteMenu;
                            case 2: // TODO: Delete with Index 
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
                                var id = Convert.ToInt32(Console.ReadLine());
                                foreach (var box in boxes)
                                    if (box.ID == id)
                                        ShowBox(box);
                                goto ShowMenu;
                            case 2:
                                Console.WriteLine("Where are we looking (location): ");
                                index = Convert.ToInt32(Console.ReadLine());
                                for (var i = 0; i < boxes.Length; i++)
                                    if (i == index)
                                        ShowBox(boxes[i]);
                                goto ShowMenu;
                            case 3:
                                goto MainMenu;
                        }

                        break;
                    case 5: // show all boxes
                        foreach (var box in boxes)
                            if (box.ID == 0)
                            {
                            }
                            else
                            {
                                ShowBox(box);
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

        private struct Box
        {
            public int ID;
            public int Height;
            public int Width;
            public int Length;
            public int Volume;
            public int Location;

            public Box(int boxID, int boxHeight, int boxWidth, int boxLength, int location)
            {
                ID = boxID;
                Height = boxHeight;
                Width = boxWidth;
                Length = boxLength;
                Volume = Width * Height * Length;
                Location = location;
            }

            public Box(int boxID = 0, int location = 0)
            {
                ID = boxID;
                Height = 0;
                Width = 0;
                Length = 0;
                Volume = 0;
                Location = location;
            }

            public void UpdateVolume()
            {
                Volume = Height * Length * Width;
            }
        }
    }
}