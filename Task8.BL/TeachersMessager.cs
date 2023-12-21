using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task8.BL
{
    public static class TeachersMessager
    {
        public static void EmptyTeacherNameMessage()
        {
            MessageBox.Show("Name and surname of the teacher can`t be empty !", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
