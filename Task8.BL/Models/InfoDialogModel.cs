using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.BL.Properties;

namespace Task8.BL.Models
{
    public class InfoDialogModel : IInfoDialog
    {
        public Bitmap HomePageInfoImage => Images.HomePageInfo;
    }
}
