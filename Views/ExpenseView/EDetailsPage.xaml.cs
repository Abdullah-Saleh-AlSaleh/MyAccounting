using MyAccounting.Data;
using MyAccounting.Models;
using System.Collections.ObjectModel;

namespace MyAccounting.Views.ExpenseView;
[QueryProperty("Expense", "Expense")]
public partial class EDetailsPage : ContentPage
{
   public Expense Expense { get; set; }
    //public Expense Expense
    //{
    //    get => BindingContext as Expense;
    //    set => BindingContext = value;
    //}
    Database database;
    public ObservableCollection<Expense> ItemsExpense { get; set; } = new();
    public bool IsRefreshing { get; set; }
    public Command RefreshCommand { get; set; }
    public Expense SelectedExpense { get; set; }

    public EDetailsPage(Database db)
    {
        RefreshCommand = new Command(async () =>
        {
            // Simulate delay
            await Task.Delay(2000);

            await LoadExpense();

            IsRefreshing = false;
            OnPropertyChanged(nameof(IsRefreshing));
        });
        database = db;
        BindingContext = this;
        InitializeComponent();

    }


    private async Task LoadExpense()
    {
        var items = await database.GetExpense();
        ItemsExpense.Clear();
        //var expense = from i in items
        //              where i.Statement == Expense.Statement
        //              select i;
        var expense = items.Where<Expense>(e => e.Statement == Expense.Statement).ToList();
        foreach (var item in expense)
            ItemsExpense.Add(item);
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetExpense();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            //var expense = from i in items
            //              where i.Statement == Expense.Statement
            //              select i;
            var expense = items.Where<Expense>(e => e.Statement == Expense.Statement).ToList();
            ItemsExpense.Clear();
            foreach (var item in expense)
            ItemsExpense.Add(item);

        });
    }

}