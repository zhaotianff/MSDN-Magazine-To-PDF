using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using MSDN_Magazine_To_PDF.Views;
using MSDN_Magazine_To_PDF.ViewModels;

namespace MSDN_Magazine_To_PDF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
