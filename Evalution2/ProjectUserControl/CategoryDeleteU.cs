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
    public partial class CategoryDeleteU : UserControl
    {
        public EventHandler<int> onClickRemove;
        public CategoryDeleteU()
        {
            InitializeComponent();
            List<Category> categories = ExpenseManager.CategoryDictionary.Values.ToList();
            categories.RemoveAt(0);
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].Id == ExpenseManager.OtherCategoryId)
                {
                    categories.RemoveAt(i);
                    break;
                }
            }
            categoryCB.DataSource = categories;
            categoryCB.DisplayMember ="CategoryName";
            categoryCB.ValueMember ="Id";
            removeBtn.Click+= RemoveBtnClick;
        }

        private void RemoveBtnClick(object sender, EventArgs e)
        {
            
            onClickRemove.Invoke(this, (int)categoryCB.SelectedValue);
        }

        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeBtn.Focus();
        }
    }
}
