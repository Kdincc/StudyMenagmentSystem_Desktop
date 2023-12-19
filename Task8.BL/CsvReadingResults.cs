using CsvHelper;
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

        public CsvReadingResults(List<T> records)
        {
            _records = records;
        }

        public CsvReadingResults(List<T> records, CsvHelperException error)
        {
            _records = records;

            Error = error;
        }

        public IEnumerable<T> Records => _records;

        public CsvHelperException Error { get; }
    }
}
