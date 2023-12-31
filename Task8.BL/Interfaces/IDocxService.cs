using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IDocxService
    {
        public void WriteGroupReport(string savePath, GroupReport report);
    }
}
