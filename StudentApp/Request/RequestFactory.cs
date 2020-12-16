using StudentApp.Model;
using CommonLibrary.RestRequest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;

namespace StudentApp.Request
{
    public class RequestFactory
    {
        RestClientCustom restClient;

        public RequestFactory()
        {
            restClient = new RestClientCustom();
        }

        public IRestResponse GetAllStudent(string endpointUrl)
        {
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse restResponse = restClient.SendGetRequest(restRequest);

            return restResponse;

        }

        public IRestResponse<StudentDTO> GetAllStudent(string endpointUrl, Dictionary<string, object> queryParam)
        {
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<StudentDTO> restResponse = restClient.SendGetRequest<StudentDTO>(restRequest, queryParam);

            return restResponse;

        }

        public IRestResponse<DatumDTO> AddStudent(string endpointUrl, object requestPayload)
        {

            var restRequest = new RestRequest(endpointUrl);
            restRequest.AddJsonBody(requestPayload);
            Dictionary<string, object> queryParameter = new Dictionary<string, object>();
            queryParameter.Add("studentsDetail","");

            var restResponse = restClient.SendPostRequest<DatumDTO>(restRequest, queryParameter, null);

            return restResponse;

        }

        //public IRestResponse<DatumDTO> EditStudent(string endpointUrl, object requestPayload)
        //{

        //    var restRequest = new RestRequest(endpointUrl);
        //    restRequest.AddJsonBody(requestPayload);

        //    var restResponse = restClient.SendPutRequest<DatumDTO>(restRequest, null, null);

        //    return restResponse;

        //}

        //public IRestResponse DeleteStudent(string endpointUrl)
        //{
        //    var restRequest = new RestRequest(endpointUrl);

        //    var restResponse = restClient.SendDeleteRequest(restRequest);

        //    return restResponse;
        //}
    }
}