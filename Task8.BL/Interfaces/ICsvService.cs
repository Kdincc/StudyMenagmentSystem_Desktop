using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ICsvService
    {
        public CsvReadingResults<Student> GetStudentsFrom(string path);

        public void WriteStudentsTo(IEnumerable<Student> students, string path);
    }
}
