using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class FoodCategory
    {
        private string name;

        public string Name { get => name; set => name = value; }

        public FoodCategory(string name)
        {
            this.Name = name;
        }
        public FoodCategory(DataRow row)
        {
            this.Name = row["category"].ToString();
        }
    }
}
