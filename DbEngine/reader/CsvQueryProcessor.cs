using System.IO;
using DbEngine.query;

namespace DbEngine.reader
{
    public class CsvQueryProcessor: QueryProcessingEngine
    {
        private readonly string _fileName;
        private StreamReader _reader;

        // Parameterized constructor to initialize filename
        public CsvQueryProcessor(string fileName)
        {
        }

        /*
	    Implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
	    Note: Return type of the method will be Header
	    */
        public override Header GetHeader()
        {
            // read the first line
            // populate the header object with the String array containing the header names
            return null;
        }

        /*
	    Implementation of getColumnType() method. To find out the data types, we will
	    read the first line from the file and extract the field values from it. If a
	    specific field value can be converted to Integer, the data type of that field
	    will contain "System.Int32", otherwise if it can be converted to Double,
	    then the data type of that field will contain "System.Double", otherwise,
	    the field is to be treated as String. 
	     Note: Return Type of the method will be DataTypeDefinitions
	 */
        public override DataTypeDefinitions GetColumnType() 
        {
           return null;
        }

         //getDataRow() method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}