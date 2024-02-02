using System;
using System.Linq;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public static class ReportBuilder
    {
        public static GroupReport BuildGroupReport(Group group)
        {
            ArgumentNullException.ThrowIfNull(group, nameof(group));

            return new GroupReport(group.Course.Name, group.Name, group.Students.ToList());
        }
    }
}
