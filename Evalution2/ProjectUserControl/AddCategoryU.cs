using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class AddCategoryU : UserControl
    {

        public EventHandler<Category> OnclickSubmit;

        private int editCategoryId = -1;
        public AddCategoryU()
        {
            InitializeComponent();
            submitBtn.Click += SubmitBtnClick;
        }
        public AddCategoryU(Category category)
        {
            InitializeComponent();
            editCategoryId = category.Id;
            categaryNameTB.Text = category.CategoryName;
            submitBtn.Click += SubmitBtnClick;
        }

        private void SubmitBtnClick(object sender, EventArgs e)
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
                OnclickSubmit.Invoke(this, new Category(categaryNameTB.Text, limitAmount, 0));

        }
    }
}
