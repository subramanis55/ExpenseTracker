using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class Expense
    {
        public int ExpenseID
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
        public string Category
        {
            set;
            get;
        }
        public int Amount
        {
            set;
            get;
        }
        public DateTime DateAndTime
        {
            set;
            get;
        }
        public string Detail
        {
            set;
            get;
        }
     
     
       
        public Expense(int expenseId, int categoryID, int amount, DateTime dateTime, string detail,string categoryName)
        {
            ExpenseID = expenseId;
            CategoryID = categoryID;
            Detail = detail;
            Amount = amount;
            DateAndTime = dateTime;
            Category = categoryName;
        }
        public Expense(int categoryID, int amount, DateTime dateTime, string detail)
        {

            CategoryID = categoryID;
            Detail = detail;
            Amount = amount;
            DateAndTime = dateTime;
        }
    }
}
