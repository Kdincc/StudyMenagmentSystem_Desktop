using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.BL.Interfaces
{
    public interface ICourseEditMessager
    {
        public void CantRemoveGroupMessage();

        public void ReportCompleteMessage();

        public void CsvReadingErrorMessage();

        public void EmptyGroupNameMessage();
    }
}
