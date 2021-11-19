using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class Bill
    {
        private int iD;
        private DateTime date;
        private int discount;
        private int finalPrice;
        private int iDAccount;
        private string iDCustomer;
        private int iDTable;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Discount { get => discount; set => discount = value; }
        public int FinalPrice { get => finalPrice; set => finalPrice = value; }
        public int IDAccount { get => iDAccount; set => iDAccount = value; }
        public string IDCustomer { get => iDCustomer; set => iDCustomer = value; }
        public int IDTable { get => iDTable; set => iDTable = value; }
        public string Status { get => status; set => status = value; }

        public Bill(int id, DateTime date, int discount, int finalPrice, int idAccount, string idCustomer, int idTable, string status)
        {
            this.ID = id;
            this.Date = date;
            this.Discount = discount;
            this.FinalPrice = finalPrice;
            this.IDAccount = iDAccount;
            this.IDCustomer = idCustomer;
            this.IDTable = idTable;
            this.Status = status;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Date = Convert.ToDateTime(row["date"].ToString());
            this.Discount = (int)row["discount"];
            this.FinalPrice = (int)row["finalPrice"];
            this.IDAccount = (int)row["iDAccount"];
            this.IDCustomer = row["idCustomer"].ToString();
            this.IDTable = (int)row["idTable"];
            this.Status = row["status"].ToString();
        }
    }
}
