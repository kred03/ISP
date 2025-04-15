namespace MauiApp2
{
    public partial class IntegralCalculationPage : ContentPage
    {
        public CancellationTokenSource _cancellationTokenSource;
        private bool _isComputing = false; 

        public IntegralCalculationPage()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async void OnStartComputation(object sender, EventArgs e)
        {
            BtnStart.IsEnabled = false;
           // if (_isComputing)
            //{
             //   Console.WriteLine("Вычисления уже выполняются.");
               // StatusLabel.Text = "Вычисления уже выполняются !!!!!!Ц";
                //return;
            //}

            Console.WriteLine("OnStartComputation start");

            try
            {
                //_isComputing = true; 

                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();

                StatusLabel.Text = "Вычисление...";
                ComputationProgressBar.Progress = 0;
                ProgressLabel.Text = "0%";

                double result = await Task.Run(()=>IntegralComputation.CalculateAsync(this, _cancellationTokenSource.Token));

                StatusLabel.Text = $"Результат: {result:F6}";
            }
            catch (OperationCanceledException)
            {
                StatusLabel.Text = "Вычисления отменены";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Error: {ex.Message}";
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                BtnStart.IsEnabled=true;
            }
        }

        public void OnCancelComputation(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();

            StatusLabel.Text = "Вычисления отменены";
            ComputationProgressBar.Progress = 0;
            ProgressLabel.Text = "0%";
        }

        public void UpdateProgressBar(double progress)
        {
            ComputationProgressBar.Progress = progress;
        }

        public void UpdateProgressLabel(string text)
        {
            ProgressLabel.Text = text;
        }
    }
}