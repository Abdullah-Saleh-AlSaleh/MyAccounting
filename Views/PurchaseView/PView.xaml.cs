using MyAccounting.Data;

namespace MyAccounting.Views.PurchaseView;

public partial class PView : ContentPage
{
    private Database db = new();
    public PView()
	{
		InitializeComponent();
      

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        try
        {
         
            var GetPurchase = await db.GetPurchase();
            
            MainThread.BeginInvokeOnMainThread(() =>
            {
                 var Total1 = GetPurchase.Where(t => ConvertToYear(t.Date.Replace("-", "/")) == DateTime.Now.Year).Sum(tos => tos.Total_Value).ToString();
                var Total2 = GetPurchase.Select(t => t.Total_Value).Sum().ToString();
                PurchaseTotal1.Text = " ≈Ã„«·Ì «·„‘ —Ì«  Œ·«· «·⁄«„ " + DateTime.Now.Year.ToString() + " : " + Total1 + "—Ì«· ";
                PurchaseTotal2.Text = " ≈Ã„«·Ì «·„‘ —Ì«   : " + Total2 + "—Ì«· ";

            });
        }
        catch (Exception e)
        {

            await DisplayAlert("Error", e.Message, "Ok");
        }

    }

    private async void PDetailsClicked(object sender, EventArgs e)
    {
        var model = new Data.Database();
        //   await Navigation.PushAsync(new STotal(model));
        //await Shell.Current.GoToAsync(nameof(PDetails));
        await Shell.Current.GoToAsync(nameof(PDetails));

    }
    async void GetDataPurchase()
    {
        try
        {
            var Get = await db.GetPurchase();
            var Total1 = Get.Where(t => ConvertToYear(t.Date.Replace("-", "/")) == DateTime.Now.Year).Sum(tos => tos.Total_Value).ToString();
            var Total2 = Get.Select(t => t.Total_Value).Sum().ToString();
            PurchaseTotal1.Text = " ≈Ã„«·Ì «·„‘ —Ì«  Œ·«· «·⁄«„ " + DateTime.Now.Year.ToString() + " : " + Total1 + "—Ì«· ";
            PurchaseTotal2.Text = " ≈Ã„«·Ì «·„‘ —Ì«   : " + Total2 + "—Ì«· ";
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

}