using Microsoft.Extensions.Logging;
using MyAccounting.Data;
using MyAccounting.Models;
using MyAccounting.ViewModel;
using MyAccounting.Views;
using MyAccounting.Views.ExpenseView;
using MyAccounting.Views.PurchaseView;
using MyAccounting.Views.SalesView;

namespace MyAccounting
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<About>();
            //Views  Sales
            builder.Services.AddTransient<SAdd>();

            builder.Services.AddSingleton<SDetails>();
            builder.Services.AddSingleton<SView>();
            //Views  Purchase
            builder.Services.AddTransient<PAdd>();
            builder.Services.AddSingleton<PDetails>();
            builder.Services.AddSingleton<PView>();
            //Views  Expense Pages
            builder.Services.AddTransient<EAdd>();
            builder.Services.AddTransient<EDetailsPage>();
            builder.Services.AddSingleton<EDetails>();
            builder.Services.AddSingleton<ViewPage>();
            //End
            builder.Services.AddSingleton<DataViewModel>();
            //  builder.Services.AddSingleton<LoadingPageViewModel>();
            //End
            builder.Services.AddSingleton<Database>();
            builder.Services.AddSingleton<Person>();
            builder.Services.AddSingleton<Sales>();
            builder.Services.AddSingleton<Purchase>();
            builder.Services.AddSingleton<Expense>();
            builder.Services.AddSingleton<ExpenseTotal>();

            return builder.Build();
        }
    }
}
