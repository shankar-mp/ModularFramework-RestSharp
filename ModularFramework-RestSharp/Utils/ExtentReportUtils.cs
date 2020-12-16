using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Utils
{
    public class ExtentReportUtils
    {
        private ExtentReports extentReports;
        private ExtentHtmlReporter htmlReporter;

        private ExtentTest extentTest;

        public ExtentReportUtils(string htmlReportFile)
        {
            extentReports = new ExtentReports();

            _ = htmlReportFile.Trim();

            htmlReporter = new ExtentHtmlReporter(htmlReportFile);

            extentReports.AttachReporter(htmlReporter);

        }

        public void CreateTestcase(string testcaseName)
        {
            extentTest = extentReports.CreateTest(testcaseName);
        }

        public void CreateTestcase(string testcaseName, string testcaseDescription)
        {
            extentTest = extentReports.CreateTest(testcaseName, testcaseDescription);
        }

        public void AddLogs(Status status, string logMessage)
        {
            extentTest.Log(status, logMessage);
        }

        public void DisposeExtentReport()
        {
            extentReports.Flush();
        }
    }
}