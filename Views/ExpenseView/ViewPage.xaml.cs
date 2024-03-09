using MyAccounting.Data;

namespace MyAccounting.Views.ExpenseView;

public partial class ViewPage : ContentPage
{
    private Database db = new();
	public ViewPage()
	{
		InitializeComponent();
        

    }
    private async void EDetailsClicked(object sender, EventArgs e)
    {
     
        await Shell.Current.GoToAsync(nameof(EDetails));
    }

    async void GetDataExpense()
    {
        try
        {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    var Get = await db.GetExpense();
                    var Total1 = Get.Where(t => ConvertToYear(t.Date.Replace("-", "/")) == DateTime.Now.Year).Sum(tos => tos.Total_Value).ToString();
                    var Total2 = Get.Select(t => t.Total_Value).Sum().ToString();
                    ExpenseTotal1.Text = " ≈Ã„«·Ì «·„’—Ê›«  Œ·«· «·⁄«„ " + DateTime.Now.Year.ToString() + "  : " + Total1 + "—Ì«· ";
                    ExpenseTotal2.Text = " ≈Ã„«·Ì «·„’—Ê›«   : " + Total2 + "—Ì«· ";

                });
            }
        catch (Exception e)
        {

            await DisplayAlert("Error", e.Message, "Ok");
        }

    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var Get = await db.GetExpense();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            try
            {
                    var Total1 = Get.Where(t => ConvertToYear(t.Date.Replace("-", "/")) == DateTime.Now.Year).Sum(tos => tos.Total_Value).ToString();
                    var Total2 = Get.Select(t => t.Total_Value).Sum().ToString();
                    ExpenseTotal1.Text = " ≈Ã„«·Ì «·„’—Ê›«  Œ·«· «·⁄«„ " + DateTime.Now.Year.ToString() + "  : " + Total1 + "—Ì«· ";
                    ExpenseTotal2.Text = " ≈Ã„«·Ì «·„’—Ê›«   : " + Total2 + "—Ì«· ";

            }
            catch (Exception e)
            {

                await DisplayAlert("Error", e.Message, "Ok");
            }

        });

    }
            private int ConvertToYear(string strDateTime)
    {
        int sdtFinaldate; string sDateTime;
        try
        {
            string[] sDate = strDateTime.Split('/');
            sDateTime = sDate[2] + '/' + sDate[1] + '/' + sDate[0];
            sdtFinaldate = Convert.ToInt32(sDate[0]);
        }
        catch (Exception e)
        {
            string[] sDate = strDateTime.Split('/');
            sDateTime = sDate[2] + '/' + sDate[1] + '/' + sDate[0];
            sdtFinaldate = Convert.ToInt32(sDate[0]);

        }
        return sdtFinaldate;
    }

}