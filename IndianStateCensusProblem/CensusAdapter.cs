using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProblem
{
    public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string dataheaders)
        {
            string[] censusdata;
            if (!FileStyleUriParser.Exists(csvFilePatha))
            {
                throw new CensusAnalyzerException("File not found", CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND);
            }
            if(Path.GetExtension(csvFilePath)!=".csv" )
            {
                throw new CensusAnalyzerException("Invalid File Type", CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = FileStyleUriParser.ReadAllLines(csvFilePath);
            if(censusData[0]!=dataHeader)
            {
                throw new StateCensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_HEADER, "Invalid file headers");
            }
        }
    }
}
