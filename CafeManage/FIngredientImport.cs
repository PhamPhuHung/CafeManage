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
    public partial class FIngredientImport : Form
    {
        Ingredient ingredient;

        private UserAccount logInAccount;

        public UserAccount LogInAccount { get => logInAccount; set => logInAccount = value; }

        public FIngredientImport(UserAccount logInAccount)
        {
            InitializeComponent();
            this.LogInAccount = logInAccount;
        }
        #region Methods
        private bool GetIngredient(int id)
        {
            ingredient = IngredientDAO.Instance.GetIngredient_ByID(id);
            if (ingredient == null) return false;
            return true;
        }

        private void ShowIngredient(Ingredient ingredient)
        {
            lbIngredientName.Text = ingredient.Name;
            lbIngredientPrice.Text = ingredient.Price.ToString();
            lbIngredientAmount.Text = ingredient.Amount.ToString();
            lbIngredientUnit.Text = ingredient.Unit;
        }

        private void AddIngredient(Ingredient ingredient, int amount)
        {
            foreach(ListViewItem item in lvBill.Items)
            {
                if (item.Text == ingredient.ID.ToString())
                {
                    amount += Convert.ToInt32(item.SubItems[3].Text);
                    item.SubItems[3].Text = amount.ToString();
                    item.SubItems[4].Text = (amount * ingredient.Price).ToString();
                    return;
                }
            }
            ListViewItem lvItem = new ListViewItem(ingredient.ID.ToString());
            lvItem.SubItems.Add(ingredient.Name);
            lvItem.SubItems.Add(ingredient.Price.ToString());
            lvItem.SubItems.Add(amount.ToString());
            lvItem.SubItems.Add((amount *ingredient.Price).ToString());

            lvBill.Items.Add(lvItem);
        }

        private void ImportIngredient(int id, float amount)
        {
           

        }
        #endregion

        #region Events
        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbIngredientID.Text);
                if(GetIngredient(id)) ShowIngredient(ingredient);
            }
            catch
            {
                MessageBox.Show("Mã nguyên liệu không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            if (lvBill.Items.Count == 0) return;
            try
            {
                BillImportDAO.Instance.InsertBillImport(LogInAccount.ID);

                BillImport billImport = BillImportDAO.Instance.GetUncheckedBillImport();
                int idBillIm = billImport.ID;
                int finalPrice = 0;
                foreach (ListViewItem item in lvBill.Items)
                {
                    int idIngredient = Convert.ToInt32(item.SubItems[0].Text.ToString());
                    int amount = Convert.ToInt32(item.SubItems[3].Text.ToString());
                    int totalPrice = Convert.ToInt32(item.SubItems[4].Text.ToString());

                    BillImportInfoDAO.Instance.InsertBillImportInfo(idBillIm, idIngredient, amount, totalPrice);
                    IngredientDAO.Instance.ModifytIngredientAmount(idIngredient, amount);

                    finalPrice += totalPrice;
                }
                BillImportDAO.Instance.BillImportCheckOut(idBillIm, finalPrice, 0);
                MessageBox.Show("Nhập kho thành công. Tổng tiền thanh toán: " + finalPrice.ToString("c"));
                lvBill.Items.Clear();
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu kho. Vui lòng kiểm tra lại mã nguyên liệu và số lượng nhập kho", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAddIngredient_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(nmIngredientImport.Value);
            if (amount == 0) return;

            int id = Convert.ToInt32(tbIngredientID.Text);
            if (GetIngredient(id)) AddIngredient(ingredient, amount);
        }


        private void btSubtractIngredient_Click(object sender, EventArgs e)
        {
            int amount = - Convert.ToInt32(nmIngredientImport.Value);
            if (amount == 0) return;

            int id = Convert.ToInt32(tbIngredientID.Text);
            if (GetIngredient(id)) AddIngredient(ingredient, amount);
        }

        private void btRemoveIngredient_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvBill.Items)
            {
                if (item.Text == ingredient.ID.ToString()) lvBill.Items.Remove(item);
                return;
            }
        }
        #endregion
    }
}
