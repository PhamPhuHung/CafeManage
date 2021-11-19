using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class IngredientInfo
    {
        private int idFood;
        private int idIngredient;
        private float amount;

        public int IdFood { get => idFood; set => idFood = value; }
        public int IdIngredient { get => idIngredient; set => idIngredient = value; }
        public float Amount { get => amount; set => amount = value; }

        public IngredientInfo(int idFood, int idIngredient, float Amount)
        {
            this.IdFood = idFood;
            this.IdIngredient = IdIngredient;
            this.Amount = amount;
        }

        public IngredientInfo(DataRow row)
        {
            this.IdFood = (int)row["idFood"];
            this.IdIngredient = (int)row["IdIngredient"];
            this.Amount = (float)Convert.ToDouble(row["amount"].ToString());
        }
    }
}
