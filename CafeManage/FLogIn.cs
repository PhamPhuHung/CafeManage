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
    public partial class FLogIn : Form
    {
        public FLogIn()
        {
            InitializeComponent();
        }

        #region Methods
        private bool LogInSuccess(string ID, string password)
        {
            return UserAccountDAO.Instance.LogInSuccess(ID, password);
        }
        #endregion

        #region Events
        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlr == DialogResult.No) e.Cancel = true;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (LogInSuccess(tbID.Text, tbPassword.Text))
            {
                UserAccount logInAccount = UserAccountDAO.Instance.GetUserByID(tbID.Text);
                FMain fMain = new FMain(logInAccount);
                this.Hide();
                fMain.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Mã nhân viên hoặc mật khẩu không đúng. Vui lòng nhập lại!",
                "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
