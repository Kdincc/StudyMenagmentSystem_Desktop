using CsvHelper;
using System;
using System.Text;
using Task8.BL.Properties;

namespace Task8.BL
{
    public static class CsvErrorMessageBuilder
    {
        public static string GetExceptionMessage(HeaderValidationException exception)
        {
            ArgumentNullException.ThrowIfNull(exception);

            string messageBase = CsvErrorMessage.InvalidHeadersMessageBase;
            StringBuilder message = new(messageBase);

            foreach (InvalidHeader header in exception.InvalidHeaders)
            {
                foreach (string headerName in header.Names)
                {
                    message.Append($"Header: {headerName} Index: {header.Index}\n");
                }
            }

            return message.ToString();
        }
    }
}
