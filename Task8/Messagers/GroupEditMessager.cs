using System.Windows;
using Task8.Properties;

namespace Task8.Messagers
{
    public static class GroupEditMessager
    {
        public static void EmptyStudentNameMessage()
        {
            MessageBox.Show(Messages.EmptyStudentNameMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
