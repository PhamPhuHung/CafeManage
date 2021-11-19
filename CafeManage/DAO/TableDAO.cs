using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class TableDAO
    {
        #region Initialize Singleton Class
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set => instance = value;
        }

        private TableDAO() { }
        #endregion

        #region Methods

        public List<Table> GetListTable()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = new DataTable();   
            string query = "EXEC UP_GetListTable";
            data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                tableList.Add(new Table(row));
            }
            return tableList;

        }

        public bool AddTable(string name)
        {
            string query = "EXEC UP_AddTable @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { name }) > 0;
        }

        public bool  ModifyTable(int id, string name)
        {
            string query = "EXEC UP_ModifyTable @ID , @name";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, name }) > 0;
        }

        public bool DeleteTable(int id)
        {
            string query = "EXEC UP_DeleteTable @ID";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id }) > 0;
        }
        #endregion
    }
}
