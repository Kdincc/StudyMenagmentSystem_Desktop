using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.ViewModels;
using Task8.Views;

namespace Task8
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();

            region.RegisterViewWithRegion(RegionNames.ContentRegion.ToString(), nameof(Home));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Home>();
            containerRegistry.RegisterForNavigation<CourseEdit>();
            containerRegistry.RegisterForNavigation<GroupEdit>();
        }
    }

    public enum RegionNames
    {
        ContentRegion,
        ToolBarRegion
    }
}
