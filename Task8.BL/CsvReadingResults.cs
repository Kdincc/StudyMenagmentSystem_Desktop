using CsvHelper;
using ICSharpCode.SharpZipLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CsvReadingResultsError Error 
        {
            get 
            {
                if(IsInvalid)
                {
                    return _error;
                }

                throw new InvalidOperationException("Cant get the error if results is valid");
            } 
        }
    }
}
