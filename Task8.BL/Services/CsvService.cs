using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class CsvService : ICsvService
    {
        public CsvReadingResults<Student> GetStudentsFrom(string path)
        {
            ArgumentNullException.ThrowIfNull(path, nameof(path));

            using (StreamReader streamReader = new(path))
            {
                using (CsvReader csvReader = new(streamReader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        var students = csvReader.GetRecords<Student>().ToList();

                        return new CsvReadingResults<Student>(students);
                    }
                    catch (HeaderValidationException ex)
                    {
                        return new CsvReadingResults<Student>(new List<Student>(), ex);
                    }
                }
            }
        }

        public void WriteStudentsTo(IEnumerable<Student> students, string path)
        {
            ArgumentNullException.ThrowIfNull(students, nameof(students));
            ArgumentNullException.ThrowIfNull(path, nameof(path));

            using (StreamWriter streamWriter = new(path))
            {
                using (CsvWriter csvWriter = new(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(students);
                }
            }
        }
    }
}
