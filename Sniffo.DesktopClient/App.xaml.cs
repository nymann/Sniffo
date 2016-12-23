using Sniffo.DesktopClient.ViewModels;
using Sniffo.DesktopClient.Views;
using System.Windows;

namespace Sniffo.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Overrides of Application

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow()
            {
                DataContext = new CustomerViewModel()
            };

            window.ShowDialog();
        }

        #endregion
    }
}