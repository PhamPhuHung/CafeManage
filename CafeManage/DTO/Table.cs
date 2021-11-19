using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class Table
    {
        private int iD;
        private string name;
        private string status;
        private string currentUsed;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public string CurrentUsed { get => currentUsed; set => currentUsed = value; }

        public Table(int id, string name, string status, string currentUsed)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.CurrentUsed = currentUsed;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
            this.CurrentUsed = row["currentUsed"].ToString();
        }
    }
}
