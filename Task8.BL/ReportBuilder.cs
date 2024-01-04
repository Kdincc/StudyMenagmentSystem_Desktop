using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public static class ReportBuilder
    {
        public static GroupReport BuildGroupReport(Group group) 
        {
            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            return new GroupReport(group.Course.Name, group.Name, group.Students.ToList());
        }
    }
}
