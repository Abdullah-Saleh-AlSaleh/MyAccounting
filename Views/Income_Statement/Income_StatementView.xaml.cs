
using MyAccounting.Data;
using MyAccounting.Models;
using System.Globalization;

namespace MyAccounting.Views.Income_Statement;

public partial class Income_StatementView : ContentPage
{
    private Database db = new();
    public Income_StatementView()
	{
		InitializeComponent();
		//GetDataIncome_State();

    }
	async void GetDataIncome_State()
	{
	
        try
		{
            var GetSales = await db.GetSales();
			var GetPurchase = await db.GetPurchase();
			var GetExpense = await db.GetExpense();
		//	var Getw = GetExpense.Where<Expense>(e => e.Statement == "≈ÌÃ«—" || e.Statement == "");
		
            double TProfitLoss = GetSales.Sum(S => S.Total_Value) - GetExpense.Sum(P => P.Total_Value);
			double ReturnOnInvestment = TProfitLoss / GetPurchase.Sum(S => S.Total_Value) * 100;
            TotalSales.Text = " ≈Ã„«·Ì «·„»Ì⁄«  : " + GetSales.Sum(S => S.Total_Value).ToString() + " —Ì«· ";
            TotalPurchase.Text = " ≈Ã„«·Ì «·„‘ —Ì«  : " +GetPurchase.Sum(P => P.Total_Value).ToString() + " —Ì«· ";
            TotalExpense.Text = " ≈Ã„«·Ì «·„’—Ê›«  : " + GetExpense.Sum(P => P.Total_Value).ToString() + " —Ì«· ";
            ProfitLoss.Text = " «·—»Õ/«·Œ”«—… : " + Convert.ToString(TProfitLoss) + " —Ì«· ";
            ReturnOnInvestmentRatio.Text =  "‰”»… «·⁄«∆œ ⁄·Ï «·«” À„«— : " + Convert.ToString(Math.Round(ReturnOnInvestment))+ "%";
        }
        catch (Exception ex)
		{

			await DisplayAlert("Œÿ√", ex.Message, "„Ê«›ﬁ");
		}
	}
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
       try
		{
            var items = await db.GetExpense();

            var GetSales = await db.GetSales();
            var GetPurchase = await db.GetPurchase();
            var GetExpense = await db.GetExpense();
            CultureInfo CurrentCulture = CultureInfo.GetCultureInfo("ar-AE");
            MainThread.BeginInvokeOnMainThread(() =>
            {
                //	var Getw = GetExpense.Where<Expense>(e => e.Statement == "≈ÌÃ«—" || e.Statement == "");

                double TProfitLoss = GetSales.Sum(S => S.Total_Value) - GetExpense.Sum(P => P.Total_Value);
                double TProfitLossYesrs = GetSales.Where(S => ConvertToYear(S.Date.Replace("-", "/")) == Convert.ToInt32(DateTime.Now.ToString("yyyy", CurrentCulture))).Sum(P => P.Total_Value) -
                GetExpense.Where(S => ConvertToYear(S.Date.Replace("-", "/")) == Convert.ToInt32(DateTime.Now.ToString("yyyy", CurrentCulture))).Sum(E => E.Total_Value);
                double ReturnOnInvestment = TProfitLoss / GetPurchase.Sum(S => S.Total_Value) * 100;       
                double ReturnOnInvestment1 = TProfitLossYesrs / GetPurchase.Sum(S => S.Total_Value) * 100;
                 TotalSales.Text = " ≈Ã„«·Ì «·„»Ì⁄«  : " + GetSales.Sum(S => S.Total_Value).ToString() + " —Ì«· ";
                 TotalPurchase.Text = " ≈Ã„«·Ì «·„‘ —Ì«  : " + GetPurchase.Sum(P => P.Total_Value).ToString() + " —Ì«· ";
                TotalExpense.Text = " ≈Ã„«·Ì «·„’—Ê›«  : " + GetExpense.Sum(P => P.Total_Value).ToString() + " —Ì«· ";
                ProfitLoss.Text = " «·—»Õ/«·Œ”«—… : " + Convert.ToString(TProfitLoss) + " —Ì«· ";
                
                ReturnOnInvestmentRatio.Text = "‰”»… «·⁄«∆œ ⁄·Ï «·«” À„«— Œ·«· Â–« «·⁄«„ "+DateTime.Now.ToString("yyyy", CurrentCulture) +" : " + Convert.ToString(Math.Round(ReturnOnInvestment)) + "%";
                ReturnOnInvestmentRatio1.Text = "‰”»… «·⁄«∆œ ⁄·Ï «·«” À„«—   : " + Convert.ToString(Math.Round(ReturnOnInvestment1)) + "%";

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

}