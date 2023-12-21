using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.BL.Interfaces;
using Task8.BL.Properties;

namespace Task8.BL
{
    public static class CourseEditMessager
    {
        public static void CantRemoveGroupMessage()
        {
            MessageBox.Show(Messages.CantRemoveGroupMessage);
        }

        public static void CsvReadingErrorMessage()
        {
            MessageBox.Show(Messages.CsvReadingErrorMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void EmptyGroupNameMessage()
        {
            MessageBox.Show(Messages.EmptyGroupNameMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ReportCompleteMessage()
        {
            MessageBox.Show(Messages.ReportCompleteMessage);
        }

    }
}
