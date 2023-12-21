using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.BL.Properties;

namespace Task8.BL
{
    public static class TeachersMessager
    {
        public static void EmptyTeacherNameMessage()
        {
            MessageBox.Show(Messages.EmptyTeacherNameMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
