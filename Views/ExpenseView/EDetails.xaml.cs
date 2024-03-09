using MyAccounting.Data;
using MyAccounting.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyAccounting.Views.ExpenseView;

public partial class EDetails : ContentPage
{
    Database database;
    public ObservableCollection<Expense> ItemsExpenseT { get; set; } = new();
    public EDetails(Database db)
    {
        InitializeComponent();
        database = db;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetExpense();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ItemsExpenseT.Clear();

            var ItemExpenseNotLOOP = items.DistinctBy(r => r.Statement).ToList();
            //var sql = from i in items
            //          select new {ID=i.ID, ExpenseID=i.ID, Date=i.Date, Statement=i.Statement , Total_Value= items.Select(m => m.Total_Value).Sum() };


            //foreach (var item in sql)

            //   ItemsExpenseT.Add(new ExpenseTotal{ ID=item.ID, ExpenseID = item.ID, Date=item.Date, Statement = item.Statement, Total_Value=item.Total_Value ,expense=items.FirstOrDefault()});
            //   //  ItemsExpenseT.Add(item);

            string Statement = string.Empty;

            foreach (var item in ItemExpenseNotLOOP)
            {
                Statement = item.Statement;
                item.Total_Value = items.Where<Expense>(p => p.Statement == Statement).Sum(N => N.Total_Value);
                ItemsExpenseT.Add(item);
            }

        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(EAdd), true, new Dictionary<string, object>
        {
            ["Expense"] = new Models.Expense()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Expense item)
            return;

        await Shell.Current.GoToAsync(nameof(EDetailsPage), true, new Dictionary<string, object>
        {
            ["Expense"] = item
        });
    }

}
