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
    public partial class FAdmin : Form
    {
        BindingSource tableSource = new BindingSource();
        BindingSource foodSource = new BindingSource();
        BindingSource foodIngredientSource = new BindingSource();
        BindingSource ingredientSource2 = new BindingSource();
        BindingSource ingredientSource = new BindingSource();
        BindingSource userSource = new BindingSource();
        BindingSource timeKeepingSource = new BindingSource();
        BindingSource customerSource = new BindingSource();

        public FAdmin()
        {
            InitializeComponent();

            BindingDgv();

            LoadTable();
            LoadFood();
            LoadIngredient();
            LoadUser();
            LoadTimeKeeping();
            LoadCustomer();

            BindingInfo();
        }

        #region Methods
        private void BindingDgv()
        {
            dgvTable.DataSource = tableSource;
            dgvFood.DataSource = foodSource;

            cbbFIID.BindingContext = this.BindingContext;
            dgvFoodIngredient.DataSource = foodIngredientSource;
            dgvIngredient.DataSource = ingredientSource;
            dgvUser.DataSource = userSource;
            dgvTimeKeeping.DataSource = timeKeepingSource;
            dgvCustomer.DataSource = customerSource;
        }
        private void LoadTable()
        {
            tableSource.DataSource = TableDAO.Instance.GetListTable();
        }
        private void LoadFood()
        {
            foodSource.DataSource = FoodDAO.Instance.GetListFood();
            cbbFoodCategory.DataSource = FoodCategoryDAO.Instance.GetListFoodCategory();
            cbbFoodCategory.DisplayMember = "Name";
        }
        private void LoadIngredient()
        {
            DataTable data = IngredientDAO.Instance.GetListIngredient();
            ingredientSource.DataSource = data;

            cbbFIID.DataSource = IngredientDAO.Instance.GetListIngredient(data);
            cbbFIID.DisplayMember = "ID";
            lbFIName.DataBindings.Clear();
            lbFIPrice.DataBindings.Clear();
            lbFIUnit.DataBindings.Clear();
            lbFIName.DataBindings.Add(new Binding("Text", cbbFIID.DataSource, "Name", true, DataSourceUpdateMode.Never));
            lbFIPrice.DataBindings.Add(new Binding("Text", cbbFIID.DataSource, "Price", true, DataSourceUpdateMode.Never));
            lbFIUnit.DataBindings.Add(new Binding("Text", cbbFIID.DataSource, "Unit", true, DataSourceUpdateMode.Never));
        }
        private void LoadUser()
        {
            userSource.DataSource = UserAccountDAO.Instance.GetListUser();
        }
        private void LoadTimeKeeping()
        {
            try
            {
                int id = Convert.ToInt32(lbUserID.Text);
                timeKeepingSource.DataSource = TimeKeepingDAO.Instance.GetListTimeKeepingByID(id);
            }
            catch { timeKeepingSource.DataSource = TimeKeepingDAO.Instance.GetListTimeKeepingByID(100000); }

        }
        private void LoadCustomer()
        {
            customerSource.DataSource = CustomerAccountDAO.Instance.GetListCustomerAccount();
        }

        private void BindingInfo()
        {
            lbTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            cbbTableStatus.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
            cbbTableCurrentUsed.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "CurrentUsed", true, DataSourceUpdateMode.Never));

            lbFoodID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbFoodPrice.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
            cbbFoodCategory.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Category", true, DataSourceUpdateMode.Never));
            cbbFoodStatus.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "CurrentUsed", true, DataSourceUpdateMode.Never));

            lbIngredientID.DataBindings.Add(new Binding("Text", dgvIngredient.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbIngredientName.DataBindings.Add(new Binding("Text", dgvIngredient.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbIngredientPrice.DataBindings.Add(new Binding("Text", dgvIngredient.DataSource, "Price", true, DataSourceUpdateMode.Never));
            tbIngredientUnit.DataBindings.Add(new Binding("Text", dgvIngredient.DataSource, "Unit", true, DataSourceUpdateMode.Never));
            tbIngredientAmount.DataBindings.Add(new Binding("Text", dgvIngredient.DataSource, "Amount", true, DataSourceUpdateMode.Never));
            tbIngredientAlarmAmount.DataBindings.Add(new Binding("Text", dgvIngredient.DataSource, "AlarmAmount", true, DataSourceUpdateMode.Never));
            cbbIngredientStatus.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "CurrentUsed", true, DataSourceUpdateMode.Never));

            lbUserID.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbUserDisplayName.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            cbbUserStatus.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "Status", true, DataSourceUpdateMode.Never));
            nmUserSalary.DataBindings.Add(new Binding("Value", dgvUser.DataSource, "Salary", true, DataSourceUpdateMode.Never));
            cbbUserType.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "Type", true, DataSourceUpdateMode.Never));

            tbTKDate.DataBindings.Add(new Binding("Text", dgvTimeKeeping.DataSource, "Date", true, DataSourceUpdateMode.Never));
            tbTKInTime.DataBindings.Add(new Binding("Text", dgvTimeKeeping.DataSource, "InTime", true, DataSourceUpdateMode.Never));
            tbTKOutTime.DataBindings.Add(new Binding("Text", dgvTimeKeeping.DataSource, "OutTime", true, DataSourceUpdateMode.Never));
            tbTKSubTractHour.DataBindings.Add(new Binding("Text", dgvTimeKeeping.DataSource, "SubtractHour", true, DataSourceUpdateMode.Never));

            tbCustomerPhoneNum.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "PhoneNum", true, DataSourceUpdateMode.Never));
            tbCustomerName.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Name", true, DataSourceUpdateMode.Never));
            tbCustomerAddress.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "Address", true, DataSourceUpdateMode.Never));
            tbCustomerLastBuyDate.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "LastBuyDate", true, DataSourceUpdateMode.Never));
            tbCustomerBonusPoint.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "BonusPoint", true, DataSourceUpdateMode.Never));
        }

        #endregion

        #region Events
        private void watchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tcAdmin.SelectedIndex)    
            {
                case 0:
                    LoadTable();
                    break;
                case 1:
                    LoadFood();
                    break;
                case 2:
                    LoadIngredient();
                    break;
                case 3:
                    LoadUser();
                    break;
                case 4:
                    LoadCustomer();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tcAdmin.SelectedIndex)
            {
                case 0:
                    string taName = tbTableName.Text;
                    if (TableDAO.Instance.AddTable(taName)) LoadTable();
                    break;
                case 1:
                    if (foodIngredientSource.DataSource == null)
                    {
                        MessageBox.Show("Vui lòng tạo nguyên liệu cho món ăn này");
                        return;
                    }
                    if (dgvFoodIngredient.RowCount <= 1)
                    {
                        MessageBox.Show("Vui lòng tạo nguyên liệu cho món ăn này");
                        return;
                    }
                    string foName = tbFoodName.Text;

                    string foCategory = cbbFoodCategory.Text;
                    List<FoodCategory> categoryList = FoodCategoryDAO.Instance.GetListFoodCategory();
                    bool check = false;
                    foreach(FoodCategory item in categoryList)
                    {
                        if (item.Name == foCategory)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check) if (MessageBox.Show("Phân loại " + foCategory + " chưa tồn tại. Bạn có muốn tạo phân loại mới?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No) return;

                    int foPrice = Convert.ToInt32(tbFoodPrice.Text);

                    if (FoodDAO.Instance.AddFood(foName, foCategory, foPrice)) LoadFood();
                    int foID = FoodDAO.Instance.GetTopIDFood();
                    IngredientInfoDAO.Instance.DeleteIngredientInfoList(foID);
                    foreach (DataRow row in (foodIngredientSource.DataSource as DataTable).Rows)
                    {
                        int idFood = foID;
                        int idIngredient = (int)row["ID"];
                        float amount = (float)Math.Round(Convert.ToDouble(row["Số lượng"]), 2);
                        IngredientInfoDAO.Instance.AddIngredientInfo(idFood, idIngredient, amount);
                    }
                    break;
                case 2:
                    string inName = tbIngredientName.Text;
                    int inPrice = Convert.ToInt32(tbIngredientPrice.Text);
                    string inUnit = tbIngredientUnit.Text;
                    int inAlarmAmount = Convert.ToInt32(tbIngredientAlarmAmount.Text);
                    if (IngredientDAO.Instance.AddIngredient(inName, inPrice, inUnit, inAlarmAmount)) LoadIngredient();
                    break;
                case 3:
                    string usDisplayName = tbUserDisplayName.Text;
                    string usSalary = nmUserSalary.Value.ToString();
                    string usType = cbbUserType.Text;
                    if (UserAccountDAO.Instance.AddNewUser(usDisplayName, usSalary, usType)) LoadUser();

                    int tkID = Convert.ToInt32(lbUserID.Text);
                    DateTime tkDate = Convert.ToDateTime(tbTKDate.Text);
                    DateTime tkInTime = Convert.ToDateTime(tbTKInTime.Text);
                    DateTime tkOutTime = Convert.ToDateTime(tbTKOutTime.Text);
                    int tkSubtractHour = Convert.ToInt32(tbTKSubTractHour.Text);
                    if (TimeKeepingDAO.Instance.Modify_ByID_and_Date(tkID, tkDate, tkInTime, tkOutTime, tkSubtractHour)) LoadTimeKeeping();
                    break;
                case 4:
                    string cuPhoneNum = tbCustomerPhoneNum.Text;
                    string cuName = tbCustomerName.Text;
                    string cuAddress = tbCustomerAddress.Text;
                    if (CustomerAccountDAO.Instance.EnrollNewCustomer(cuPhoneNum, cuName, cuAddress)) LoadCustomer();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tcAdmin.SelectedIndex)
            {
                case 0:
                    int taID = Convert.ToInt32(lbTableID.Text);
                    string taName = tbTableName.Text;
                    if (TableDAO.Instance.ModifyTable(taID, taName)) LoadTable();
                    break;
                case 1:
                    int foID = Convert.ToInt32(lbFoodID.Text);
                    string foName = tbFoodName.Text;
                    int foPrice = Convert.ToInt32(tbFoodPrice.Text);

                    string foCategory = cbbFoodCategory.Text;
                    List<FoodCategory> categoryList = FoodCategoryDAO.Instance.GetListFoodCategory();
                    bool check = false;
                    foreach (FoodCategory item in categoryList)
                    {
                        if (item.Name == foCategory)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check) if (MessageBox.Show("Phân loại " + foCategory + " chưa tồn tại. Bạn có muốn tạo phân loại mới?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No) return;

                    if (FoodDAO.Instance.ModifyFood(foID, foName, foPrice, foCategory)) LoadFood();
                   
                    break;
                case 2:
                    int inID = Convert.ToInt32(lbIngredientID.Text);
                    string inName = tbIngredientName.Text;
                    int inPrice = Convert.ToInt32(tbIngredientPrice.Text);
                    string inUnit = tbIngredientUnit.Text;
                    int inAmount = Convert.ToInt32(tbIngredientAmount.Text);
                    int inAlarmAMount = Convert.ToInt32(tbIngredientAmount.Text);
                    if (IngredientDAO.Instance.ModifyIngredient(inID, inName, inPrice, inUnit, inAmount, inAlarmAMount)) LoadIngredient();
                    break;
                case 3:
                    int usID = Convert.ToInt32(lbUserID.Text);
                    string usDisplayName = tbUserDisplayName.Text;
                    string usStatus = cbbUserStatus.Text;
                    int usSalary = (int)nmUserSalary.Value;
                    string usType = cbbUserType.Text;
                    if (UserAccountDAO.Instance.ModifyUser(usID, usDisplayName, usStatus, usSalary, usType)) LoadUser();

                    int tkID = usID;
                    DateTime tkDate = Convert.ToDateTime(tbTKDate.Text);
                    DateTime tkInTime = Convert.ToDateTime(tbTKInTime.Text);
                    DateTime tkOutTime = Convert.ToDateTime(tbTKOutTime.Text);
                    int tkSubtractHour = Convert.ToInt32(tbTKSubTractHour.Text);
                    if (TimeKeepingDAO.Instance.Modify_ByID_and_Date(tkID, tkDate, tkInTime, tkOutTime, tkSubtractHour)) LoadTimeKeeping();
                    break;
                case 4:
                    string cuPhoneNum = tbCustomerPhoneNum.Text;
                    string cuName = tbCustomerName.Text;
                    string cuAddress = tbCustomerAddress.Text;
                    if (CustomerAccountDAO.Instance.CustomerInfoModify(cuPhoneNum, cuName, cuAddress)) LoadCustomer();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tcAdmin.SelectedIndex)
            {
                case 0:
                    int taID = Convert.ToInt32(lbTableID.Text);
                    if (TableDAO.Instance.DeleteTable(taID)) LoadTable();
                    break;
                case 1:
                    int foID = Convert.ToInt32(lbFoodID.Text);
                    if (FoodDAO.Instance.DeleteFood(foID)) LoadFood();
                    break;
                case 2:
                    int inID = Convert.ToInt32(lbIngredientID.Text);
                    if (IngredientDAO.Instance.DeleteIngredient(inID)) LoadIngredient();
                    break;
                case 3:
                    int usID = Convert.ToInt32(lbUserID.Text);
                    if (UserAccountDAO.Instance.DeleteUser(usID)) LoadUser();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvFood.Rows[dgvFood.CurrentRow.Index].Cells[0].Value);
                foodIngredientSource.DataSource = IngredientInfoDAO.Instance.GetIngredientInfoList_ByIDFood_Advance(id);
            }
            catch { }
        }

        private void btAddIngredient_Click(object sender, EventArgs e)
        {
            if (nmFIAmount.Value == 0) return;
            DataTable data = (DataTable)foodIngredientSource.DataSource;
            if (data == null) return;

            DataRow row = data.NewRow();
            int rowCount = dgvIngredient.RowCount;
            row["ID"] = cbbFIID.Text;
            row["Tên nguyên liệu"] = lbFIName.Text;
            row["Đơn giá"] = lbFIPrice.Text;
            row["Đơn vị"] = lbFIUnit.Text;
            row["Số lượng"] = nmFIAmount.Value;

            data.Rows.Add(row);
            data.AcceptChanges();
        }

        private void btRemoveIngredient_Click(object sender, EventArgs e)
        {
            if (dgvFoodIngredient.CurrentRow == null) return;
            dgvFoodIngredient.Rows.Remove(dgvFoodIngredient.CurrentRow);
        }

        private void tcAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcAdmin.SelectedIndex)
            {
                case 0:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    break;
                case 1:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    break;
                case 3:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                    break;
                case 4:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = false;
                    break;
                case 5:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = false;
                    modifyToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    break;
                case 6:
                    watchToolStripMenuItem.Enabled = true;
                    addToolStripMenuItem.Enabled = false;
                    modifyToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    break;
                case 7:
                    break;
                default:
                    break;
            }
        }

        private void btUserResetPass_Click(object sender, EventArgs e)
        {
            if (lbUserID.Text == null) return;
            int id = Convert.ToInt32(lbUserID.Text);
            if (UserAccountDAO.Instance.ResetUserPass(id)) MessageBox.Show("Đã reset Password của nhân viên " + lbUserID.Text + " thành 0");
            else MessageBox.Show("Có lỗi khi Reset Password");
        }

        private void lbUserID_Click(object sender, EventArgs e)
        {

        }

        private void lbUserID_TextChanged(object sender, EventArgs e)
        {
            LoadTimeKeeping();
        }
    }
}
