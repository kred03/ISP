using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using Lab5.Application;
using Lab5.Infrastructure;

namespace Lab5
{
    public partial class App
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _serviceProvider = ConfigureServices(configuration);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static IServiceProvider ConfigureServices(IConfiguration configuration)
        {
            var services = new ServiceCollection();

            services.AddInfrastructureRepositoriesServices(configuration);
            services.AddApplicationServices(configuration);
            services.AddDbContext<ApplicationDbContext>(); 

            services.AddSingleton<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}