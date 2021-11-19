using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class BillImportInfoDAO
    {

        #region Initalzie Singleton Class

        private static BillImportInfoDAO instance;

        public static BillImportInfoDAO Instance
        {
            get { if (instance == null) instance = new BillImportInfoDAO(); return BillImportInfoDAO.instance; }
            private set => instance = value;
        }

        private BillImportInfoDAO() { }

        #endregion

        #region Methods
        public bool InsertBillImportInfo(int idBillIm, int idIngredient, int amount, int totalPrice)
        {
            string query = "EXEC UP_Insert_BillImportInfo @idBillIm , @idIngredient , @amount , @totalPrice";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBillIm, idIngredient, amount, totalPrice }) > 0;
        }
        #endregion
    }
}
