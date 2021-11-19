using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage
{
    public class CustomerEvent:EventArgs
    {
        private CustomerAccount customer;

        public CustomerAccount Customer { get => customer; set => customer = value; }

        public CustomerEvent(CustomerAccount customer)
        {
            this.Customer = customer;
        }
    }
}
