using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class IngredientDAO
    {
        #region Initialize Singleton Class

        private static IngredientDAO instance;

        public static IngredientDAO Instance
        {
            get { if (instance == null) instance = new IngredientDAO(); return IngredientDAO.instance; }
            private set => instance = value;
        }

        private IngredientDAO() { }

        #endregion

        #region Methods

        public Ingredient GetIngredient_ByID(int id)
        {
            string query = "EXEC UP_GetIngredient_ByID @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow row in data.Rows)
            {
                return new Ingredient(row);
            }
            return null;
        }
        public bool ModifytIngredientAmount(int idIngredient, float amount)
        {
            string query = "UP_ModifyIngredientAMount @idIngredient , @amount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idIngredient, amount }) > 0;

        }

        public DataTable GetListIngredient()
        {
            string query = "EXEC UP_GetListIngredient";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public List<Ingredient> GetListIngredient(DataTable data)
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            foreach (DataRow row in data.Rows)
            {
                ingredientList.Add(new Ingredient(row));
            }
            return ingredientList;
        }

        public bool AddIngredient(string name, int price, string unit, int alarmAmount)
        {
            string query = "EXEC UP_AddIngredient @name , @price , @unit , @alarmAmount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, price, unit, alarmAmount }) > 0;
        }

        public bool ModifyIngredient(int id, string name, int price, string unit, int amount, int alarmAmount)
        {
            string query = "EXEC UP_ModifyIngredient @id , @name , @price , @unit, @amount , @alarmAmount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, price, unit, amount, alarmAmount }) > 0;
        }

        public bool DeleteIngredient(int id)
        {
            string query = "EXEC UP_DeleteIngredient @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id }) > 0;
        }
        #endregion
    }
}
