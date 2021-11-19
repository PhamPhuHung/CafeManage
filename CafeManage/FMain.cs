using CafeManage.DAO;
using CafeManage.DTO;
using CafeManage.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManage
{
    public partial class FMain : Form
    {
        BindingSource foodSource = new BindingSource();
        public class BillCheckOut
        {
            public static int finalPrice;
            public static int used;
            public static int get;
        }
        private UserAccount logInAccount;

        public UserAccount LogInAccount
        {
            get => logInAccount;
            set { logInAccount = value; ChangeAccount(); }
        }

        public FMain(UserAccount logInAccount)
        {
            InitializeComponent();
            this.LogInAccount = logInAccount;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");

            LoadTable();
            LoadFoodCategory();

            dgvFood.DataSource = foodSource;
            lbFoodID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "ID"));
            lbFoodName.DataBindings.Add(new Binding("Text", foodSource, "Tên món"));
            lbFoodPrice.DataBindings.Add(new Binding("Text", foodSource, "Đơn giá"));
            LoadFood();
        }

        #region Methods
        private void ChangeAccount()
        {
            adminToolStripMenuItem.Visible = logInAccount.Type == "Quản Lý";
            userInfoToolStripMenuItem.Text = string.Format("{0}", logInAccount.DisplayName); 
        }
        private void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.GetListTable();
            List<Button> btTableList = new List<Button>();
            foreach (Table table in tableList)
            {
                if (table.CurrentUsed == "Khả dụng")
                {
                    Button btTable = new Button()
                    {
                        Width = 100,
                        Height = 100,
                        Text = table.Name + "\n\n\n" + table.Status,
                        BackColor = Color.WhiteSmoke,
                        ForeColor = Color.Black,
                        Tag = table,
                        BackgroundImage = table.Status == "Trống" ? Resources.UnOccupiedTable : Resources.OccupiedTable,
                        BackgroundImageLayout = ImageLayout.Zoom
                    };
                btTable.Click += BtTable_Click;
                btTableList.Add(btTable);
                }
            }
            flpTable.Controls.Clear();
            flpTable.Controls.AddRange(btTableList.ToArray());
        }
        private void LoadFoodCategory()
        {
            List<FoodCategory> categoryList = FoodCategoryDAO.Instance.GetListFoodCategory();
            List<Button> btCategoryList = new List<Button>();
            foreach (FoodCategory item in categoryList)
            {
                Button btCategory = new Button()
                {
                    Width = 100,
                    Height = 46,
                    Text = item.Name,
                    BackColor = Color.DimGray,
                    ForeColor =  Color.White
                };
                btCategory.Click += BtCategory_Click;
                btCategoryList.Add(btCategory);
            }
            flpFoodCategory.Controls.Clear();
            flpFoodCategory.Controls.Add(btAllFood);
            flpFoodCategory.Controls.AddRange(btCategoryList.ToArray());
        }
        private void LoadFood()
        {
            DataTable foodList = new DataTable();
            string category = "";
            foreach (Button bt in flpFoodCategory.Controls)
            {
                if (!bt.Enabled && bt!=btAllFood)
                {
                    category = bt.Text;
                    break;
                }
            }
            foodList = FoodDAO.Instance.GetListFood_ByCategory(category);
            foodSource.DataSource = foodList;
        }
        private void ShowBill(int idTable)
        {
            lvBill.Items.Clear();

            Bill bill = BillDAO.Instance.GetUncheckedBill_ByTableID(idTable);
            lvBill.Tag = bill;
            if (bill == null) return;
            List<DTO.Menu> tableMenu = MenuDAO.Instance.GetListMenu_ByBillID(bill.ID);

            int i = 0;
            int totalPrice = 0;
            foreach (DTO.Menu item in tableMenu)
            {
                i++;
                ListviewBill_AddItem(new string[] { i.ToString(), item.Name, item.Price.ToString("c"), item.Amount.ToString(), item.TotalPrice.ToString("c") }, new Font("Microsoft Sans Serif", 12, FontStyle.Regular));
                totalPrice += item.TotalPrice;
            }
            BillCheckOut.finalPrice = totalPrice - bill.Discount;
            BillCheckOut.used = 0;
            BillCheckOut.get = 0;
            ListviewBill_AddItem(new string[] { "", "Tạm tính", "", "", totalPrice.ToString("c") }, new Font("Microsoft Sans Serif", 12, FontStyle.Bold));
            ListviewBill_AddItem(new string[] { "", "Giảm giá", "", "", bill.Discount.ToString("c") }, new Font("Microsoft Sans Serif", 12, FontStyle.Bold));
            ListviewBill_AddItem(new string[] { "", "Thành tiền", "", "", (totalPrice - bill.Discount).ToString("c") }, new Font("Microsoft Sans Serif", 12, FontStyle.Bold));

            CustomerAccount customer = CustomerAccountDAO.Instance.GetCustomerAccountByPhoneNum(bill.IDCustomer);
            if (customer != null)
            {
                BillCheckOut.get = Convert.ToInt32(Math.Ceiling(totalPrice / 100000.0));
                BillCheckOut.used = bill.Discount / 1000;
                ListviewBill_AddItem(new string[] { "", "KH: " + customer.Name + 
                    ", tích lũy: " + (customer.BonusPoint + BillCheckOut.get - BillCheckOut.used).ToString() + " điểm" },
                    new Font("Microsoft Sans Serif", 12, FontStyle.Bold));


            }
        }

        private void ListviewBill_AddItem(string[] s, Font f)
        {
            ListViewItem lvItem = new ListViewItem(s[0]);
            for (int i = 1; i < s.Count() ; i++) 
            {
                lvItem.SubItems.Add(s[i]);
            }
            lvItem.Font = f;
            lvBill.Items.Add(lvItem);
        }
        #endregion   

        #region Events

        private void BtCategory_Click(object sender, EventArgs e)
        {
            foreach (Button btCategory in flpFoodCategory.Controls)
            {
                btCategory.Enabled = true;
                btCategory.BackColor = Color.DimGray;
            }
            Button bt = sender as Button;
            bt.Enabled = false;
            bt.BackColor = Color.LimeGreen;
            LoadFood();
        }

        private void BtTable_Click(object sender, EventArgs e)
        {
            Button btTable = sender as Button;
            Table table = btTable.Tag as Table;

            gbBill.Text = "HÓA ĐƠN (" + table.Name +")";
            btAddFood.Tag = table;
            btSubtractFood.Tag = table;
            btRemoveFood.Tag = table;

            ShowBill(table.ID);

            ShowBill((btAddFood.Tag as Table).ID);

            lbCustomerPhoneNum.Text = "";
            lbCustomerName.Text = "";
            lbCustomerBonusPoint.Text = "";
            nmUsedBonusPoint.Maximum = 0;
            nmUsedBonusPoint.Value = 0;
            nmUsedBonusPoint.Enabled = false;
            btUseBonusPoint.Enabled = false;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAdmin fAdmin = new FAdmin();
            fAdmin.ShowDialog();
        }

        private void individualInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FUserProfile fUserProfile = new FUserProfile(LogInAccount);
            fUserProfile.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FCustomerProfile fCustomer = new FCustomerProfile();
            fCustomer.AddCustomerToBill += FCustomer_AddCustomerToBill;
            fCustomer.ShowDialog();
        }

        private void FCustomer_AddCustomerToBill(object sender, CustomerEvent e)
        {
            if (lvBill.Tag == null) return;

            Bill bill = lvBill.Tag as Bill;
            BillDAO.Instance.AddCustomerToBill(e.Customer.PhoneNum, bill.ID);
            ShowBill((btAddFood.Tag as Table).ID);
            lbCustomerPhoneNum.Text = e.Customer.PhoneNum;
            lbCustomerName.Text = e.Customer.Name;
            lbCustomerBonusPoint.Text = e.Customer.BonusPoint.ToString();
            nmUsedBonusPoint.Maximum = e.Customer.BonusPoint;
            nmUsedBonusPoint.Value = e.Customer.BonusPoint;
            nmUsedBonusPoint.Enabled = true;
            btUseBonusPoint.Enabled = true;

        }

        private void ingredientImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FIngredientImport fIngredientImport = new FIngredientImport(LogInAccount);
            fIngredientImport.ShowDialog();
        }
        #endregion

        private void btUnoccupiedTable_Click(object sender, EventArgs e)
        {
            foreach (Button bt in flpTable.Controls)
            {
                if ((bt.Tag as Table).Status == "Trống") bt.Visible = true;
                else bt.Visible = false;
            }
            btUnoccupiedTable.BackColor = Color.LimeGreen;
            btAllTable.BackColor = Color.DimGray;
            btOccupiedTable.BackColor = Color.DimGray;

            btUnoccupiedTable.Enabled = false;
            btAllTable.Enabled = true;
            btOccupiedTable.Enabled = true;
        }

        private void btAllTable_Click(object sender, EventArgs e)
        {
            LoadTable();
            foreach (Button bt in flpTable.Controls)
            {
                bt.Visible = true;
            }
            btUnoccupiedTable.BackColor = Color.DimGray;
            btAllTable.BackColor = Color.LimeGreen;
            btOccupiedTable.BackColor = Color.DimGray;

            btUnoccupiedTable.Enabled = true;
            btAllTable.Enabled = false;
            btOccupiedTable.Enabled = true;
        }

        private void btOccupiedTable_Click(object sender, EventArgs e)
        {
            foreach (Button bt in flpTable.Controls)
            {
                if ((bt.Tag as Table).Status != "Trống") bt.Visible = true;
                else bt.Visible = false;
            }
            btUnoccupiedTable.BackColor = Color.DimGray;
            btAllTable.BackColor = Color.DimGray;
            btOccupiedTable.BackColor = Color.LimeGreen;

            btUnoccupiedTable.Enabled = true;
            btAllTable.Enabled = true;
            btOccupiedTable.Enabled = false;
        }

        private void btAllFood_Click(object sender, EventArgs e)
        {
            foreach (Button btCategory in flpFoodCategory.Controls)
            {
                btCategory.Enabled = true;
                btCategory.BackColor = Color.DimGray;
            }
            Button bt = sender as Button;
            bt.Enabled = false;
            bt.BackColor = Color.LimeGreen;
            LoadFood();
        }

        private void btAddFood_Click(object sender, EventArgs e)
        {
            if (btAddFood.Tag == null | nmFoodQty.Value == 0) return;

            Bill bill = lvBill.Tag as Bill;
            Table table = btAddFood.Tag as Table;
            if (bill == null)
            {
                BillDAO.Instance.InsertBill(LogInAccount.ID, table.ID);
                LoadTable();
                bill = BillDAO.Instance.GetUncheckedBill_ByTableID(table.ID);
            }

            List<IngredientInfo> ingredientInfoList = IngredientInfoDAO.Instance.GetIngredientInfoList_ByIDFood(Convert.ToInt32(lbFoodID.Text));
            foreach (IngredientInfo item in ingredientInfoList)
            {
                float amount = item.Amount * Convert.ToInt32(nmFoodQty.Value);
                if (amount > IngredientDAO.Instance.GetIngredient_ByID(item.IdIngredient).Amount)
                {
                    MessageBox.Show(string.Format("Không còn đủ nguyên liệu để làm {0} món {1}", nmFoodQty.Value, lbFoodName.Text));
                    return;
                }
            }
            foreach (IngredientInfo item in ingredientInfoList)
            {
                IngredientDAO.Instance.ModifytIngredientAmount(item.IdIngredient, item.Amount * (-1) * Convert.ToInt32(nmFoodQty.Value));
            }

            BillInfoDAO.Instance.InsertBillInfo(Convert.ToInt32(lbFoodID.Text), bill.ID, Convert.ToInt32(nmFoodQty.Value));
            ShowBill(table.ID);
        }

        private void btSubtractFood_Click(object sender, EventArgs e)
        {
            if (btSubtractFood.Tag == null | nmFoodQty.Value == 0) return;

            Bill bill = lvBill.Tag as Bill;
            Table table = btSubtractFood.Tag as Table;
            if (bill == null)
            {
                return;
            }

            BillInfoDAO.Instance.InsertBillInfo(Convert.ToInt32(lbFoodID.Text), bill.ID, Convert.ToInt32(nmFoodQty.Value)*(-1));
            ShowBill(table.ID);
            LoadTable();
        }

        private void btRemoveFood_Click(object sender, EventArgs e)
        {
            if (lvBill.Tag == null || btAddFood.Tag == null || string.IsNullOrWhiteSpace(lbFoodID.Text)) return;

            Table table = btAddFood.Tag as Table;
            Bill bill = lvBill.Tag as Bill;

            if (BillInfoDAO.Instance.DeleteBillInfo(bill.ID, Convert.ToInt32(lbFoodID.Text)))
            ShowBill(table.ID);
            LoadTable();
        }

        private void btUseBonusPoint_Click(object sender, EventArgs e)
        {
            if (lvBill.Tag == null || btAddFood.Tag == null) return;

            Table table = btAddFood.Tag as Table;
            Bill bill = lvBill.Tag as Bill;

            BillDAO.Instance.CustomerUseBonusForBill(lbCustomerPhoneNum.Text, bill.ID, Convert.ToInt32(nmUsedBonusPoint.Value) * 1000);
            ShowBill(table.ID);
        }

        private void btCheckOut_Click(object sender, EventArgs e)
        {
            if (lvBill.Tag == null || btAddFood.Tag == null) return;

            Table table = btAddFood.Tag as Table;
            Bill bill = lvBill.Tag as Bill;

            if (BillDAO.Instance.CheckOut(bill.ID, BillCheckOut.finalPrice))
            {
                CustomerAccount customer = CustomerAccountDAO.Instance.GetCustomerAccountByPhoneNum(bill.IDCustomer);
                if (customer != null)
                    CustomerAccountDAO.Instance.ModifyBonusPoint_AfterCheckOut(BillCheckOut.used, BillCheckOut.get, customer.PhoneNum);

                LoadTable();
                lvBill.Items.Clear();
            }
        }

        private void addFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btAddFood_Click(null, null);
        }

        private void subtractFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btSubtractFood_Click(null, null);
        }

        private void removeFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btRemoveFood_Click(null, null);
        }

        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btCheckOut_Click(null, null);
        }
    }
}
