using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class MenuDAO
    {
        #region Initialize Singleton Class

        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set => instance = value; 
        }
        private MenuDAO() { }

        #endregion

        #region Methods

        public List<Menu> GetListMenu_ByBillID(int idBill)
        {
            List<Menu> menuList = new List<Menu>();
            string query = "EXEC UP_GetListMenu_ByIDBill @idBill";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBill });
            foreach (DataRow row in data.Rows)
            {
                menuList.Add(new Menu(row));
            }
            return menuList;
        }
        #endregion

    }
}
