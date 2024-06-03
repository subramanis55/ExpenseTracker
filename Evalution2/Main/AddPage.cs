using ExpenseTracker.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class AddPage : Form
    {

        public EventHandler<Expense> OnSubmit;
        Expense editExpense;
        public bool IsEditMode;
        private int editExpenseId;
        private DateTime date;
        public AddPage()
        {
            InitializeComponent();
            titleLabel.Text = "Add ";
            submitBtn.Text = "Add";
            var categoryComboboxSource = ExpenseManager.CategoryDictionary.Values.ToList();
            categoryComboboxSource.RemoveAt(0);
            for (int i = 0; i < categoryComboboxSource.Count; i++)
            {
                if (categoryComboboxSource[i].Id == ExpenseManager.OtherCategoryId)
                {
                    Category categrory = categoryComboboxSource[i];
                    categoryComboboxSource.RemoveAt(i);
                    categoryComboboxSource.Add(categrory);
                }
            }
            categoryCB.DataSource = categoryComboboxSource;
            categoryCB.DisplayMember = "CategoryName";
            categoryCB.ValueMember = "Id";
            Load += AddPageLoad;

        }

        public AddPage(Expense expense)
        {

            InitializeComponent();
            IsEditMode = true;
            titleLabel.Text = "Edit ";
            submitBtn.Text = "Save";
            var categoryComboboxSource = ExpenseManager.CategoryDictionary.Values.ToList();
            categoryComboboxSource.RemoveAt(0);
            for (int i = 0; i < categoryComboboxSource.Count; i++)
            {
                if (categoryComboboxSource[i].Id == ExpenseManager.OtherCategoryId)
                {
                    Category categrory = categoryComboboxSource[i];
                    categoryComboboxSource.RemoveAt(i);
                    categoryComboboxSource.Add(categrory);
                }
            }
            categoryCB.DataSource = categoryComboboxSource;
            categoryCB.DisplayMember = "CategoryName";
            categoryCB.ValueMember = "Id";
            editExpense = expense;
           Load += AddPageLoad;
            ValueSetToEdit();
        }
        bool isUp;
        Point prevPoint;
        private void MessageBoxTopPMouseMove(object sender, MouseEventArgs e)
        {
            if (isUp)
            {
                this.Location = new Point(Location.X + (Cursor.Position.X - prevPoint.X), Location.Y + (Cursor.Position.Y - prevPoint.Y));
                prevPoint = Cursor.Position;
            }

        }
        private void MessageBoxTopPMouseDown(object sender, MouseEventArgs e)
        {
            isUp = true;
            prevPoint = Cursor.Position;
        }

        private void MessageBoxTopPMouseUp(object sender, MouseEventArgs e)
        {
            isUp = false;
        }

        private void ValueSetToEdit()
        {
               

                amountTB.Text = "" + editExpense.Amount;
                dateTimePicker.Value = editExpense.DateAndTime;
                categoryCB.SelectedValue = editExpense.CategoryID;
                reasonTB.Text = editExpense.Detail;
           
        }

        public AddPage(List<string> categorySource)
        {
            InitializeComponent();

        }

        private void AddPageLoad(object sender, EventArgs e)
        {
            submitBtn.Click += SubmitBtnClick;
            dateTimePicker.ValueChanged += DateTimePickerValueChanged;
            // categoryCB.SelectedIndex = 0;
            date = dateTimePicker.Value;
        }

        private void DateTimePickerValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker.Value;
        }

        private void SubmitBtnClick(object sender, EventArgs e)
        {
            try
            {
                int temp = int.Parse(amountTB.Text);
                if (IsEditMode)
                {
                    editExpense.Detail = reasonTB.Text;
                    editExpense.DateAndTime = date;
                    editExpense.Amount = Convert.ToInt32(amountTB.Text);
                    editExpense.CategoryID = (int)categoryCB.SelectedValue;
                    editExpense.Category = ExpenseManager.CategoryDictionary["" + (int)categoryCB.SelectedValue].CategoryName;
                    OnSubmit?.Invoke(this, editExpense);
                }
                else
                    OnSubmit?.Invoke(this, new Expense((int)categoryCB.SelectedValue, Convert.ToInt32(amountTB.Text), date, reasonTB.Text));
            }
            catch
            {
                amountErrorLabel.Visible = true;

            }
              
            
           

        }

        private void colseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void amountTBTextChanged(object sender, EventArgs e)
        {
                
        }

        private void categoryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            submitBtn.Focus();
        }
    }
}
