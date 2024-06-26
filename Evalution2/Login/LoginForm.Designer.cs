﻿namespace ExpenseTracker
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.mainP = new System.Windows.Forms.Panel();
            this.loginBackgorundMovingU1 = new ExpenseTracker.LoginBackgorundMovingU();
            this.ellipseControl1 = new ChatApplication.EllipseControl();
            this.mainP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainP
            // 
            this.mainP.BackColor = System.Drawing.Color.Teal;
            this.mainP.Controls.Add(this.loginBackgorundMovingU1);
            this.mainP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainP.Location = new System.Drawing.Point(8, 8);
            this.mainP.Margin = new System.Windows.Forms.Padding(2);
            this.mainP.Name = "mainP";
            this.mainP.Size = new System.Drawing.Size(784, 484);
            this.mainP.TabIndex = 5;
            // 
            // loginBackgorundMovingU1
            // 
            this.loginBackgorundMovingU1.BackColor = System.Drawing.Color.Teal;
            this.loginBackgorundMovingU1.Direction = ExpenseTracker.MoveDirection.None;
            this.loginBackgorundMovingU1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginBackgorundMovingU1.Location = new System.Drawing.Point(0, 0);
            this.loginBackgorundMovingU1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginBackgorundMovingU1.Name = "loginBackgorundMovingU1";
            this.loginBackgorundMovingU1.Padding = new System.Windows.Forms.Padding(3);
            this.loginBackgorundMovingU1.Size = new System.Drawing.Size(784, 484);
            this.loginBackgorundMovingU1.TabIndex = 0;
            this.loginBackgorundMovingU1.Visible = false;
            // 
            // ellipseControl1
            // 
            this.ellipseControl1.CornerRadius = 10;
            this.ellipseControl1.TargetControl = this;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.mainP);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.mainP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mainP;
        private LoginBackgorundMovingU loginBackgorundMovingU1;
        private ChatApplication.EllipseControl ellipseControl1;
    }
}