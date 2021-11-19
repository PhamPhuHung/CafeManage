using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class FoodDAO
    {
        #region Initialize Singleton Class

        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set => instance = value;
        }
        private FoodDAO() { }

        #endregion

        #region Methods

        public DataTable GetListFood()
        {
            string query = "EXEC UP_GetListFood";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetListFood_ByCategory(string category)
        {
            string query = "EXEC UP_GetListFood_ByCategory @Category";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { category });
        }

        public bool AddFood(string name, string category, int price)
        {
            string query = "EXEC UP_AddFood @name , @category , @price";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name, category, price }) > 0;
        }

        public bool ModifyFood(int id, string name, int price, string category)
        {
            string query = "EXEC UP_ModifyFood @ID , @name , @price , @category";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name, price, category }) > 0;
        }

        public bool DeleteFood(int id)
        {
            string query = "EXEC UP_DeleteFood @ID";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id }) > 0;
        }

        public int GetTopIDFood()
        {
            string query = "EXEC UP_GetTopIDFood";
            DataTable data =  DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                return (int)row[0];
            }
            return (int)0;
        }
        #endregion
    }
}
