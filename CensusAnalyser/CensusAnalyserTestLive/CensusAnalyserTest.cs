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
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyserLive.DTO.CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();            
        }
        [Test]
        public void GivenIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
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
    }
}
