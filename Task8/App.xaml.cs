using Prism.Ioc;
using System.Windows;
using Task8.BL;
using Task8.BL.Interfaces;
using Task8.BL.Models;
using Task8.Data.Data;
using Task8.Views;

namespace Task8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICourseRepository, CourseRepository>();
            containerRegistry.Register<Task6Context>();
            containerRegistry.Register<IHomeModel, HomeModel>();
            containerRegistry.Register<ICourseEditModel, CourseEditModel>();
        }
    }
}
