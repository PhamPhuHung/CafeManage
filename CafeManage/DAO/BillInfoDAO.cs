using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class BillInfoDAO
    {

        #region Initialize Singleton Class

        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set => instance = value;
        }

        private BillInfoDAO() { }

        #endregion

        #region Methods

        public bool InsertBillInfo(int idFood, int idBill, int amount)
        {
            string query = "EXEC UP_InsertBillInfo @idFood , @idBill , @amount";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idFood, idBill, amount })> 0;
        }
        public bool DeleteBillInfo(int idBill, int idFood)
        {
            string query = "EXEC dbo.UP_DeleteBillInfo @idFood , @idBill ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idFood, idBill  }) > 0;
        }
        #endregion

    }
}
