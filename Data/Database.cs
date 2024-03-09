

using MyAccounting.Models;
using SQLite;
using System.Globalization;

namespace MyAccounting.Data
{
    public class Database
    {
        SQLiteAsyncConnection db;
        SQLiteConnection db1;
        public Database()
        {
            
        }
        async Task Init()
        {
            if (db is not null)
                return;

            db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            //  var result =
            var result = await db.CreateTableAsync<Sales>();
            result = await db.CreateTableAsync<Purchase>();
            result = await db.CreateTableAsync<Expense>();

        }
        // GetList-------------Acconuting---------------------
        public async Task<List<Sales>> GetSales()
        {
            await Init();
            return await db.Table<Sales>().ToListAsync();
        }
        public async Task<List<Purchase>> GetPurchase()
        {
            await Init();
            return await db.Table<Purchase>().ToListAsync();
        }
        public async Task<List<Expense>> GetExpense()
        {
            await Init();
            return await db.Table<Expense>().ToListAsync();
        }
        public List<Expense> GetExpenses()
        {

            db1 = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            return db1.Table<Expense>().ToList();
        }
        //GetEND----------------------------------
        public async Task<Sales> GetSales(int id)
        {
            await Init();
            return await db.Table<Sales>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public async Task<Purchase> GetPurchase(int id)
        {
            await Init();
            return await db.Table<Purchase>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public async Task<Expense> GetExpense(int id)
        {
            await Init();
            return await db.Table<Expense>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        //Add-----------------------------------------
        public async Task<int> SaveSales(Sales item)
        {
            await Init();
            CultureInfo CurrentCulture = CultureInfo.GetCultureInfo("ar-AE");
            item.Date = DateTime.Now.ToString("yyyy-MM-dd", CurrentCulture);
            item.Total_Value = item.Quantity * item.Sales_price;
            if (item.ID != 0)
            {
                return await db.UpdateAsync(item);
            }
            else
            {
                return await db.InsertAsync(item);
            }
        }
        public async Task<int> SavePurchase(Purchase item)
        {
            await Init();
            CultureInfo CurrentCulture = CultureInfo.GetCultureInfo("ar-AE");
            item.Date = DateTime.Now.ToString("yyyy-MM-dd", CurrentCulture);
            item.Total_Value = item.Quantity * item.Buy_price;
            if (item.ID != 0)
            {
                return await db.UpdateAsync(item);
            }
            else
            {
                return await db.InsertAsync(item);
            }
        }
        public async Task<int> SaveExpense(Expense item)
        {
            
            await Init();
            
            CultureInfo CurrentCulture = CultureInfo.GetCultureInfo("ar-AE");
            item.Date = DateTime.Now.ToString("yyyy-MM-dd", CurrentCulture);
            if (item.ID != 0)
            {
                return await db.UpdateAsync(item);
            }
            else
            {
                return await db.InsertAsync(item);
            }
        }
        //--------------------------------------------
        public async Task<int> DeleteItemAsync(Sales item)
        {
            await Init();
            return await db.DeleteAsync(item);
        }
        public async Task<int> DeleteSales(int item)
        {
            await Init();
            return await db.DeleteAsync(item);
        }
    }
}
