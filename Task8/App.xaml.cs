using NPOI.XWPF.UserModel;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Task8.BL;
using Task8.BL.Interfaces;
using Task8.BL.Models;
using Task8.BL.Services;
using Task8.Data;
using Task8.Data.Data;
using Task8.ViewModels;
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
            containerRegistry.Register<Task6Context>();
            containerRegistry.Register<IHomeModel, HomeModel>();
            containerRegistry.Register<ICourseEditModel, CourseEditModel>();
            containerRegistry.Register<IGroupEditModel, GroupEditModel>();
            containerRegistry.Register<ITeachersModel, TeachersModel>();
            containerRegistry.Register<IDocxService, DocxService>();
            containerRegistry.Register<IPdfService, PdfService>();
            containerRegistry.Register<ICsvService, CsvService>();
            containerRegistry.Register<IDocumentHelper<iText.Layout.Document>, PdfHelper>();
            containerRegistry.Register<IDocumentHelper<XWPFDocument>, DocxHelper>();
            containerRegistry.RegisterSingleton<IRepository, Repository>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<NavigationModule>();
        }
    }
}
