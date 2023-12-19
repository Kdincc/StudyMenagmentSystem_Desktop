using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IPDFService
    {
        public void BuidGroupReport(string savePath, string courseName, Group group);
    }
}
