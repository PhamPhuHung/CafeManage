using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class UserAccount
    {
        private int iD;
        private string displayName;
        private string password;
        private string status;
        private int salary;
        private string type;

        public int ID { get => iD; set => iD = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
        public string Status { get => status; set => status = value; }
        public int Salary { get => salary; set => salary = value; }
        public string Type { get => type; set => type = value; }

        public UserAccount(int id, string displayName, string password, string status, int salary, string type )
        {
            this.ID = id;
            this.DisplayName = displayName;
            this.Password = password;
            this.Status = status;
            this.Salary = salary;
            this.Type = type;
        }

        public UserAccount(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DisplayName = row["displayName"].ToString();
            this.Password = row["password"].ToString(); 
            this.Status = row["status"].ToString();
            try { this.Salary = (int)row["salary"]; } catch { }
            this.Type = row["type"].ToString();
        }
    }
}
