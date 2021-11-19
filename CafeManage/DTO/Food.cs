using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class Food
    {
        private int iD;
        private string name;
        private int price;
        private string category;
        private string currentUsed;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public string CurrentUsed { get => currentUsed; set => currentUsed = value; }

        public Food(int id, string name, int price, string category, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.CurrentUsed = status;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (int)row["price"];
            this.Category = row["category"].ToString();
            this.CurrentUsed = row["status"].ToString();
        }
    }
}
