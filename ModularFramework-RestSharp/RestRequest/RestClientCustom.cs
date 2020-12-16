using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.RestRequest
{
    public class RestClientCustom
    {
        private IRestClient restClient;

        public IRestClient RestClientCust
        {
            get
            {
                return restClient;
            }
        }

        public RestClientCustom()
        {
            restClient = new RestClient();
        }

        //GET - 2 (Without Type,With Type)
        //POST - 2, PUT - 2, PATCH  - 2, DELETE - 2

        public IRestResponse SendGetRequest(IRestRequest restRequest)
        {
            IRestResponse restResponse = restClient.Get(restRequest);

            return restResponse;
        }

        public IRestResponse SendGetRequest(IRestRequest restRequest, Dictionary<string, object> queryParameter)
        {
            foreach (var param in queryParameter)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }

            IRestResponse restResponse = restClient.Get(restRequest);

            return restResponse;
        }

        public IRestResponse SendGetRequest(IRestRequest restRequest, Dictionary<string, object> queryParameter, Dictionary<string, string> headers)
        {
            if (queryParameter != null)
            {
                foreach (var param in queryParameter)
                {
                    restRequest.AddParameter(param.Key, param.Value);
                }
            }
            if (headers != null)
            {
                foreach (var param in headers)
                {
                    restRequest.AddHeader(param.Key, param.Value);
                }
            }

            IRestResponse restResponse = restClient.Get(restRequest);

            return restResponse;
        }


        public IRestResponse<T> SendGetRequest<T>(IRestRequest restRequest)
        {
            return restClient.Get<T>(restRequest);
        }

        public IRestResponse<T> SendGetRequest<T>(IRestRequest restRequest, Dictionary<string, object> queryParameter)
        {
            foreach (var param in queryParameter)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }

            return restClient.Get<T>(restRequest);
        }

        public IRestResponse SendPostRequest(IRestRequest restRequest)
        {
            return restClient.Post(restRequest);
        }

        public IRestResponse<T> SendPostRequest<T>(IRestRequest restRequest)
        {
            return restClient.Post<T>(restRequest);
        }

        public IRestResponse<T> SendPostRequest<T>(IRestRequest restRequest, Dictionary<string, object> queryParameter, Dictionary<string, string> headers)
        {
            addQueryParametersToRestRequest(restRequest, queryParameter);

            addHeadersToRestRequest(restRequest, headers);


            return restClient.Post<T>(restRequest);
        }



        public IRestResponse SendPutRequest(IRestRequest restRequest)
        {
            return restClient.Put(restRequest);
        }

        public IRestResponse<T> SendPutRequest<T>(IRestRequest restRequest, Dictionary<string, object> queryParameter, Dictionary<string, string> headers)
        {
            addQueryParametersToRestRequest(restRequest, queryParameter);
            addHeadersToRestRequest(restRequest, headers);

            return restClient.Put<T>(restRequest);
        }


        public IRestResponse SendDeleteRequest(IRestRequest restRequest)
        {
            IRestResponse restResponse = restClient.Delete(restRequest);
            return restResponse;
        }

        public IRestResponse<T> SendDeleteRequest<T>(IRestRequest restRequest)
        {
            return restClient.Delete<T>(restRequest);
        }

        private void addQueryParametersToRestRequest(IRestRequest restRequest, Dictionary<string, object> queryParameter)
        {
            if (queryParameter != null)
            {
                foreach (var param in queryParameter)
                {
                    restRequest.AddParameter(param.Key, param.Value);
                }
            }

        }

        private void addHeadersToRestRequest(IRestRequest restRequest, Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var param in headers)
                {
                    restRequest.AddHeader(param.Key, param.Value);
                }
            }
        }

    }
}