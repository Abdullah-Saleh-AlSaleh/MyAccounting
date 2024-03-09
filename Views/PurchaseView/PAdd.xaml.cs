using MyAccounting.Data;
using MyAccounting.Models;

namespace MyAccounting.Views.PurchaseView;
[QueryProperty("Purchase", "Purchase")]
public partial class PAdd : ContentPage
{
    Purchase purchase;
    public Purchase Purchase
    {
        get => BindingContext as Purchase;
        set => BindingContext = value;
    }
    Database db;
    public PAdd(Database database)
    {
        InitializeComponent();
        db = database;
    }
    async void OnSaveClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(Purchase.Statement))
        {
             await DisplayAlert("«·—Ã«¡ ≈œŒ«· ","«·»Ì«‰«  «·„ÿ·Ê»…", "„Ê«›ﬁ");
            return;
         
        }

        await db.SavePurchase(Purchase);
        await Shell.Current.GoToAsync("..");
    }

    //async void OnDeleteClicked(object sender, EventArgs e)
    //{
    //    if (purchase.ID == 0)
    //        return;
    //    await db.DeleteItemAsync(Purchase);
    //    await Shell.Current.GoToAsync("..");
    //}

    //async void OnCancelClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync("..");
    //}

}