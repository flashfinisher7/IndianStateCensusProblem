using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProblem
{
    class IndianCensusAdapter
    {
        public class IndianCensusAdapter : CensusAdapter
        {
            string[] censusdata;
            Dictionary<string, CensusDTO> dataMap;

            public Dictionary<string, CensusDTO> LoadCensusData(string csvfilePath, string dataHeaders)
            {
                dataMap = new Dictionary<string, CensusDTO>();
                censusdata = GetCensusData(csvfilePath, dataHeaders);
                foreach (string data in censusdata.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException(StateCensusAnalyserException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                    }
                    string[] lines = data.Split(",");
                    //Check for correct file and call respective constructor and add into dictionary
                    if (csvfilePath.Contains("IndianStateCode.csv"))
                    {
                        dataMap.Add(lines[1], new CensusDTO(new CensusDataDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                    if (csvfilePath.Contains("IndianStateCwnsusData.csv"))
                    {
                        dataMap.Add(lines[0], new CensusDTO(new StateCodesDAO(lines[0], lines[1], lines[2], lines[3])));
                    }
                }
                return dataDict;
            }
        }
    }
}
