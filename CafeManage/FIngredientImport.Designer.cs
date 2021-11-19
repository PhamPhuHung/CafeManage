namespace CafeManage
{
    partial class FIngredientImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btImport = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIngredientID = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbIngredientName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbIngredientPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbIngredientUnit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbIngredientAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nmIngredientImport = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btRemoveIngredient = new System.Windows.Forms.Button();
            this.btSubtractIngredient = new System.Windows.Forms.Button();
            this.btAddIngredient = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmIngredientImport)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(149, 682);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(211, 27);
            this.btImport.TabIndex = 4;
            this.btImport.Text = "Nhập kho - Xuất hóa đơn";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btExit
            // 
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Location = new System.Drawing.Point(366, 682);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(103, 27);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btRemoveIngredient);
            this.groupBox1.Controls.Add(this.btSubtractIngredient);
            this.groupBox1.Controls.Add(this.btAddIngredient);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 335);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN NGUYÊN LIỆU";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.tbIngredientID);
            this.flowLayoutPanel1.Controls.Add(this.btSearch);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lbIngredientName);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lbIngredientPrice);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.lbIngredientUnit);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.lbIngredientAmount);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.nmIngredientImport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(482, 261);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã nguyên liệu:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbIngredientID
            // 
            this.tbIngredientID.Location = new System.Drawing.Point(170, 13);
            this.tbIngredientID.Name = "tbIngredientID";
            this.tbIngredientID.Size = new System.Drawing.Size(187, 26);
            this.tbIngredientID.TabIndex = 1;
            // 
            // btSearch
            // 
            this.btSearch.ForeColor = System.Drawing.Color.Black;
            this.btSearch.Location = new System.Drawing.Point(363, 13);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(103, 26);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "Tìm kiếm";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên nguyên liệu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIngredientName
            // 
            this.lbIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIngredientName.ForeColor = System.Drawing.Color.White;
            this.lbIngredientName.Location = new System.Drawing.Point(171, 45);
            this.lbIngredientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIngredientName.Name = "lbIngredientName";
            this.lbIngredientName.Size = new System.Drawing.Size(295, 35);
            this.lbIngredientName.TabIndex = 15;
            this.lbIngredientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 35);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đơn giá:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIngredientPrice
            // 
            this.lbIngredientPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIngredientPrice.ForeColor = System.Drawing.Color.White;
            this.lbIngredientPrice.Location = new System.Drawing.Point(171, 80);
            this.lbIngredientPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIngredientPrice.Name = "lbIngredientPrice";
            this.lbIngredientPrice.Size = new System.Drawing.Size(295, 35);
            this.lbIngredientPrice.TabIndex = 16;
            this.lbIngredientPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 35);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đơn vị:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIngredientUnit
            // 
            this.lbIngredientUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIngredientUnit.ForeColor = System.Drawing.Color.White;
            this.lbIngredientUnit.Location = new System.Drawing.Point(171, 115);
            this.lbIngredientUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIngredientUnit.Name = "lbIngredientUnit";
            this.lbIngredientUnit.Size = new System.Drawing.Size(267, 35);
            this.lbIngredientUnit.TabIndex = 17;
            this.lbIngredientUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 35);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số lượng hiện tại:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIngredientAmount
            // 
            this.lbIngredientAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIngredientAmount.ForeColor = System.Drawing.Color.White;
            this.lbIngredientAmount.Location = new System.Drawing.Point(171, 150);
            this.lbIngredientAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIngredientAmount.Name = "lbIngredientAmount";
            this.lbIngredientAmount.Size = new System.Drawing.Size(295, 35);
            this.lbIngredientAmount.TabIndex = 18;
            this.lbIngredientAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 185);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(409, 35);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nhập kho";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(14, 220);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 35);
            this.label7.TabIndex = 14;
            this.label7.Text = "Số lượng nhập kho:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nmIngredientImport
            // 
            this.nmIngredientImport.Location = new System.Drawing.Point(170, 223);
            this.nmIngredientImport.Name = "nmIngredientImport";
            this.nmIngredientImport.Size = new System.Drawing.Size(296, 26);
            this.nmIngredientImport.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvBill);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(0, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 341);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HÓA ĐƠN NHẬP KHO";
            // 
            // lvBill
            // 
            this.lvBill.BackColor = System.Drawing.Color.SteelBlue;
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBill.ForeColor = System.Drawing.Color.White;
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(3, 22);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(482, 316);
            this.lvBill.TabIndex = 3;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên món";
            this.columnHeader2.Width = 137;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số lượng";
            this.columnHeader4.Width = 79;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thành tiền";
            this.columnHeader5.Width = 124;
            // 
            // btRemoveIngredient
            // 
            this.btRemoveIngredient.ForeColor = System.Drawing.Color.Black;
            this.btRemoveIngredient.Location = new System.Drawing.Point(367, 296);
            this.btRemoveIngredient.Name = "btRemoveIngredient";
            this.btRemoveIngredient.Size = new System.Drawing.Size(103, 27);
            this.btRemoveIngredient.TabIndex = 11;
            this.btRemoveIngredient.Text = "Xóa";
            this.btRemoveIngredient.UseVisualStyleBackColor = true;
            this.btRemoveIngredient.Click += new System.EventHandler(this.btRemoveIngredient_Click);
            // 
            // btSubtractIngredient
            // 
            this.btSubtractIngredient.ForeColor = System.Drawing.Color.Black;
            this.btSubtractIngredient.Location = new System.Drawing.Point(258, 296);
            this.btSubtractIngredient.Name = "btSubtractIngredient";
            this.btSubtractIngredient.Size = new System.Drawing.Size(103, 27);
            this.btSubtractIngredient.TabIndex = 10;
            this.btSubtractIngredient.Text = "Bớt";
            this.btSubtractIngredient.UseVisualStyleBackColor = true;
            this.btSubtractIngredient.Click += new System.EventHandler(this.btSubtractIngredient_Click);
            // 
            // btAddIngredient
            // 
            this.btAddIngredient.ForeColor = System.Drawing.Color.Black;
            this.btAddIngredient.Location = new System.Drawing.Point(149, 296);
            this.btAddIngredient.Name = "btAddIngredient";
            this.btAddIngredient.Size = new System.Drawing.Size(103, 27);
            this.btAddIngredient.TabIndex = 9;
            this.btAddIngredient.Text = "Thêm";
            this.btAddIngredient.UseVisualStyleBackColor = true;
            this.btAddIngredient.Click += new System.EventHandler(this.btAddIngredient_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 55;
            // 
            // FIngredientImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(488, 715);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.btExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FIngredientImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập kho nguyên liệu";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmIngredientImport)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIngredientID;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbIngredientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbIngredientPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbIngredientUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbIngredientAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmIngredientImport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btRemoveIngredient;
        private System.Windows.Forms.Button btSubtractIngredient;
        private System.Windows.Forms.Button btAddIngredient;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}