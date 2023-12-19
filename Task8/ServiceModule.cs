using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.BL.Services;
using Task8.BL;

namespace Task8
{
    public class ServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDocxService, DocxService>();
            containerRegistry.Register<IPDFService, PDFService>();
            containerRegistry.Register<ICsvService, CsvService>();
            containerRegistry.RegisterSingleton<IRepositoryService, RepositoryService>();
            containerRegistry.Register<ICourseEditMessager, CourseEditMessager>();
        }
    }
}
