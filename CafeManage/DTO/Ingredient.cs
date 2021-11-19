using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class Ingredient
    {
        private int iD;
        private string name;
        private int price;
        private string unit;
        private float amount;
        private int alarmAmount;
        private string currentUsed;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public string Unit { get => unit; set => unit = value; }
        public float Amount { get => amount; set => amount = value; }
        public int AlarmAmount { get => alarmAmount; set => alarmAmount = value; }
        public string CurrentUsed { get => currentUsed; set => currentUsed = value; }

        public Ingredient(int id, string name, int price, string unit, float amount, int alarmAMount, string status)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Unit = unit;
            this.Amount = amount;
            this.AlarmAmount = alarmAMount;
            this.CurrentUsed = status;
        }

        public Ingredient(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (int)row["price"];
            this.Unit = row["unit"].ToString();
            this.Amount = (float)Convert.ToDouble(row["amount"].ToString());
            this.AlarmAmount = (int)row["alarmAMount"];
            this.CurrentUsed = row["CurrentUsed"].ToString();
        }
    }
}
