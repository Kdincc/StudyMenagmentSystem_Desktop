using CsvHelper;
using System;
using System.Collections.Generic;

namespace Task8.BL
{
    public class CsvReadingResults<T>
    {
        private readonly List<T> _records;
        private readonly CsvReadingResultsError _error;
        private readonly bool _isInvalid;

        public CsvReadingResults(List<T> records)
        {
            _records = records;
            _isInvalid = false;
        }

        public CsvReadingResults(List<T> records, HeaderValidationException ex)
        {
            _records = records;
            _isInvalid = true;
            _error = new(ex);
        }

        public IEnumerable<T> Records => _records;

        public bool IsInvalid => _isInvalid;

        public CsvReadingResultsError Error => _error;
    }
}
