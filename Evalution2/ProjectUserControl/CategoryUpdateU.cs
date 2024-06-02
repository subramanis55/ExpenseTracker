using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseTracker.Manager;

namespace ExpenseTracker
{
    public partial class CategoryUpdateU : UserControl
    {
        public EventHandler<Category> OnClickSave;

        public CategoryUpdateU()
        {
            InitializeComponent();


            categoryCB.DataSource = ExpenseManager.CategoryDictionary.Values.ToList();
            categoryCB.DisplayMember = "CategoryName";
            categoryCB.ValueMember = "Id";
            categoryCB.SelectedIndexChanged += CategoryCBValueMemberChanged;
            CategoryCBValueMemberChanged(this, EventArgs.Empty);
            // categoryCB.SelectedValue = 1;
            SaveBtn.Click += SaveBtnClick;
        }

        private void SaveBtnClick(object sender, EventArgs e)
        {
            int limitAmount = 0;
            try
            {
                limitAmount = int.Parse(limitTB.Text);
                amountErrorLabel.Visible = false;
            }
            catch
            {
                amountErrorLabel.Visible = true;
            }

            if (categaryNameTB.Text == "")
                categorynameErrorLabel.Visible = true;
            else
                categorynameErrorLabel.Visible = false;

            if (categorynameErrorLabel.Visible == false && amountErrorLabel.Visible == false)
                OnClickSave?.Invoke(this, new Category((int)categoryCB.SelectedValue, categaryNameTB.Text, limitAmount, ExpenseManager.CategoryDictionary["" + (int)categoryCB.SelectedValue].CurrentMonthUsedAmount));
        }


        private void CategoryCBValueMemberChanged(object sender, EventArgs e)
        {
            if (categoryCB.DataSource != null)
            {
                if (categoryCB.SelectedIndex == 0 || (int)categoryCB.SelectedValue == ExpenseManager.OtherCategoryId)
                {
                    categaryNameTB.ReadOnly = true;
                }
                else
                {
                    categaryNameTB.ReadOnly = false;
                }
                categaryNameTB.Text = ExpenseManager.CategoryDictionary["" + ((int)categoryCB.SelectedValue)].CategoryName;
                limitTB.Text = "" + ExpenseManager.CategoryDictionary["" + ((int)categoryCB.SelectedValue)].BudgetLimit;
            }

        }
    }
}
