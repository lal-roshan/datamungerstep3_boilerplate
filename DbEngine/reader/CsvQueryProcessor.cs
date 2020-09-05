using System.Collections.Generic;
using System.IO;
using System.Linq;
using DbEngine.query;

namespace DbEngine.reader
{
    public class CsvQueryProcessor : QueryProcessingEngine
    {
        private readonly string _fileName;
        private StreamReader _reader;

        // Parameterized constructor to initialize filename
        public CsvQueryProcessor(string fileName)
        {
            this._fileName = fileName;
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
            if (File.Exists(_fileName))
            {
                using (_reader = new StreamReader(_fileName))
                {
                    string headerRow = _reader.ReadLine();
                    if (!string.IsNullOrEmpty(headerRow))
                    {
                        Header header = new Header();
                        header.Headers = headerRow.Split(',').Select(x => x.Trim()).ToArray();
                        return header;
                    }
                }
            }
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
            if (File.Exists(_fileName))
            {
                using (_reader = new StreamReader(_fileName))
                {
                    _reader.ReadLine();
                    string firstDataRow = _reader.ReadLine();
                    if (!string.IsNullOrEmpty(firstDataRow))
                    {
                        int intValue = 0;
                        double doubleValue = 0;
                        List<string> dataTypes = new List<string>();
                        DataTypeDefinitions dataTypeDefinitions = new DataTypeDefinitions();
                        foreach(string field in firstDataRow.Split(','))
                        {
                            if(int.TryParse(field, out intValue))
                            {
                                dataTypes.Add(typeof(System.Int32).ToString());
                            }
                            else if(double.TryParse(field, out doubleValue))
                            {
                                dataTypes.Add(typeof(System.Double).ToString());
                            }
                            else
                            {
                                dataTypes.Add(typeof(System.String).ToString());
                            }
                        }
                        dataTypeDefinitions.DataTypes = dataTypes.ToArray();
                        return dataTypeDefinitions;
                    }
                }
            }
            return null;
        }

        //getDataRow() method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}