using CsvHelper;

namespace Task8.BL
{
    public class CsvReadingResultsError
    {
        private readonly HeaderValidationException _headerValidationException;

        public CsvReadingResultsError(HeaderValidationException ex)
        {
            _headerValidationException = ex;
        }

        public string Message => CsvErrorMessageBuilder.GetExceptionMessage(_headerValidationException);
    }
}
