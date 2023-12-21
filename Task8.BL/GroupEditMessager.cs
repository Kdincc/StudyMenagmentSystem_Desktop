using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Task8.BL.Properties;

namespace Task8.BL
{
    public static class GroupEditMessager
    {
        public static void EmptyStudentNameMessage() 
        {
            MessageBox.Show(Messages.EmptyStudentNameMessage, "", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
