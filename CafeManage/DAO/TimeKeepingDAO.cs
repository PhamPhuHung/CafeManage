using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class TimeKeepingDAO
    {

        #region Initialize Singleton Class

        private static TimeKeepingDAO instance;

        public static TimeKeepingDAO Instance
        {
            get { if (instance == null) instance = new TimeKeepingDAO(); return TimeKeepingDAO.instance; }
            private set => instance = value;
        }

        private TimeKeepingDAO() { }

        #endregion

        #region Methods

        public TimeKeeping GetTodayTimeKeepingInfo(int id)
        {
            string query = "EXEC UP_GetTimeKeepingToday_byID @ID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow row in data.Rows)
            {
                TimeKeeping tk = new TimeKeeping(row);
                return tk;
            }
            return null;
        }
        public bool TimeKeepingTodayCheck(int id, DateTime time)
        {
            string query = "EXEC UP_TimeKeepingTodayCheck_ByID @ID , @Time";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, time }) > 0;
        }
        public DataTable GetListTimeKeepingByID(int id)
        {
            string query = "EXEC UP_GetListTimeKeeping_ByID @ID";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public bool Add_ByID_and_Date(int id, DateTime date, DateTime inTime, DateTime outTime, int subtractHour)
        {
            string query = "EXEC UP_TimeKeepingAdd_byIDandDate @id , @date , @inTime , @outTime , @subtractHour";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, date, inTime, outTime, subtractHour }) > 0;
        }
        public bool Modify_ByID_and_Date(int id, DateTime date, DateTime inTime, DateTime outTime, int subtractHour)
        {
            string query = "EXEC UP_TimeKeepingModify_byIDandDate @id , @date , @inTime , @outTime , @subtractHour";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, date, inTime, outTime, subtractHour}) > 0;
        }
        #endregion
    }
}
