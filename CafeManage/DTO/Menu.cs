using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class Menu
    {
        private string name;
        private int price;
        private int amount;
        private int totalPrice;

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Menu(string name, int price, int amount, int totalPrice)
        {
            this.Name = name;
            this.Price = price;
            this.Amount = amount;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.Name = row["name"].ToString();
            this.Price = (int)row["price"];
            this.Amount = (int)row["amount"];
            this.TotalPrice = (int)row["totalPrice"];
        }
    }
}
