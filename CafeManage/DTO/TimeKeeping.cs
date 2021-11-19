using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class TimeKeeping
    {
        private DateTime date;
        private int idAccount;
        private DateTime inTime;
        private DateTime outTime;
        private int substractHour;

        public DateTime Date { get => date; set => date = value; }
        public int IdAccount { get => idAccount; set => idAccount = value; }
        public DateTime InTime { get => inTime; set => inTime = value; }
        public DateTime OutTime { get => outTime; set => outTime = value; }
        public int SubstractHour { get => substractHour; set => substractHour = value; }

        public TimeKeeping(DateTime date, int idAccount, DateTime inTime, DateTime outTime, int subStractHour)
        {
            this.Date = date;
            this.IdAccount = idAccount;
            this.InTime = inTime;
            this.OutTime = outTime;
            this.SubstractHour = subStractHour;
        }

        public TimeKeeping(DataRow row)
        {
            this.Date = Convert.ToDateTime(row["date"].ToString());
            this.IdAccount = (int)row["idAccount"];
            this.InTime = Convert.ToDateTime(row["inTime"].ToString());
            this.OutTime = Convert.ToDateTime(row["outTime"].ToString());
            this.SubstractHour = (int) row["subtractHour"];
        }
    }
}
