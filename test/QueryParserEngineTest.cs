using System;
using Xunit;
using System.IO;
using FluentAssertions;
using DbEngine.reader;
using DbEngine.query;

namespace test
{
    public class QueryParserEngineTest
    {
        #region Don't Try to Delete/Change the Logic Keep it as it is
        readonly string strtogetipldotcsv = "";
        readonly string rootdir = "";
        #endregion
        private readonly CsvQueryProcessor _reader;

        public QueryParserEngineTest()
        {
            #region Don't Try to Delete/Change the Logic Keep it as it is in Constructor
            var mydirectory = Environment.CurrentDirectory;
            int indexofmyvar = mydirectory.IndexOf("bin");
            string substr = mydirectory.Substring(0, indexofmyvar);
            if (substr.Contains("test"))
            {
                int testindex = substr.IndexOf("test");
                rootdir = substr.Substring(0, testindex);
                strtogetipldotcsv = rootdir + "data/ipl.csv";
            }
            this._reader = new CsvQueryProcessor(strtogetipldotcsv);
            #endregion
        }

        [Fact]
        public void TestRetrieveHeader()
        {
            Header result = _reader.GetHeader();
            string[] expectedHeaders = new string[] {
              "id", "season", "city", "date", "team1", "team2", "toss_winner", "toss_decision",
						  "result", "dl_applied", "winner", "win_by_runs", "win_by_wickets", "player_of_match", "venue",
						  "umpire1", "umpire2", "umpire3"
            };
            result.Headers.Should().NotBeNull();
            result.Headers.Should().BeEquivalentTo(expectedHeaders);
        }

        [Fact]
        public void TestRetrieveDataTypes()
        {
            DataTypeDefinitions result = _reader.GetColumnType();
            string[] expectedDataTypes = new string[] {
                "System.Int32", "System.Int32", "System.String", "System.String",
						"System.String", "System.String", "System.String", "System.String",
						"System.String", "System.Int32", "System.String", "System.Int32",
						"System.Int32", "System.String", "System.String", "System.String",
						"System.String", "System.String"
            };
            result.DataTypes.Should().BeEquivalentTo(expectedDataTypes);
        }

        [Fact]
        public void TestFileNotFound()
        {
            try
            {
                CsvQueryProcessor reader = new CsvQueryProcessor(strtogetipldotcsv);
            }
            catch (Exception exception)
            {
                exception.GetType().ToString().Should().Be("System.IO.FileNotFoundException");
            }
        }
    }
}