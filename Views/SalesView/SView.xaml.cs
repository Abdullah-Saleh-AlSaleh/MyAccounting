using MyAccounting.Data;
namespace MyAccounting.Views.SalesView;

public partial class SView : ContentPage
{

   private Database db = new();
	public SView()
	{
		InitializeComponent();
       

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        try
        {

            var GetSales = await db.GetSales();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                var Total1 = GetSales.Where(t => ConvertToYear(t.Date.Replace("-", "/")) == DateTime.Now.Year).Sum(tos => tos.Total_Value).ToString();
                var Total2 = GetSales.Select(t => t.Total_Value).Sum().ToString();
                SalesTotal1.Text = "  ≈Ã„«·Ì «·„»Ì⁄«  Œ·«· «·⁄«„ " + DateTime.Now.Year.ToString() + " : " + Total1 + "—Ì«· ";
                SalesTotal2.Text = " ≈Ã„«·Ì «·„»Ì⁄«   : " + Total2 + "—Ì«· ";

            });
        }
        catch (Exception e)
        {

            await DisplayAlert("Error", e.Message, "Ok");
        }

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


    private async void STotalClicked(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync(nameof(SDetails));
        
    }
}