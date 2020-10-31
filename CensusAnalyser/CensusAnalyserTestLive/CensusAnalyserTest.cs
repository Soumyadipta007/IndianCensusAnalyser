using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyserLive;
using CensusAnalyserLive.POCO;
using CensusAnalyserLive.DTO;
using NUnit.Framework;
using static CensusAnalyserLive.DTO.CensusAnalyzer;

namespace CensusAnalyserTestLive
{
    public class CensusAnalyserTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";        
        static string indianStateCensusFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCensusData.csv";        
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCensusData.txt";
        CensusAnalyserLive.DTO.CensusAnalyzer censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCode.txt";        
        static string delimiterIndianStateCodeFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\User\source\repos\CensusAnalyser\CensusAnalyserTestLive\CSVFiles\WrongIndiaStateCode.csv";
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyserLive.DTO.CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenWrongFilePathThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }            
        }
        [Test]
        public void GivenWrongStateCodeFilePathThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenWrongFileTypeThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenWrongStateCodeFileTypeThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenWrongFileDelimiterThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenWrongStateCodeFileDelimiterThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenWrongFileHeaderThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
        [Test]
        public void GivenWrongStateCodeFileHeaderThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}
