using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class BillInfo
    {
        private int iDFood;
        private int iDBill;
        private int amount;

        public int IDFood { get => iDFood; set => iDFood = value; }
        public int IDBill { get => iDBill; set => iDBill = value; }
        public int Amount { get => amount; set => amount = value; }

        public BillInfo(int idFood, int idBill, int amount)
        {
            this.IDFood = idFood;
            this.IDBill = idBill;
            this.Amount = amount;
        }

        public BillInfo(DataRow row)
        {
            this.IDFood = (int)row["idFood"];
            this.IDBill = (int)row["idBill"];
            this.Amount = (int)row["amount"];
        }
    }
}
