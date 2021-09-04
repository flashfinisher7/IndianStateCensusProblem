using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusProblem.DTO;

namespace IndianStateCensusProblem
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilepath, string dataHeaders)
        {
            switch (country)
            {
                //Check countries
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvfilepath, dataHeaders);
                case (CensusAnalyser.Country.US):
                    return new USCensusAdapter().LoadUSCensusData(csvpath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No such country present",CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
