using static System.Net.Mime.MediaTypeNames;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiApp2;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Routing.RegisterRoute("integral", typeof(IntegralCalculationPage));
        MainPage = new AppShell();
    }
}
