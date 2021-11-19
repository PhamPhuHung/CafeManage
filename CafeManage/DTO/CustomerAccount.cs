using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DTO
{
    public class CustomerAccount
    {
        private string phoneNum;
        private string name;
        private string address;
        private DateTime lastBuyDate;
        private int bonusPoint;

        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public DateTime LastBuyDate { get => lastBuyDate; set => lastBuyDate = value; }
        public int BonusPoint { get => bonusPoint; set => bonusPoint = value; }

        public CustomerAccount(string PhoneNum, string name, string address, DateTime lastBuyDate, int bonusPoint)
        {
            this.PhoneNum = phoneNum;
            this.Name = name;
            this.Address = address;
            this.LastBuyDate = lastBuyDate;
            this.BonusPoint = bonusPoint;
        }

        public CustomerAccount(DataRow row)
        {
            this.PhoneNum = row["phoneNum"].ToString() ;
            this.Name = row["name"].ToString();
            this.Address = row["address"].ToString();
            this.LastBuyDate = (DateTime)row["lastBuyDate"];
            this.BonusPoint = (int)row["bonusPoint"];
        }
    }
}
