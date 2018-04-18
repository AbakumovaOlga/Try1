using SweetShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShopService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Baker> Bakers { get; set; }

        public List<Request> Requests { get; set; }

        public List<Cake> Cakes { get; set; }

        public List<CakeIngredient> CakeIngredients { get; set; }

        public List<Fridge> Fridges { get; set; }

        public List<FridgeIngredient> FridgeIngredients { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Ingredients = new List<Ingredient>();
            Bakers = new List<Baker>();
            Requests = new List<Request>();
            Cakes = new List<Cake>();
            CakeIngredients = new List<CakeIngredient>();
            Fridges = new List<Fridge>();
            FridgeIngredients = new List<FridgeIngredient>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}
