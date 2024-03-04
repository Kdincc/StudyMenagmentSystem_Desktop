using System.Windows;
using Task8.Properties;

namespace Task8.Messagers
{
    public static class TeachersMessager
    {
        public static void EmptyTeacherNameMessage()
        {
            MessageBox.Show(Messages.EmptyTeacherNameMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
