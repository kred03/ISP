using Microsoft.Maui.Controls;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MauiApp2
{
    public static class IntegralComputation
    {
        public static async Task<double> CalculateAsync(IntegralCalculationPage page, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                
                try
                {
                    double a = 0, b = 1;
                    double step = 0.00000001;
                    double sum = 0;
                    int totalSteps = (int)((b - a) / step);
                    int updateFrequency = Math.Max(1, totalSteps / 100); 

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    for (int i = 0; i < totalSteps; i++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            throw new OperationCanceledException();

                        double x = a + i * step;
                        sum += Math.Sin(x) * step;

                        if (i % updateFrequency == 0)
                        {
                            double progress = (double)i / totalSteps;

                            //MainThread.BeginInvokeOnMainThread(() =>
                            {
                                page?.UpdateProgressBar(progress);
                                page?.UpdateProgressLabel($"{(progress * 100):F0}%");
                            };
                        }
                    }

                    stopwatch.Stop();
                    Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
                    return sum;
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Computation was cancelled.");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in calculation: {ex.Message}");
                    throw;
                }
            }, cancellationToken);
        }
    }
}

