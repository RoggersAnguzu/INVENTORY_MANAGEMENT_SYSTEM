using System;
namespace Program
{
    struct Inventory
    {
        public double quantity;
        public double price;
        public string name;
        public double amount;
    }
    public class InventorySystem
    {
        static Inventory[] invent = new Inventory[1000];
        static int itemCount = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO RANGUZU_INVENTORY_SYSTEM\n");
            Console.WriteLine("Please Enter your name before using Our Services:\n");
            string Sname = Console.ReadLine();
            Console.WriteLine($"Dear {Sname}\nYou have successfully logged into the system");
            Master();
        }
        static void Master()
        {
            Console.WriteLine("The following are the operations to be carried out \n\n1. Add Products to the system\n2. Display items in the System\n3. Remove items ");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Remove();
                    break;
                default:
                    Console.WriteLine("Please Enter the Right Number from the above options");
                    break;
            }
        }
        static void Add()
        { 
            Console.WriteLine("Enter the number of items to be added: ");
            int x = int.Parse(Console.ReadLine());

            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("Enter Product Name: ");
                invent[i].name = Console.ReadLine();

                Console.WriteLine("Enter the Product quantity: ");
                invent[i].quantity = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the unit Price: ");
                invent[i].price = double.Parse(Console.ReadLine());

                invent[i].amount = invent[i].price * invent[i].quantity;
                itemCount ++;
            }
            Console.WriteLine("The items have been Successfully added in to the system");
            Exit();
        }
        static void Display()
        {
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine("The following are the items that have been added into the system.");
                Console.WriteLine($"{invent[i].name} {invent[i].quantity} {invent[i].price} {invent[i].amount}");
                Console.WriteLine();
            }
            Exit();
        }
        static void Exit()
        {
            try
            {
                Console.WriteLine("Would you like to exit?\n1. No\n2. Yes ");
                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        Master();
                        break;
                    case 2:
                        Console.WriteLine("Thanks for Using Our System");
                        break;
                    default:
                        Console.WriteLine("Enter the right option");
                        Exit();
                        break;
                }
            } catch (FormatException) { Console.WriteLine("Enter the Correct format"); }  
        }
        static void Remove()
        {
            Console.WriteLine("Enter the item name to be removed: ");
            string itemToBeRemoved = Console.ReadLine().ToLower();

            int itemIndex = -1; 
            for (int i = 0; i < itemCount; i++)
            {
                if (invent[i].name.ToLower() == itemToBeRemoved)
                {
                    itemIndex = i;
                    break;
                }
            }

            if (itemIndex != -1)
            {
                for (int i = itemIndex; i < itemCount - 1; i++)
                {
                    invent[i] = invent[i + 1];
                }

                itemCount--; 
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }

            Exit();
        }

    }
}