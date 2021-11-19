using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class BillDAO
    {

        #region Initialize Singleton Class

        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set => instance = value;
        }

        private BillDAO() { }

        #endregion

        #region  Methods
        public Bill GetUncheckedBill_ByTableID(int idTable)
        {
            string query = "EXEC UP_GetUncheckedBill_ByTableID @idTable";
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExecuteQuery(query, new object[] { idTable });
            foreach (DataRow row in data.Rows)
            {
                return new Bill(row);
            }
            return null;
        }

        public bool InsertBill(int idUser, int idTable)
        {
            string query = "EXEC UP_InsertBill @idUser , @idTable";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idUser, idTable }) > 0;
        }

        public bool AddCustomerToBill(string phoneNum, int idBill)
        {
            string query = "EXEC UP_AddCustomerToBill @phoneNum , @idBill";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { phoneNum, idBill }) > 0;
        }

        public bool CustomerUseBonusForBill(string phoneNum, int idBill, int discount)
        {
            string query = "EXEC UP_CustomerUseBonusForBill @phoneNum , @idBill , @discount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { phoneNum, idBill, discount }) > 0;
        }

        public bool CheckOut(int idBill, int finalPrice)
        {
            string query = "EXEC UP_CheckOut @idBill , @finalPrice";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill, finalPrice }) > 0;
        }
        #endregion
    }
}
