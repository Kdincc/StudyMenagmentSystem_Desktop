using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Properties;

namespace Task8.BL
{
    public static class CsvErrorMessageBuilder
    {
        public static string HeaderValidationMessage(HeaderValidationException exception)
        {
            StringBuilder message = new(Messages.CsvReadingErrorMessage);

            foreach (InvalidHeader header in exception.InvalidHeaders)
            {
                foreach (string headerName in header.Names)
                {
                    message.Append($"Header: {headerName}, Index: {header.Index}\n");
                }
            }

            return message.ToString();
        }
    }
}
