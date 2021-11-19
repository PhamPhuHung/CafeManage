using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class BillImport
    {
        private int iD;
        private DateTime date;
        private int discount;
        private int finalPrice;
        private string status;

        public int ID { get => iD; set => iD = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Discount { get => discount; set => discount = value; }
        public int FinalPrice { get => finalPrice; set => finalPrice = value; }
        public string Status { get => status; set => status = value; }

        public BillImport(int id, DateTime date, int discount, int finalPrice, string status)
        {
            this.ID = id;
            this.Date = date;
            this.Discount = discount;
            this.FinalPrice = finalPrice;
            this.Status = status;
        }

        public BillImport(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Date = Convert.ToDateTime(row["date"].ToString());
            this.Discount = (int)row["discount"];
            this.FinalPrice = (int)row["finalPrice"];
            this.Status = row["status"].ToString() ;
        }
    }
}
