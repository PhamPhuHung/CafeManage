using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class BillImportInfo
    {
        private int iDBillIm;
        private int iDIngredient;
        private int amount;
        private int totalPrice;

        public int IDBillIm { get => iDBillIm; set => iDBillIm = value; }
        public int IDIngredient { get => iDIngredient; set => iDIngredient = value; }
        public int Amount { get => amount; set => amount = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }

        public BillImportInfo(int idBillIm, int idIngredient, int amount, int totalPrice)
        {
            this.IDBillIm = idBillIm;
            this.IDIngredient = idIngredient;
            this.Amount = amount;
            this.TotalPrice = totalPrice;
        }
        public BillImportInfo(DataRow row)
        {
            this.IDBillIm = (int)row["idBillIm"];
            this.IDIngredient = (int)row["idIngredient"];
            this.Amount = (int)row["amount"];
            this.TotalPrice = (int)row["totalPrice"];
        }



    }
}
