using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.BL.Interfaces
{
    internal interface IDialogAware
    {
        bool CanCloseDialog();

        void OnDialogClosed();

        void OnDialogOpened(IDialogParameters parameters);

        string Title { get; set; }

        event Action<IDialogResult> RequestClose;
    }
}
