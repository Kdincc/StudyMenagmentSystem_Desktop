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
