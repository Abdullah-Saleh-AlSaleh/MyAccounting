using MyAccounting.Data;
using MyAccounting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounting.ViewModel
{
    public class DataViewModel
    {
        private Database db = new();
        public ObservableCollection<Person> Data { get; set; } = new();
        public DataViewModel()
        {
            Data = new ObservableCollection<Person>()
            {

                new Person { Month = "1", Height =1500 },
                new Person { Month = "2", Height = 2000 },
                new Person { Month = "3", Height =  1750 },
                new Person { Month = "4", Height = 1500 },
                new Person { Month = "5", Height =2500 },
                new Person { Month = "6", Height = 2650 },
                new Person { Month = "7", Height = 2840 },
                new Person { Month = "8", Height = 3048 },
                new Person { Month = "9", Height = 2605 },
                new Person { Month = "10", Height = 1050 },
                new Person { Month = "11", Height =2000 },
                new Person { Month = "12", Height = 1680},
            };
        }
        private int ConvertToMonth(string strDateTime)
        {
            int sdtFinaldate; string sDateTime;
            try
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[2] + '/' + sDate[1] + '/' + sDate[0];
                sdtFinaldate = Convert.ToInt32(sDate[1]);
            }
            catch (Exception e)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[2] + '/' + sDate[1] + '/' + sDate[0];
                sdtFinaldate = Convert.ToInt32(sDate[1]);

            }
            return sdtFinaldate;
        }
        async void GetData()
        {
            var data = await db.GetExpense();
            var GetData = from i in data
                          select new { Date = i.Date.Replace("-", "/"), Total = i.Total_Value };
            var ExpenseMonth1 = GetData.Where(e => ConvertToMonth(e.Date) == 1).Sum(t => t.Total);
            var ExpenseMonth2 = GetData.Where(e => ConvertToMonth(e.Date) == 2).Sum(t => t.Total);
            var ExpenseMonth3 = GetData.Where(e => ConvertToMonth(e.Date) == 3).Sum(t => t.Total);
            var ExpenseMonth4 = GetData.Where(e => ConvertToMonth(e.Date) == 4).Sum(t => t.Total);
            var ExpenseMonth5 = GetData.Where(e => ConvertToMonth(e.Date) == 5).Sum(t => t.Total);
            var ExpenseMonth6 = GetData.Where(e => ConvertToMonth(e.Date) == 6).Sum(t => t.Total);
            var ExpenseMonth7 = GetData.Where(e => ConvertToMonth(e.Date) == 7).Sum(t => t.Total);
            var ExpenseMonth8 = GetData.Where(e => ConvertToMonth(e.Date) == 8).Sum(t => t.Total);
            var ExpenseMonth9 = GetData.Where(e => ConvertToMonth(e.Date) == 9).Sum(t => t.Total);
            var ExpenseMonth10 = GetData.Where(e => ConvertToMonth(e.Date) == 10).Sum(t => t.Total);
            var ExpenseMonth11 = GetData.Where(e => ConvertToMonth(e.Date) == 11).Sum(t => t.Total);
            var ExpenseMonth12 = GetData.Where(e => ConvertToMonth(e.Date) == 12).Sum(t => t.Total);
            //Data = new List<Person>()
            //{
            //    new Person { Month = "يناير", Height = ExpenseMonth1 },
            //    new Person { Month = "فبراير", Height = ExpenseMonth2 },
            //    new Person { Month = "مارس", Height = ExpenseMonth3 },
            //    new Person { Month = "ابريل", Height = ExpenseMonth4 },
            //    new Person { Month = "مايو", Height = ExpenseMonth5 },
            //    new Person { Month = "يونيو", Height = ExpenseMonth6 },
            //    new Person { Month = "يوليو", Height = ExpenseMonth7 },
            //    new Person { Month = "اغسطس", Height = ExpenseMonth8 },
            //    new Person { Month = "سبتمبر", Height = ExpenseMonth9 },
            //    new Person { Month = "أكتوبر", Height = ExpenseMonth10 },   
            //    new Person { Month = "نوفمبر", Height = ExpenseMonth11 },
            //    new Person { Month = "ديسمبر", Height = ExpenseMonth12 },
            //};
        }

        void DataTs()
        {
            Data = new ObservableCollection<Person>()
            {

                new Person { Month = "1", Height =db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 1).Sum(t=>t.Total_Value) },
                new Person { Month = "2", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 2).Sum(t=>t.Total_Value) },
                new Person { Month = "3", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 3).Sum(t=>t.Total_Value) },
                new Person { Month = "4", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 4).Sum(t=>t.Total_Value) },
                new Person { Month = "5", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 5).Sum(t=>t.Total_Value)},
                new Person { Month = "6", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 6).Sum(t=>t.Total_Value) },
                new Person { Month = "7", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 7).Sum(t=>t.Total_Value) },
                new Person { Month = "8", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 8).Sum(t=>t.Total_Value) },
                new Person { Month = "9", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 9).Sum(t=>t.Total_Value) },
                new Person { Month = "10", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 10).Sum(t=>t.Total_Value) },
                new Person { Month = "11", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 11).Sum(t=>t.Total_Value) },
                new Person { Month = "12", Height = db.GetExpenses().Where(e=> ConvertToMonth(e.Date.Replace("-", "/")) == 12).Sum(t=>t.Total_Value) },
            };
        }
    }
}
