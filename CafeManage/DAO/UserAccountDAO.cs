using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class UserAccountDAO
    {
        #region Initialize Singleton Class
        private static UserAccountDAO instance;

        public static UserAccountDAO Instance
        {
            get { if (instance == null) instance = new UserAccountDAO(); return UserAccountDAO.instance; }
            private set => instance = value;
        }

        private UserAccountDAO() { }
        #endregion

        #region Methods
        private string PasswordEncoding(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";
            foreach(byte item in hasData)
            {
                hasPass += item;
            }
            hasPass.Reverse();
            return hasPass;
        }
        public bool LogInSuccess(string ID, string password)
        {
            DataTable data = new DataTable();
            string query = "EXEC UP_LogIn @ID , @password ";
            data = DataProvider.Instance.ExecuteQuery(query, new object[] { ID, PasswordEncoding(password)});
            return data.Rows.Count > 0;
        }

        public UserAccount GetUserByID(string ID)
        {
            DataTable data = new DataTable();
            string query = "EXEC UP_GetAccountByID @ID";
            data = DataProvider.Instance.ExecuteQuery(query, new object[] { ID });
            foreach(DataRow row in data.Rows)
            {
                return new UserAccount(row);
            }
            return null;
        }

        public bool UpdateAccount(int ID, string displayName, string pass, string newPass)
        {
            string query = "EXEC UP_AccountUPdate @ID , @displayName , @pass , @newPass";
            pass = PasswordEncoding(pass);
            newPass = PasswordEncoding(newPass);
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { ID, displayName, pass, newPass }) > 0;
        }

        public DataTable GetListUser()
        {
            string query = "EXEC UP_GetListUser";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool AddNewUser(string displayName, string salary, string type)
        {
            string query = "EXEC UP_AddNewUser @displayName , @salary , @type";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { displayName, salary, type }) > 0;
        }
        public bool ModifyUser(int id, string displayName, string status, int salary, string type)
        {
            string query = "UP_ModifyUser @id , @displayName , @status , @salary , @type ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {id , displayName, status, salary, type }) > 0;
        }

        public bool ResetUserPass(int id)
        {
            string query = "EXEC UP_ResetUserPass @ID";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id }) > 0;
        }
        public bool DeleteUser(int id)
        {
            string query = "EXEC UP_DeleteUser @ID";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id }) > 0;
        }
        #endregion
    }
}
