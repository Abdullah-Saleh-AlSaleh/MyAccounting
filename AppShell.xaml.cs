using MyAccounting.Views.ExpenseView;
using MyAccounting.Views.PurchaseView;
using MyAccounting.Views.SalesView;

namespace MyAccounting
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SAdd), typeof(SAdd));
            Routing.RegisterRoute(nameof(PAdd), typeof(PAdd));
            Routing.RegisterRoute(nameof(EAdd), typeof(EAdd));
            Routing.RegisterRoute(nameof(PDetails), typeof(PDetails));
            Routing.RegisterRoute(nameof(SDetails), typeof(SDetails));
            Routing.RegisterRoute(nameof(EDetails), typeof(EDetails));
            Routing.RegisterRoute(nameof(EDetailsPage), typeof(EDetailsPage));

        }
    }
}
