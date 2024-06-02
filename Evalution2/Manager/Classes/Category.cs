using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class Category
    {
        public int Id
        {
            set;
            get;
        }
        public string CategoryName
        {
            set;
            get;
        }
        public int BudgetLimit
        {
            set;
            get;
        }
        public int CurrentMonthUsedAmount
        {
            set;
            get;
        }
        public Category(int id, string name, int limit, int currentUsedAmount)
        {
            Id = id;
            CategoryName = name;
            BudgetLimit = limit;
            CurrentMonthUsedAmount = currentUsedAmount;
        }
        public Category( string name, int limit, int currentUsedAmount)
        {

            CategoryName = name;
            BudgetLimit = limit;
            CurrentMonthUsedAmount = currentUsedAmount;
        }
    }
}
