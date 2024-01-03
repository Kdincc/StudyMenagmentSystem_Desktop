using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.BL
{
    public class CsvReadingResultsError
    {
		private readonly string _message;

        public string Message => _message;

        public CsvReadingResultsError(HeaderValidationException ex)
        {
            _message = CsvErrorMessageBuilder.HeaderValidationMessage(ex);
        }
    }
}
