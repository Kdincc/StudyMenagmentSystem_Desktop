using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface IDocumentHelper<T>
    {
        public void BuildHeader(T document, string text, int fontSize, DocumentFont font, bool isBold = false);

        public void BuildStudentList(T document, int fontSize, DocumentFont font, ICollection<Student> students, bool isBold = false);
    }
}
