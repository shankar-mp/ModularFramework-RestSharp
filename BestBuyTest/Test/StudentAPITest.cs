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

        //[TestMethod]
        //public void VerifyAddStudentApiWithRequestPayloadInJsonFile()
        //{

        //    string requestPayloadJsonFile = $"{currentProjectDirectory}/TestData/product.json";

        //    string requestPayload = File.ReadAllText(requestPayloadJsonFile);

        //    string productEndpointUrl = $"{endpointUrl}/{studentResource}";
        //    var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

        //    Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


        //}

        //[TestMethod]
        //public void VerifyAddStudentApiWithRequestPayloadAsObject()
        //{

        //    ProductDTO requestPayload = new ProductDTO();

        //    requestPayload.name = "IPhone";
        //    requestPayload.type = "Mobile";
        //    requestPayload.price = 1000;
        //    requestPayload.shipping = 10;
        //    requestPayload.upc = "2asj";
        //    requestPayload.description = "Iphone New Model";
        //    requestPayload.manufacturer = "Apple";
        //    requestPayload.model = "iPhone 12";
        //    requestPayload.url = "rweuru";
        //    requestPayload.image = "sdfsadfasd";


        //    string productEndpointUrl = $"{endpointUrl}/{studentResource}";
        //    var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

        //    Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);


        //}

        //[TestMethod]
        //public void VerifyEditProductApiWithRequestPayloadAsObject()
        //{
        //    string productEndpointUrl = $"{endpointUrl}/{studentResource}";
        //    ProductDTO requestPayload = new ProductDTO();

        //    requestPayload.name = "IPhone";
        //    requestPayload.type = "Mobile";
        //    requestPayload.price = 1000;
        //    requestPayload.shipping = 10;
        //    requestPayload.upc = "2asj";
        //    requestPayload.description = "Iphone New Model";
        //    requestPayload.manufacturer = "Apple";
        //    requestPayload.model = "iPhone 12";
        //    requestPayload.url = "rweuru";
        //    requestPayload.image = "sdfsadfasd";



        //    var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

        //    Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);

        //    int id = restResponse.Data.id;

        //    ProductDTO requestPayloadForUpdate = new ProductDTO();

        //    requestPayloadForUpdate.name = "Samsung Mobile";
        //    requestPayloadForUpdate.type = "Mobile";
        //    requestPayloadForUpdate.price = 1000;
        //    requestPayloadForUpdate.shipping = 10;
        //    requestPayloadForUpdate.upc = "2asj";
        //    requestPayloadForUpdate.description = "Samsung New Model";
        //    requestPayloadForUpdate.manufacturer = "Samsung";
        //    requestPayloadForUpdate.model = "Samsung 12";
        //    requestPayloadForUpdate.url = "rweuru";
        //    requestPayloadForUpdate.image = "sdfsadfasd";

        //    var restResponseFromEdit = requestFactory.EditProduct($"{productEndpointUrl}/{id}", requestPayloadForUpdate);

        //    Assert.AreEqual(HttpStatusCode.OK, restResponseFromEdit.StatusCode);

        //    Assert.AreEqual(requestPayloadForUpdate.name, restResponseFromEdit.Data.name);
        //}

        //[TestMethod]
        //public void VerifyDeleteProductApiWithRequestPayloadAsObject()
        //{
        //    string productEndpointUrl = $"{endpointUrl}/{studentResource}";
        //    ProductDTO requestPayload = new ProductDTO();

        //    requestPayload.name = "IPhone";
        //    requestPayload.type = "Mobile";
        //    requestPayload.price = 1000;
        //    requestPayload.shipping = 10;
        //    requestPayload.upc = "2asj";
        //    requestPayload.description = "Iphone New Model";
        //    requestPayload.manufacturer = "Apple";
        //    requestPayload.model = "iPhone 12";
        //    requestPayload.url = "rweuru";
        //    requestPayload.image = "sdfsadfasd";



        //    var restResponse = requestFactory.AddStudent(productEndpointUrl, requestPayload);

        //    Assert.AreEqual(HttpStatusCode.Created, restResponse.StatusCode);

        //    int id = restResponse.Data.id;

        //    //DELETE Request

        //    var restResponseFromDelete = requestFactory.DeleteProduct($"{productEndpointUrl}/{id}");

        //    Assert.AreEqual(HttpStatusCode.OK, restResponseFromDelete.StatusCode);

        //    //GET Request

        //    var restResponseFromGet = requestFactory.GetAllStudent($"{productEndpointUrl}/{id}");

        //    Assert.AreEqual(HttpStatusCode.NotFound, restResponseFromGet.StatusCode);

        //}
    }
}