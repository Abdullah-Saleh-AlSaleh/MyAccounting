using MyAccounting.Data;
using MyAccounting.Models;
using System.Collections.ObjectModel;

namespace MyAccounting.Views.SalesView;

public partial class SDetails : ContentPage
{
    Database database;
    public ObservableCollection<Sales> ItemsSales { get; set; } = new();
    public bool IsRefreshing { get; set; }
      public Command RefreshCommand { get; set; }
    public Sales SelectedSales { get; set; }

    public SDetails(Database db)
	{
        RefreshCommand = new Command(async () =>
        {
            // Simulate delay
            await Task.Delay(2000);

            await LoadSales();

            IsRefreshing = false;
            OnPropertyChanged(nameof(IsRefreshing));
        });
        database = db;
		BindingContext= this;
        InitializeComponent();
		
	}


    private async Task LoadSales()
    {
        var items = await database.GetSales();
        ItemsSales.Clear();
        foreach (var item in items)
            ItemsSales.Add(item);
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetSales();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ItemsSales.Clear();
            foreach (var item in items)
                ItemsSales.Add(item);

        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SAdd), true, new Dictionary<string, object>
        {
            ["Sales"] = new Models.Sales()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Models.Sales item)
            return;

        await Shell.Current.GoToAsync(nameof(SAdd), true, new Dictionary<string, object>
        {
            ["Sales"] = item
        });
    }

}