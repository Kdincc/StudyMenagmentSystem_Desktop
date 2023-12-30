using Prism.Commands;
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
    public class InfoDialogViewModel : BindableBase, IDialogAware
    {
        private string _infoImage;

        public InfoDialogViewModel()
        {
            CloseCommand = new(CloseDialog);
        }

        public string InfoImage
        {
            get { return _infoImage; }
            set { SetProperty(ref _infoImage, value); }
        }

        public string Title => "Info";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand CloseCommand { get; }

        private void CloseDialog()
        {
            ButtonResult result = ButtonResult.None;

            RaiseRequestClose(new DialogResult(result));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            InfoImage = parameters.GetValue<string>("Image");
        }

        public void RaiseRequestClose(IDialogResult result)
        {
            RequestClose.Invoke(result);
        }
    }
}
