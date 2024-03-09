using MyAccounting.Data;
using MyAccounting.Models;

namespace MyAccounting.Views.ExpenseView;
[QueryProperty("Expense", "Expense")]
public partial class EAdd : ContentPage
{
    Expense expense;
    public Expense Expense
    {
        get => BindingContext as Expense;
        set => BindingContext = value;
    }
    Database db;
    public EAdd(Database database)
    {
        InitializeComponent();
        db = database;
    }
    async void OnSaveClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(Expense.Statement))
        {
            await DisplayAlert("«·—Ã«¡ ≈œŒ«· ", "«·»Ì«‰«  «·„ÿ·Ê»…", "„Ê«›ﬁ");
            return;
        }
        if (string.IsNullOrWhiteSpace(Expense.StatementDa))
        {
            await DisplayAlert("«·—Ã«¡ ≈œŒ«· ", "«·»Ì«‰«  «·„ÿ·Ê»…", "„Ê«›ﬁ");
            return;
        }  


        await db.SaveExpense(Expense);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (expense.ID == 0)
            return;
     //   await db.DeleteItemAsync(Expense);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
