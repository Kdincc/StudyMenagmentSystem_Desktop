using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task8.BL
{
    public static class GroupEditMessager
    {
        public static void EmptyStudentNameMessage() 
        {
            MessageBox.Show("Name and surname of the student can`t be empty !", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
