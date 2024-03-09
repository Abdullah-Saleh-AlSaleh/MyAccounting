using MyAccounting.Models;
using MyAccounting.Data;
namespace MyAccounting.Views.SalesView;
[QueryProperty("Sales", "Sales")]
public partial class SAdd : ContentPage
{
    Sales sales;
    public Sales Sales
    {
        get => BindingContext as Sales;
        set => BindingContext = value;
    }
    Database db;

    public SAdd(Database database)
	{
		InitializeComponent();
        db = database;
	}
    async void OnSaveClicked(object sender, EventArgs e)
    {
    
        if (string.IsNullOrWhiteSpace(Sales.Statement))
        {
            await DisplayAlert("«·—Ã«¡ ≈œŒ«· ", "«·»Ì«‰«  «·„ÿ·Ê»…", "„Ê«›ﬁ");
            return;
        }

        await db.SaveSales(Sales);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sales.ID == 0)
            return;
        await db.DeleteItemAsync(Sales);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}