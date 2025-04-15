using System.Threading;
using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnNavigateToIntegralCalculation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MauiApp2.IntegralCalculationPage());
        }
    }
}
