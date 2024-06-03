namespace ExpenseTracker
{
    partial class AddPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.reasonTB = new System.Windows.Forms.TextBox();
            this.nameLB = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.amountErrorLabel = new System.Windows.Forms.Label();
            this.amountTB = new System.Windows.Forms.TextBox();
            this.amountLB = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLB = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.categoryLB = new System.Windows.Forms.Label();
            this.categoryCB = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.submitBtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.colseBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 426);
            this.panel1.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(10);
            this.panel9.Size = new System.Drawing.Size(321, 365);
            this.panel9.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 345);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.reasonTB);
            this.panel4.Controls.Add(this.nameLB);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 237);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(301, 104);
            this.panel4.TabIndex = 0;
            // 
            // reasonTB
            // 
            this.reasonTB.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonTB.Location = new System.Drawing.Point(72, 22);
            this.reasonTB.Multiline = true;
            this.reasonTB.Name = "reasonTB";
            this.reasonTB.Size = new System.Drawing.Size(196, 73);
            this.reasonTB.TabIndex = 1;
            // 
            // nameLB
            // 
            this.nameLB.AutoSize = true;
            this.nameLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLB.Location = new System.Drawing.Point(15, 3);
            this.nameLB.Name = "nameLB";
            this.nameLB.Size = new System.Drawing.Size(58, 20);
            this.nameLB.TabIndex = 0;
            this.nameLB.Text = "Details";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.amountErrorLabel);
            this.panel7.Controls.Add(this.amountTB);
            this.panel7.Controls.Add(this.amountLB);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 154);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(301, 83);
            this.panel7.TabIndex = 3;
            // 
            // amountErrorLabel
            // 
            this.amountErrorLabel.AutoSize = true;
            this.amountErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.amountErrorLabel.Location = new System.Drawing.Point(69, 64);
            this.amountErrorLabel.Name = "amountErrorLabel";
            this.amountErrorLabel.Size = new System.Drawing.Size(72, 15);
            this.amountErrorLabel.TabIndex = 2;
            this.amountErrorLabel.Text = "Invalid Input";
            this.amountErrorLabel.Visible = false;
            // 
            // amountTB
            // 
            this.amountTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTB.Location = new System.Drawing.Point(72, 26);
            this.amountTB.Name = "amountTB";
            this.amountTB.Size = new System.Drawing.Size(196, 26);
            this.amountTB.TabIndex = 1;
            this.amountTB.TextChanged += new System.EventHandler(this.amountTBTextChanged);
            // 
            // amountLB
            // 
            this.amountLB.AutoSize = true;
            this.amountLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLB.Location = new System.Drawing.Point(15, 3);
            this.amountLB.Name = "amountLB";
            this.amountLB.Size = new System.Drawing.Size(65, 20);
            this.amountLB.TabIndex = 0;
            this.amountLB.Text = "Amount";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.dateTimePicker);
            this.panel6.Controls.Add(this.dateLB);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 88);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(301, 66);
            this.panel6.TabIndex = 2;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(72, 24);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(196, 28);
            this.dateTimePicker.TabIndex = 1;
            // 
            // dateLB
            // 
            this.dateLB.AutoSize = true;
            this.dateLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLB.Location = new System.Drawing.Point(15, 3);
            this.dateLB.Name = "dateLB";
            this.dateLB.Size = new System.Drawing.Size(44, 20);
            this.dateLB.TabIndex = 0;
            this.dateLB.Text = "Date";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.categoryLB);
            this.panel5.Controls.Add(this.categoryCB);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(301, 88);
            this.panel5.TabIndex = 1;
            // 
            // categoryLB
            // 
            this.categoryLB.AutoSize = true;
            this.categoryLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLB.Location = new System.Drawing.Point(7, 0);
            this.categoryLB.Name = "categoryLB";
            this.categoryLB.Size = new System.Drawing.Size(73, 20);
            this.categoryLB.TabIndex = 0;
            this.categoryLB.Text = "Category";
            // 
            // categoryCB
            // 
            this.categoryCB.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryCB.FormattingEnabled = true;
            this.categoryCB.Location = new System.Drawing.Point(72, 33);
            this.categoryCB.Name = "categoryCB";
            this.categoryCB.Size = new System.Drawing.Size(196, 29);
            this.categoryCB.TabIndex = 1;
            this.categoryCB.SelectedIndexChanged += new System.EventHandler(this.categoryCB_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panel3.Controls.Add(this.submitBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 365);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 50, 10);
            this.panel3.Size = new System.Drawing.Size(321, 61);
            this.panel3.TabIndex = 2;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.Teal;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(108, 13);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(113, 35);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Teal;
            this.panel8.Controls.Add(this.titleLabel);
            this.panel8.Controls.Add(this.colseBtn);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(8, 5, 3, 3);
            this.panel8.Size = new System.Drawing.Size(321, 41);
            this.panel8.TabIndex = 1;
            this.panel8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageBoxTopPMouseDown);
            this.panel8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageBoxTopPMouseMove);
            this.panel8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MessageBoxTopPMouseUp);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(8, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(8, 4, 0, 0);
            this.titleLabel.Size = new System.Drawing.Size(53, 28);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Add";
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageBoxTopPMouseDown);
            this.titleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageBoxTopPMouseMove);
            this.titleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MessageBoxTopPMouseUp);
            // 
            // colseBtn
            // 
            this.colseBtn.BackColor = System.Drawing.Color.Crimson;
            this.colseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.colseBtn.FlatAppearance.BorderSize = 0;
            this.colseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colseBtn.ForeColor = System.Drawing.Color.White;
            this.colseBtn.Image = global::ExpenseTracker.Properties.Resources.icons8_cancel_30;
            this.colseBtn.Location = new System.Drawing.Point(279, 5);
            this.colseBtn.Name = "colseBtn";
            this.colseBtn.Size = new System.Drawing.Size(39, 33);
            this.colseBtn.TabIndex = 1;
            this.colseBtn.UseVisualStyleBackColor = false;
            this.colseBtn.Click += new System.EventHandler(this.colseBtn_Click);
            // 
            // AddPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 467);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddPage";
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox categoryCB;
        private System.Windows.Forms.Label categoryLB;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label dateLB;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox amountTB;
        private System.Windows.Forms.Label amountLB;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label nameLB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox reasonTB;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button colseBtn;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label amountErrorLabel;
    }
}