using DbEngine.query;

namespace DbEngine.reader
{
    /*
     Abstract class containing three abstract methods that should be implemented 
    in CsvQueryProcessor class
    */
    public abstract class QueryProcessingEngine{
        public abstract Header GetHeader();
        public abstract void GetDataRow();
        public abstract DataTypeDefinitions GetColumnType();
    }
}