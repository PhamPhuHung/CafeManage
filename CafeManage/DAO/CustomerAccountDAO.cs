using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class CustomerAccountDAO
    {
        #region Initialize Singleton Class

        private static CustomerAccountDAO instance;

        public static CustomerAccountDAO Instance
        {
            get { if (instance == null) instance = new CustomerAccountDAO(); return CustomerAccountDAO.instance; }
            private set => instance = value;
        }

        private CustomerAccountDAO() { }

        #endregion

        #region Methods

        public CustomerAccount GetCustomerAccountByPhoneNum(string phoneNum)
        {
            string query = " EXEC UP_GetCustomerAccount_ByPhoneNum @PhoneNum";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { phoneNum });

            foreach(DataRow row in data.Rows)
            {
                return new CustomerAccount(row);
            }
            return null;
        }

        public bool EnrollNewCustomer(string phoneNum, string name, string address)
        {
            string query = "EXEC UP_EnrollNewCustomer @PhoneNum , @Name , @address";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { phoneNum, name, address }) > 0;
        }

        public bool CustomerInfoModify(string phoneNum, string name, string address)
        {
            string query = "EXEC UP_CustomerInfoModify @PhoneNum , @Name , @address";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { phoneNum, name, address }) > 0;
        }

        public bool ModifyBonusPoint_AfterCheckOut(int used, int get, string phoneNum)
        {
            string query = "EXEC UP_ModifyBonusPoint_AfterCheckOut @used , @get , @phoneNum";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { used, get, phoneNum }) > 0;
        }

        public DataTable GetListCustomerAccount()
        {
            string query = "EXEC UP_GetListCustomer";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        #endregion
    }
}
