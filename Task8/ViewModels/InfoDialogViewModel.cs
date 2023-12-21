using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;

namespace Task8.ViewModels
{
    public class InfoDialogViewModel : BindableBase
    {
        private readonly IInfoDialog _infoDialog;

        public InfoDialogViewModel(IInfoDialog infoDialog)
        {
            _infoDialog = infoDialog;
        }

        public Bitmap HomePageInfoImage => _infoDialog.HomePageInfoImage;
    }
}
