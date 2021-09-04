using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusProblem
{
    public class CensusAnalyzerException
    {
        public class CensusAnalyzer : Exception
        {
            public enum ExceptionType
            {
                FILE_NOT_FOUND, INVALID_FILE_TYPE, INVALID_HEADER, INVALID_DELIMITER, NO_SUCH_COUNTRY
            }
            public ExceptionType eType;
            public CensusAnalyzerException(string message, ExceptionType exceptionType) : base(message) => this.eType = exceptionType;
        }
    }
}
