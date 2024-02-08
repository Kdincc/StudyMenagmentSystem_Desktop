using System.Windows;
using Task8.Properties;

namespace Task8.Messagers
{
    public static class CourseEditMessager
    {
        public static void ShowCantRemoveGroupMessage()
        {
            MessageBox.Show(Messages.CantRemoveGroupMessage);
        }

        public static void ShowCsvReadingErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowEmptyGroupNameMessage()
        {
            MessageBox.Show(Messages.EmptyGroupNameMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowReportCompleteMessage()
        {
            MessageBox.Show(Messages.ReportCompleteMessage);
        }

    }
}
