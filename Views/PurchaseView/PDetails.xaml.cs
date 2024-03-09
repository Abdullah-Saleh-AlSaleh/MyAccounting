using MyAccounting.Data;
using MyAccounting.Models;
using System.Collections.ObjectModel;

namespace MyAccounting.Views.PurchaseView;

public partial class PDetails : ContentPage
{
    Database database;
    public ObservableCollection<Purchase> ItemsPurchase { get; set; } = new();
    public bool IsRefreshing { get; set; }
    public Command RefreshCommand { get; set; }
    public Sales SelectedPurchase { get; set; }

    public PDetails(Database db)
    {
        RefreshCommand = new Command(async () =>
        {
            // Simulate delay
            await Task.Delay(2000);

            await LoadPurchase();

            IsRefreshing = false;
            OnPropertyChanged(nameof(IsRefreshing));
        });
        database = db;
        BindingContext = this;
        InitializeComponent();

    }


    private async Task LoadPurchase()
    {
        var items = await database.GetPurchase();
        ItemsPurchase.Clear();
        foreach (var item in items)
            ItemsPurchase.Add(item);
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetPurchase();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ItemsPurchase.Clear();
            foreach (var item in items)
                ItemsPurchase.Add(item);

        });
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PAdd), true, new Dictionary<string, object>
        {
            ["Purchase"] = new Models.Purchase()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Models.Purchase item)
            return;

        await Shell.Current.GoToAsync(nameof(PAdd), true, new Dictionary<string, object>
        {
            ["Purchase"] = item
        });
    }

}