using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker.Manager
{
    public static class ExpenseManager
    {
        public static MySqlConnection mySqlConnection;
        public static int AllCategoryId = 1;
        public static int OtherCategoryId = 2;
        private static int Expense_Id = 1;
        public static string DatabasePassword = "";
        public static string DatabaseName = "ExpenseTracker";
        public static Dictionary<string, Category> CategoryDictionary = new Dictionary<string, Category>();
        public static Dictionary<int, Expense> ExpenseDictionary = new Dictionary<int, Expense>();
        private static MySqlCommand cmd = new MySqlCommand();
        public static bool DataBaseConnecting()
        {
            string connectionstring = $"server=localhost;port=3306;uid=root;pwd={DatabasePassword };database={DatabaseName}";
            mySqlConnection = new MySqlConnection(connectionstring);

            try
            {
                mySqlConnection.Open();
                cmd.Connection = mySqlConnection;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public static void DataBaseExitsCheck()
        {
            string connectionstring = "server=localhost;port=3306;uid=root;pwd=;database=mysql";
            mySqlConnection = new MySqlConnection(connectionstring);

            try
            {
                mySqlConnection.Open();
                cmd.Connection = mySqlConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ExcuteQuery("Create database ExpenseTracker;");
            string connectionstring2 = "server=localhost;port=3306;uid=root;pwd=;database=ExpenseTracker";
            mySqlConnection = new MySqlConnection(connectionstring2);

            try
            {
                mySqlConnection.Open();
                cmd.Connection = mySqlConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ExcuteQuery("create table category(CategoryID int auto_increment,CategoryName varchar(100),BudgetLimit int,CurrentMonthUsedAmount int,primary key(CategoryID)); ");
            ExcuteQuery("create table expense(ExpenseID int auto_increment primary key,CategoryID int,DateAndTime datetime,Amount int,Detail varchar(200),foreign key(CategoryID) references category(CategoryID)); ");
            ExcuteQuery("create table logininformation(LoginUsername varchar(100),  LoginPassword varchar(50),  UpdatedDate Datetime,  Id int); ");
            ExcuteQuery("insert into logininformation(LoginUsername,LoginPassword,UpdatedDate,Id) values('a','a','2024-03-18',1);");
            ExcuteQuery("insert into category(CategoryName,BudgetLimit,CurrentMonthUsedAmount) values ('All',10000,0),('Others',10000,0),('Travel',2000,0),('Movies',2000,0),('Food',2000,0);");

        }
        public static void ExcuteQuery(string query)
        {
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        public static void ExpenseRefresh()
        {
            ExpenseDictionary = GetExpenseSource();
        }
        public static void CategoryRefresh()
        {
            CategoryDictionary = GetCategorySource();
            Category other = CategoryDictionary["" + 2];
            CategoryDictionary.Remove("" + 2);
            CategoryDictionary.Add("" + other.Id, other);
        }
        public static bool AddCategory(Category category)
        {
            string addCategoryQuery = $"insert into category(CategoryName,BudgetLimit,CurrentMonthUsedAmount) values ('{category.CategoryName}',{category.BudgetLimit},{category.CurrentMonthUsedAmount});";
            cmd.CommandText = addCategoryQuery;
            cmd.ExecuteNonQuery();
            CategoryRefresh();
            return true;
        }
        public static void UpdateCategory(Category category)
        {
            CategoryDictionary["" + category.Id].CategoryName = category.CategoryName;
            CategoryDictionary["" + category.Id].BudgetLimit = category.BudgetLimit;
            string foreignKeyCheckOFF = $"SET FOREIGN_KEY_CHECKS ={0};";
            cmd.CommandText = foreignKeyCheckOFF;
            cmd.ExecuteNonQuery();
            string updateCategoryQuery = $"update category set CategoryName='{category.CategoryName}',BudgetLimit='{category.BudgetLimit}' where CategoryID={category.Id}";
            cmd.CommandText = updateCategoryQuery;
            cmd.ExecuteNonQuery();
            string foreignKeyCheckOn = $"SET FOREIGN_KEY_CHECKS ={1};";
            cmd.CommandText = foreignKeyCheckOn;
            cmd.ExecuteNonQuery();
        }
        public static bool DeleteCategory(int categoryId)
        {
            CategoryDictionary.Remove("" + categoryId);
            string foreignKeyCheckOFF = $"SET FOREIGN_KEY_CHECKS ={0};";
            ExcuteQuery(foreignKeyCheckOFF);
            string deleteCategoryQuery = $"delete from category where CategoryID={categoryId};";
            ExcuteQuery(deleteCategoryQuery);
            string convertExpenseToOthersCategory = $"update expense  set CategoryID={OtherCategoryId} where CategoryID={categoryId};";
            ExcuteQuery(convertExpenseToOthersCategory);
            int otherCategoryAmount = getCurrentMonthUsedAmountFromDatabaseExpenseTable(OtherCategoryId);
            UpdategetCurrentMonthUsedAmount(OtherCategoryId, otherCategoryAmount);
            CategoryDictionary["" + OtherCategoryId].CurrentMonthUsedAmount = otherCategoryAmount;
            string foreignKeyCheckOn = $"SET FOREIGN_KEY_CHECKS ={1};";
            cmd.CommandText = foreignKeyCheckOn;
            cmd.ExecuteNonQuery();
            ExpenseDictionary = GetExpenseSource();
            return true;
        }
        public static int getCurrentMonthUsedAmountFromDatabaseExpenseTable(int categoryId)
        {
            string sumOfOtherCategoryAmountQuery = $" Select Sum(Amount) from expense where CategoryID={categoryId} and Month(DateAndTime)={DateTime.Now.Month} and Year(DateAndTime)={DateTime.Now.Year};";

            cmd.CommandText = sumOfOtherCategoryAmountQuery;
            var totalAmount = cmd.ExecuteScalar();
            if (!(totalAmount is DBNull))
            {
                return Convert.ToInt32(totalAmount);
            }
            else
                return 0;
        }
        public static int getCurrentMonthUsedAmountFromDatabaseExpenseTable()
        {
            string sumOfOtherCategoryAmountQuery = $" Select Sum(Amount) from expense where   Month(DateAndTime)={DateTime.Now.Month} and Year(DateAndTime)={DateTime.Now.Year};";

            cmd.CommandText = sumOfOtherCategoryAmountQuery;
            var totalAmount = cmd.ExecuteScalar();
            if (!(totalAmount is DBNull))
            {
                return Convert.ToInt32(totalAmount);
            }
            else
                return 0;
        }
        public static int GetCurrentMonthLimitExceedAmount(int categoryID)
        {
            string getCurrentMonthUsedAmountQuery = $"select (CurrentMonthUsedAmount-BudgetLimit)  from category where CategoryID={categoryID};";
            cmd.CommandText = getCurrentMonthUsedAmountQuery;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static Expense GetExpenseByIdFromDatabase(int expenseId)
        {
            string getExpenseQuery = $"select expense.ExpenseID ,expense.CategoryID ,expense.Amount ,expense.DateAndTime,expense.Detail From expense left Join category on expense.CategoryID = category.CategoryID where expense.ExpenseID={expenseId};";
            DataTable table = new DataTable();
            cmd.CommandText = getExpenseQuery;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                table.Load(reader);
            }
            return new Expense(int.Parse(table.Rows[0]["ExpenseID"].ToString()), int.Parse(table.Rows[0]["CategoryID"].ToString()), int.Parse(table.Rows[0]["Amount"].ToString()), (DateTime)table.Rows[0]["DateAndTime"], table.Rows[0]["Detail"].ToString(),CategoryDictionary["" + int.Parse(table.Rows[0]["CategoryID"].ToString())].CategoryName);
        }
        public static Category GetCategoryByIdFromDatabase(int categoryId)
        {
            DataTable table = new DataTable();
            string getCategoryQuery = $"select CategoryName,BudgetLimit from category where CategoryID={categoryId}";
            cmd.CommandText = getCategoryQuery;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                table.Load(reader);
            }
            return new Category(Convert.ToInt32(table.Rows[0]["CategoryID"]), Convert.ToString(table.Rows[0]["CategoryName"]), Convert.ToInt32(table.Rows[0]["BudgetLimit"]), getCurrentMonthUsedAmountFromDatabaseExpenseTable(Convert.ToInt32(table.Rows[0]["CategoryID"])));
        }
        public static bool EditCurrentMonthUsedAmountToCategory(int amount, int categoryID)
        {
            CategoryDictionary[""+AllCategoryId].CurrentMonthUsedAmount = CategoryDictionary["" + AllCategoryId].CurrentMonthUsedAmount + amount;
            CategoryDictionary["" + categoryID].CurrentMonthUsedAmount = CategoryDictionary["" + categoryID].CurrentMonthUsedAmount + amount;
            string addAmountToCategoryQuery = $"update category set CurrentMonthUsedAmount=CurrentMonthUsedAmount+{amount} where CategoryID={categoryID};";
            ExcuteQuery(addAmountToCategoryQuery);
            string addAmountToAllCategoryQuery = $"update category set CurrentMonthUsedAmount=CurrentMonthUsedAmount+{amount} where CategoryID={1};";
            ExcuteQuery(addAmountToAllCategoryQuery);
            return true;
        }
        public static bool AddExpense(Expense expense)
        {
            string addQuery = $"INSERT INTO expense (CategoryID, Amount, DateAndTime, Detail) VALUES ({expense.CategoryID}, {expense.Amount}, '{expense.DateAndTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{expense.Detail.ToString()}');";
            ExcuteQuery(addQuery);
            if (expense.DateAndTime.Month == DateTime.Now.Month && (expense.DateAndTime).Year == DateTime.Now.Year)
            {
                EditCurrentMonthUsedAmountToCategory( expense.Amount, expense.CategoryID);
            }
            expense = getExpenseFromDataBase(expense.DateAndTime);
            ExpenseDictionary.Add(expense.ExpenseID, expense);
            return true;
        }
        public static Expense getExpenseFromDataBase(DateTime DateAndTime)
        {
            string getExpenseQuery = $"select expense.ExpenseID ,expense.CategoryID ,expense.Amount ,expense.DateAndTime,expense.Detail From expense left Join category on expense.CategoryID = category.CategoryID where expense.DateAndTime='{DateAndTime.ToString("yyyy-MM-dd HH:mm:ss")}';";
            DataTable table = new DataTable();
            cmd.CommandText = getExpenseQuery;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                table.Load(reader);
            }
            return new Expense(int.Parse(table.Rows[0]["ExpenseID"].ToString()), int.Parse(table.Rows[0]["CategoryID"].ToString()), int.Parse(table.Rows[0]["Amount"].ToString()), (DateTime)table.Rows[0]["DateAndTime"], table.Rows[0]["Detail"].ToString(), CategoryDictionary["" + int.Parse(table.Rows[0]["CategoryID"].ToString())].CategoryName);
        }
        public static bool UpdateExpense(Expense expense)
        {
            ExpenseDictionary[expense.ExpenseID] = expense;
            string expenseUpdateQuery = $"update expense set CategoryID={expense.CategoryID}, Amount={expense.Amount},DateAndTime='{expense.DateAndTime.ToString("yyyy-MM-dd HH:mm:ss")}',Detail='{expense.Detail.ToString()}' where ExpenseID={expense.ExpenseID};";
            cmd.CommandText = expenseUpdateQuery;
            cmd.ExecuteNonQuery();
            if (expense.DateAndTime.Month == DateTime.Now.Month && expense.DateAndTime.Year == DateTime.Now.Year)
            {
                EditCurrentMonthUsedAmountToCategory(expense.Amount, expense.CategoryID);
            }

            return true;
        }
        public static bool DeleteExpense(Expense expense)
        {
            string deleteQuery = $"delete From expense Where ExpenseId={expense.ExpenseID}";
            cmd.CommandText = deleteQuery;
            cmd.ExecuteNonQuery();

            if (expense.DateAndTime.Month == DateTime.Now.Month && expense.DateAndTime.Year == DateTime.Now.Year)
            {
                EditCurrentMonthUsedAmountToCategory(-expense.Amount, expense.CategoryID);
            }
            ExpenseDictionary.Remove(expense.ExpenseID);
            return true;
        }
        public static Dictionary<string, Category> GetCategorySource()
        {
            DataTable table = new DataTable();

            string categoryGetQuery = "select category.CategoryID as CategoryID,category.CategoryName as CategoryName,category.BudgetLimit as BudgetLimit,category.CurrentMonthUsedAmount as CurrentMonthUsedAmount from category;";
            try
            {
                using (MySqlCommand command = new MySqlCommand(categoryGetQuery, mySqlConnection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
                Dictionary<string, Category> categoryDictionary = new Dictionary<string, Category>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int currentMonthAmount = 0;
                    if (int.Parse(table.Rows[i]["CategoryID"].ToString()) != 1)
                        currentMonthAmount = getCurrentMonthUsedAmountFromDatabaseExpenseTable(int.Parse(table.Rows[i]["CategoryID"].ToString()));
                    else
                        currentMonthAmount = getCurrentMonthUsedAmountFromDatabaseExpenseTable();
             
                        UpdategetCurrentMonthUsedAmount(int.Parse(table.Rows[i]["CategoryID"].ToString()), currentMonthAmount);

                    categoryDictionary.Add(""+int.Parse(table.Rows[i]["CategoryID"].ToString()), new Category(Convert.ToInt32(table.Rows[i]["CategoryID"]), Convert.ToString(table.Rows[i]["CategoryName"]), Convert.ToInt32(table.Rows[i]["BudgetLimit"]), currentMonthAmount));
                }
                return categoryDictionary;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static Dictionary<int, Expense> GetExpenseSource()
        {
            DataTable table = new DataTable();
            Dictionary<int, Expense> ExpenseDictionary = new Dictionary<int, Expense>();
            string expenseGetQuery = "select expense.ExpenseID as ExpenseID,category.CategoryID as CategoryID,expense.DateAndTime as DateAndTime,expense.Amount as Amount,expense.Detail as Detail from expense Left JOIN category  ON  Expense.CategoryID= Category.CategoryID order by DateAndTime desc ;";
            try
            {
                using (MySqlCommand command = new MySqlCommand(expenseGetQuery, mySqlConnection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        ExpenseDictionary.Add(int.Parse(table.Rows[i]["ExpenseID"].ToString()), new Expense(int.Parse(table.Rows[i]["ExpenseID"].ToString()), int.Parse(table.Rows[i]["CategoryID"].ToString()), int.Parse(table.Rows[i]["Amount"].ToString()), (DateTime)table.Rows[i]["DateAndTime"], table.Rows[i]["Detail"].ToString(), CategoryDictionary["" + int.Parse(table.Rows[i]["CategoryID"].ToString())].CategoryName));
                    }
                }
                return ExpenseDictionary;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static void UpdategetCurrentMonthUsedAmount(int categoryId, int Amount)
        {
            string UpdategetCurrentMonthUsedAmountQuery = $" Update category set CurrentMonthUsedAmount={Amount} where CategoryId={categoryId}";
           
            ExcuteQuery(UpdategetCurrentMonthUsedAmountQuery);
        }

        //Login
        public static DataTable LoginInformationSource()
        {
            DataTable dataTable = new DataTable();
            string loginInformationGetQuery = "select logininformation.LoginUsername as Username, logininformation.LoginPassword as Password from logininformation";
            using (MySqlCommand command = new MySqlCommand(loginInformationGetQuery, mySqlConnection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                { dataTable.Load(reader); }
            }
            return dataTable;
        }
        public static void LoginPasswordChange(string username, string password)
        {
            string passwordChangeQuery = $"update logininformation set LoginPassword='{password}',UpdatedDate='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where LoginUsername='{username}' ";
            ExcuteQuery(passwordChangeQuery);
        }
        public static void LoginDetailChange(string username, string password)
        {
            string passwordChangeQuery = $"update logininformation set LoginPassword='{password}',LoginUsername='{username}',UpdatedDate='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where id={1} ";
            ExcuteQuery(passwordChangeQuery);
        }
    }
}
