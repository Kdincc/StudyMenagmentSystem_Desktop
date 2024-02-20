using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Task8.BL.Properties;

namespace Task8.Tests
{
    [TestClass]
    public class CsvErrorMessageBuilderTests
    {
        [TestMethod]
        public void GetExceptionMessage_IsCorrectMessage()
        {
            string headerName = "invalid";
            int headerIndex = 0;
            CsvContext csvContext = new(new CsvConfiguration(CultureInfo.InvariantCulture));
            InvalidHeader invalidHeader = new() { Names = new List<string> { headerName }, Index = headerIndex };
            InvalidHeader[] invalidHeaders = new InvalidHeader[1] { invalidHeader };
            HeaderValidationException headerValidationException = new(csvContext, invalidHeaders);
            string expected = $"{CsvErrorMessage.InvalidHeadersMessageBase}Header: {headerName} Index: {headerIndex}\n";
            string actual;

            actual = CsvErrorMessageBuilder.GetExceptionMessage(headerValidationException);

            Assert.AreEqual(expected, actual);
        }
    }
}
