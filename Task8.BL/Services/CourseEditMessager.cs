using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.BL.Interfaces;

namespace Task8.BL
{
    public class CourseEditMessager : ICourseEditMessager
    {
        public void CantRemoveGroupMessage()
        {
            MessageBox.Show("A group can not be deleted if there is at least one student in this group.");
        }

        public void CsvReadingErrorMessage()
        {
            MessageBox.Show("Csv file not in correct format !", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void EmptyGroupNameMessage()
        {
            MessageBox.Show("Group must have name !", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ReportCompleteMessage()
        {
            MessageBox.Show("Report is complete !");
        }

    }
}
