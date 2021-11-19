using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class FoodCategoryDAO
    {
        #region Initialize Singleton Class
        private static FoodCategoryDAO instance;

        public static FoodCategoryDAO Instance
        {
            get { if (instance == null) instance = new FoodCategoryDAO(); return FoodCategoryDAO.instance; }
            private set => instance = value;
        }

        private FoodCategoryDAO() { }
        #endregion

        #region Methods

        public List<FoodCategory> GetListFoodCategory()
        {
            List<FoodCategory> categoryList = new List<FoodCategory>();
            string query = "EXEC UP_GetListFoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow row in data.Rows)
            {
                categoryList.Add(new FoodCategory(row));
            }
            return categoryList;
        }
        #endregion
    }
}
