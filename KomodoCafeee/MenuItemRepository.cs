using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeee
{
    public class MenuItemRepository
    {
        private List<MenuItem> _listofFood = new List<MenuItem>();

        //Create
        public void AddItemToList(MenuItem item)
        {
            _listofFood.Add(item);
        }

        //Read
        public List<MenuItem> GetFoodList()
        {
            return _listofFood;
        }

        //Update
        public bool UpdateExistingMenu(string originalItem, MenuItem newItem)
        {
            //Find the Content
            MenuItem oldItem = GetContentByNumber(originalItem);

            //Update the Content
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.MealPrice = newItem.MealPrice;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.MealIngredients = newItem.MealIngredients;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool RemoveItemFromList(string mealNumber)
        {
            MenuItem item = GetContentByNumber(mealNumber);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listofFood.Count;
            _listofFood.Remove(item);

            if (initialCount > _listofFood.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public MenuItem GetContentByNumber(string mealNumber)
        {
            foreach (MenuItem item in _listofFood)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }

            }
            return null;
        }

        public MenuItem GetContentByName(string mealName)
        {
            foreach (MenuItem item in _listofFood)
            {
                if (item.MealName == mealName)
                {
                    return item;
                }

            }
            return null;
        }
    }
}
