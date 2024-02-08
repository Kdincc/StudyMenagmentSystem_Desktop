using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.Properties;

namespace Task8.Messagers
{
    public static class MainWindowMessager
    {
        public static void ShowAppInfoMessage()
        {
            MessageBox.Show(Messages.AppInfoMessage);
        }
    }
}
