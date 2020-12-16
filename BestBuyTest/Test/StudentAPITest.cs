using AventStack.ExtentReports;
using StudentApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace StudentTest.Test
{
    [TestClass]
    public class StudentAPITest : BaseTest
    {

        [TestMethod]
        public void VerifyGetStudentAPI()
        {
            reportUtils.CreateTestcase("Verify Get Student API - Test");

            IRestResponse restResponse = requestFactory.GetAllStudent($"{endpointUrl}/{studentResource}");

            reportUtils.AddLogs(Status.Info, $"Resposne Status Code : {restResponse.StatusCode} \n" +
                $"Content : {restResponse.Content}");

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

        }

        [TestMethod]
        public void VerifyGetStudentAPIWithQueryParam()
        {
            reportUtils.CreateTestcase("Verify Get Product API with query parameter- Test");

            Dictionary<string, object> allQueryParam = new Dictionary<string, object>();

            int id = 106;
            allQueryParam.Add("$id", id);

            string productEndpointUrl = $"{endpointUrl}/{studentResource}/{id}";

            var restResponse = requestFactory.GetAllStudent(productEndpointUrl, allQueryParam);

            reportUtils.AddLogs(Status.Info, $"Resposne Status Code : {restResponse.StatusCode} \n" +
                $"Content : {restResponse.Content}");

            //var getid = JsonConvert.DeserializeObject<StudentDTO>(restResponse.Content);
            //StudentDTO myDeserializedClass = JsonConvert.DeserializeObject<StudentDTO>(restResponse.Content);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

            Assert.AreEqual(id, restResponse.Data.data.id);

        }

        [TestMethod]
        public void VerifyAddStudentApiWithStringRequestPayload()
        {

            //string requestPayload = "{\"id\":106,\"first_name\":\"Sumit\",\"middle_name\":\"sample string 3\",\"last_name\":\"Cavisson\",\"date_of_birth\":\"NA\"}";
            string requestPayload = "{\"first_name\":\"Shankar\",\"middle_name\":\"M\",\"last_name\":\"Prasad\",\"date_of_birth\":\"01/01/01\"}";

            string productEndpointUrl = $"{endpointUrl}/{studentResource}";
            var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


        }

        [TestMethod]
        public void VerifyAddStudentApiWithObjectRequestPayload()
        {

            Dictionary<string, object> requestPayload = new Dictionary<string, object>();

            requestPayload.Add("first_name", "Shankar");
            requestPayload.Add("middle_name", "M");
            requestPayload.Add("last_name", "Prasad");
            requestPayload.Add("date_of_birth", "01/01/01");
            
            string productEndpointUrl = $"{endpointUrl}/{studentResource}";
            var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


        }

        [TestMethod]
        public void VerifyAddStudentApiWithRequestPayloadInJsonFile()
        {

            string requestPayloadJsonFile = $"{currentProjectDirectory}/TestData/student.json";

            string requestPayload = File.ReadAllText(requestPayloadJsonFile);

            string productEndpointUrl = $"{endpointUrl}/{studentResource}";
            var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


        }

        [TestMethod]
        public void VerifyAddStudentApiWithRequestPayloadAsObject()
        {

            Data requestPayload = new Data();

            requestPayload.id = 0;
            requestPayload.first_name = "Shankar";
            requestPayload.middle_name = "M";
            requestPayload.last_name = "Prasad";
            requestPayload.date_of_birth = "01/01/02";

            string productEndpointUrl = $"{endpointUrl}/{studentResource}";
            var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


        }

        [TestMethod]
        public void VerifyEditStudentApiWithRequestPayloadAsObject()
        {
            string productEndpointUrl = $"{endpointUrl}/{studentResource}";
            Data requestPayload = new Data();

            //requestPayload.id = 0;
            requestPayload.first_name = "Shankar";
            requestPayload.middle_name = "M";
            requestPayload.last_name = "Prasad";
            requestPayload.date_of_birth = "01/01/03";


            var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);

            int id = restResponse.Data.id;

            Data requestPayloadForUpdate = new Data();

            requestPayloadForUpdate.id = id;
            requestPayloadForUpdate.first_name = "Shankar";
            requestPayloadForUpdate.middle_name = "M";
            requestPayloadForUpdate.last_name = "Prasad";
            requestPayloadForUpdate.date_of_birth = "01/01/04";

            var restResponseFromEdit = requestFactory.EditStudent($"{productEndpointUrl}/{id}", requestPayloadForUpdate);

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromEdit.StatusCode);

            //Assert.AreEqual(requestPayloadForUpdate.date_of_birth, restResponseFromEdit.Data.date_of_birth);
        }

        [TestMethod]
        public void VerifyDeleteStudentApiWithRequestPayloadAsObject()
        {
            string productEndpointUrl = $"{endpointUrl}/{studentResource}";
            Data requestPayload = new Data();

            //requestPayload.id = 0;
            requestPayload.first_name = "Shankar";
            requestPayload.middle_name = "M";
            requestPayload.last_name = "Prasad";
            requestPayload.date_of_birth = "01/01/03";

            var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

            Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);

            int id = restResponse.Data.id;

            //DELETE Request

            var restResponseFromDelete = requestFactory.DeleteStudent($"{productEndpointUrl}/{id}");

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromDelete.StatusCode);

            //GET Request
            Dictionary<string, object> allQueryParam = new Dictionary<string, object>();

            //int id = 106;
            allQueryParam.Add("$id", id);

            IRestResponse restResponseFromGet = requestFactory.GetAllStudent($"{productEndpointUrl}/{id}", allQueryParam);

            Assert.AreEqual(HttpStatusCode.OK, restResponseFromGet.StatusCode);

        }
    }
}