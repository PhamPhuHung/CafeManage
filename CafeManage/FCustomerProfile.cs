using CafeManage.DAO;
using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManage
{
    public partial class FCustomerProfile : Form
    {
        #region Initialize
        CustomerAccount customer = null;
        public FCustomerProfile()
        {
            InitializeComponent();
        }

        private event EventHandler<CustomerEvent> addCustomerToBill;
        public event EventHandler<CustomerEvent> AddCustomerToBill
        {
            add { addCustomerToBill += value; }
            remove { addCustomerToBill -= value; }
        }
        #endregion

        #region Events
        private void btSearch_Click(object sender, EventArgs e)
        {
            customer = CustomerAccountDAO.Instance.GetCustomerAccountByPhoneNum(tbPhoneNum.Text);
            if (customer == null)
            {
                MessageBox.Show("Số điện thoại này không tồn tại trong hệ thống");
                return;
            }
            tbName.Text = customer.Name;
            tbAddress.Text = customer.Address;
            tbBonusPoint.Text = customer.BonusPoint.ToString();
        }

        private void btEnroll_Click(object sender, EventArgs e)
        {
            if(!tbPhoneNum.Text.All(char.IsDigit))
            {
                MessageBox.Show("Chỉ được nhập số vào mục số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CustomerAccountDAO.Instance.EnrollNewCustomer(tbPhoneNum.Text, tbName.Text, tbAddress.Text))
            {
                MessageBox.Show("Đăng ký khách hàng mới thành công");
                customer = CustomerAccountDAO.Instance.GetCustomerAccountByPhoneNum(tbPhoneNum.Text);
            }
            else MessageBox.Show("Tài khoản đã tồn tại. Số điện thoại " + tbPhoneNum.Text + " đã tồn tại");

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (CustomerAccountDAO.Instance.CustomerInfoModify(tbPhoneNum.Text, tbName.Text, tbAddress.Text))
            {
                MessageBox.Show("Cập nhật tài khoản khách hàng thành công");
                customer = CustomerAccountDAO.Instance.GetCustomerAccountByPhoneNum(tbPhoneNum.Text);
            }
            else MessageBox.Show("Không thể cập nhật. Số điện thoại " + tbPhoneNum.Text + " không tồn tại");
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAddToBill_Click(object sender, EventArgs e)
        {
            if (addCustomerToBill != null) addCustomerToBill(this, new CustomerEvent(customer));
        }
        #endregion
    }
}
