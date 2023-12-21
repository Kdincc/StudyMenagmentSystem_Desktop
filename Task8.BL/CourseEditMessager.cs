using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.BL.Interfaces;

namespace Task8.BL
{
    public static class CourseEditMessager
    {
        public static void CantRemoveGroupMessage()
        {
            MessageBox.Show("A group can not be deleted if there is at least one student in this group.");
        }

        public static void CsvReadingErrorMessage()
        {
            MessageBox.Show("Csv file not in correct format !", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void EmptyGroupNameMessage()
        {
            MessageBox.Show("Group must have name !", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ReportCompleteMessage()
        {
            MessageBox.Show("Report is complete !");
        }

    }
}
