using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeee
{
    public class ProgramUI
        
    {
        private MenuItemRepository _menuItemRepo = new MenuItemRepository();

        public void Run()
        {
            SeedContentList();
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                System.Console.WriteLine("What would you like to do?" +
                    "\n1. Read Menu" +
                    "\n2. Create a Menu Item" +
                    "\n3. Delete a Menu Item" +
                    "\n4. Exit Program");
                string userResponse = System.Console.ReadLine();

                switch (userResponse)
                {
                    case "1":
                        ViewMenu();
                        break;

                    case "2":
                        CreateMenuItem();
                        break;

                    case "3":
                        DeleteMenuItem();
                        break;

                    case "4":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create menu item
        private void CreateMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            Console.WriteLine("Enter a name for the new menu item:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter a number for the new menu item:");
            newItem.MealNumber = Console.ReadLine();

            Console.WriteLine("Enter a description for the new menu item:");
            newItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter the ingredients for the new menu item:");
            newItem.MealIngredients = Console.ReadLine();

            Console.WriteLine("Enter the price for the new menu item:");
            newItem.MealPrice = Console.ReadLine();

            _menuItemRepo.AddItemToList(newItem);
            Console.ReadLine();


        }
        //View menu item
        private void ViewMenu()
        {
            List<MenuItem> listOfMenuItems = _menuItemRepo.GetFoodList();

            Console.Clear();
            Console.WriteLine("Menu Items: ");
            foreach (MenuItem item in listOfMenuItems)
            {
                
                Console.WriteLine("____________________________________________");
                Console.WriteLine($"Number: {item.MealNumber}, Title: { item.MealName},Description: { item.MealDescription},Price: { item.MealPrice}");
                
            }
        }

        
        //Delete menu item
        private void DeleteMenuItem()
        {
            Console.Clear();

            ViewMenu();

            Console.WriteLine("What menu item would you like to delete? (enter a number)");
            string number = Console.ReadLine();

            bool deleted = _menuItemRepo.RemoveItemFromList(number);

            if(deleted)
            {
                Console.WriteLine("______________________________");
                Console.WriteLine("Item was deleted");
            }
            else
            {
                Console.WriteLine("The content could not be deleted");
            }
        }

        //Seed method
        private void SeedContentList()
        {
            MenuItem BigMac = new MenuItem("1", "Big Mac", "Double Patty Goodness", "Two Beef Pattys, Special Sauce, Cheese, Lettuce, Ketchup", "$5.99");
            MenuItem Nuggets = new MenuItem("2", "10pc Nuggets", "Crispy Spicy Nuggets", "White Meat Chicken", "5.99");

            _menuItemRepo.AddItemToList(BigMac);
            _menuItemRepo.AddItemToList(Nuggets);
        }



    }
}
