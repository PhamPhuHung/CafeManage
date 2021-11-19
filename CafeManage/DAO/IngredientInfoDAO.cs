using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    class IngredientInfoDAO
    {
        #region Initialize Singleton Class

        private static IngredientInfoDAO instance;

        internal static IngredientInfoDAO Instance
        {
            get { if (instance == null) instance = new IngredientInfoDAO(); return IngredientInfoDAO.instance; }
            private set => instance = value;
        }

        private IngredientInfoDAO() { }

        #endregion

        #region Methods
        public List<IngredientInfo> GetIngredientInfoList_ByIDFood(int idFood)
        {
            List<IngredientInfo> ingredientInfoList = new List<IngredientInfo>();
            string query = "EXEC UP_GetIngredientInfoList_byIDFood @idFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idFood });
            foreach (DataRow row in data.Rows)
            {
                ingredientInfoList.Add(new IngredientInfo(row));
            }
            return ingredientInfoList;
        }

        public DataTable GetIngredientInfoList_ByIDFood_Advance(int idFood)
        {
            string query = "EXEC UP_GetIngredientInfoList_ByIDFood_Advance @idFood";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idFood });
        }

        public bool DeleteIngredientInfoList(int idFood)
        {
            string query = "EXEC UP_DeleteIngredientInfoList @idFood";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idFood }) > 0;
        }

        public bool AddIngredientInfo(int idFood, int idIngredient, float amount)
        {
            string query = "EXEC UP_AddIngredientInfo @idFood , @idIngredient , @amount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idFood, idIngredient, amount }) > 0;
        }
        #endregion
    }
}
