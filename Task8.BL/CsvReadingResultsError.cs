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
        private readonly HeaderValidationException _headerValidationException;

        public CsvReadingResultsError(HeaderValidationException ex)
        {
            _headerValidationException = ex;
        }

        public string Message => CsvErrorMessageBuilder.HeaderValidationMessage(_headerValidationException);
    }
}
