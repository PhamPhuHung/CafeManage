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
    public partial class FUserProfile : Form
    {
        private UserAccount logInAccount;

        public UserAccount LogInAccount
        {
            get => logInAccount;
            set { logInAccount = value; ChangeAccount(); LoadTimeKeeping(); }
        }
        TimeKeeping tk;
        public FUserProfile(UserAccount logInAccount)
        {
            InitializeComponent();
            this.LogInAccount = logInAccount;
        }

        private void ChangeAccount()
        {
            tbID.Text = LogInAccount.ID.ToString() ;
            tbName.Text = LogInAccount.DisplayName;
        }
        private void LoadTimeKeeping()
        {
            try
            {
                tk = TimeKeepingDAO.Instance.GetTodayTimeKeepingInfo(LogInAccount.ID);
                tbInTime.Text = tk.InTime.ToLongTimeString();
                tbOutTime.Text = tk.OutTime.ToLongTimeString();
            }
            catch { }

        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string newPass = "";
            if(!string.IsNullOrWhiteSpace(tbNewPass.Text))
            {
                if (tbNewPass.Text != tbReEnterNewPass.Text)
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau. Vui lòng nhập lại!", "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else newPass = tbNewPass.Text;
            }

            if (UserAccountDAO.Instance.UpdateAccount(LogInAccount.ID, tbName.Text, tbPass.Text, newPass))
            {
                MessageBox.Show("Cập nhật thông tin thành công");
            }
            else MessageBox.Show("Mật khẩu không đúng. Vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTimeKeeping_Click(object sender, EventArgs e)
        {
            TimeKeepingDAO.Instance.TimeKeepingTodayCheck(LogInAccount.ID, DateTime.Now);
            LoadTimeKeeping();
        }
    }
}
