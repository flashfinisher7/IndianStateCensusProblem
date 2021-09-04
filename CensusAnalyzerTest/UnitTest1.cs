using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CensusAnalyzerTest
{
    public class Tests
    {
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public static string indianStateCensusFilePath = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\IndiaStateCode.csv";
        public static string wrongHeaderIndianCensusFile = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\WrongIndiaStateCensusData.csv";
        public static string wrongHeaderIndianStateCode = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\WrongIndiaStateCode.csv";
        public static string wrongIndianStateCensusFilePath = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles1\WrongIndiaStateCensusData.csv";
        public static string wrongIndianStateCensusFileType = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\IndiaStateCode.txt";
        public static string wrongIndianStateCodeFilePath = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles1\WrongIndiaStateCode.csv";
        public static string wrongIndianStateCodeFiletype = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\IndiaStateCode.txt";
        public static string delimeterIndianStateCodeFilePath = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\DelimiterIndiaStateCode.csv";
        public static string delimeterIndianCensusCodeFilePath = @"C:\Users\HP\source\repos\IndiaCensusDataDemo\CSVFiles\DelimiterIndiaStateCensusData.csv";


        CensusAnalyser censusAnalyser;

        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        /// <summary>
        /// Test Case 1.1
        /// Getting the count of data in IndiaStateCensusData
        /// </summary>

        [Test]
        public void GivenIndianCensusDataFile_WhenReturnShouldReturnCensusDataCount()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            //assert
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(29, totalRecord.Count);
        }
        /// <summary>
        /// Given the State Census CSV File if incorrect Returns a custom Exception
        /// </summary>
        /// TC1.2
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReadedShouldReturnCustomException()
        {
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianCensusResult.exception);
        }
        /// <summary>
        /// TC 1.3
        /// Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataType_WhenReadedShouldReturnCustomException()
        {
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianCensusResult.exception);
        }
        /// <summary>
        /// TC 1.4
        /// Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileTypeDelimeter()
        {
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianCensusCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, indianCensusResult.exception);
        }
        /// <summary>
        /// TC 1.5
        /// Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataHeadersCustomExcep()
        {
            var indianCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, indianCensusResult.exception);
        }
        /// <summary>
        /// Test Case 2.1
        /// Getting the count of data in IndiaStateCodeData
        /// </summary>
        [Test]
        public void GivenIndianCodeDataFile_WhenReturnShouldReturnCodeCount()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            //assert
            //total no of rows excluding header are 37 in indian state census data.
            Assert.AreEqual(37, stateRecord.Count);
        }
        /// <summary>
        /// checking the program for incorrect file name which do not exist
        /// test case 2.2
        /// </summary>
        [Test]
        public void GivenWrongIndianCodeDataFile_WhenReadedShouldReturnCustomException()
        {
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, stateResult.exception);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file type which do not exist
        /// test case 2.3
        /// </summary>
        public void GivenWrongIndianCodeDataType_WhenReadedShouldReturnCustomException()
        {
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFiletype, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, stateResult.exception);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect delimiter is passed
        /// test case 2.4
        /// </summary>
        public void GivenIncorrectDelimiterForCodeData_WhenReadedShouldReturnCustomException()
        {
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, stateResult.exception);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect header is passed
        /// test case 2.5
        /// </summary>
        public void GivenIncorrectHeaderForCodeData_WhenReadedShouldReturnCustomException()
        {
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCode, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, stateResult.exception);
        }
    }
}