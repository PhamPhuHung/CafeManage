using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class BillImportDAO
    {
        #region Initialzie Singleton Class

        private static BillImportDAO instance;

        public static BillImportDAO Instance
        {
            get { if (instance == null) instance = new BillImportDAO(); return BillImportDAO.instance; }
            private set => instance = value;
        }

        private BillImportDAO() { }

        #endregion

        #region Methods
        public bool InsertBillImport(int idUser)
        {
            string query = "EXEC UP_InsertBillImport @idUser ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idUser }) > 0;
        }
        public BillImport GetUncheckedBillImport()
        {
            string query = "EXEC UP_GetUncheckedBillImport";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                return new BillImport(row);
            }
            return null;
        }
        public bool BillImportCheckOut(int id, int finalPrice, int discount)
        {
            string query = "EXEC UP_BillImportCheckOut @id , @finalPrice , @discount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, finalPrice, discount }) > 0;
        }
        #endregion
    }
}
