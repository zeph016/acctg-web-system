using fgciams.domain.clsRequestType;
using fgciams.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.RequestTypeServices
{
    public class RequestTypeService : IRequestTypeService
    {
        public RequestTypeService(HttpClient client)
        {
            _client = client;
        }

        #region Properties

        private readonly HttpClient _client;

        #endregion

        #region Methods
        public async Task<RequestTypeModel> AddRequestType(RequestTypeModel requestType, string token)
        {
            try
            {
                var request = new RequestTypeModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("request-type", requestType);
                if (responseMessage.IsSuccessStatusCode)
                    request = await responseMessage.Content.ReadAsAsync<RequestTypeModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                  string ContentRequest = await responseMessage.Content.ReadAsStringAsync();
                  if(ContentRequest.Contains("UniqueTypeName"))
                    throw HttpException.HttpExceptionMessage(requestType.TypeName);
                  else
                    throw HttpException.HttpErrorMessage(ContentRequest);
                }
                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RequestTypeModel>> LoadRequestType(string token)
        {
            var requestTypes = new List<RequestTypeModel>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.GetAsync("request-type/list");
            if (responseMessage.IsSuccessStatusCode)
                requestTypes = await responseMessage.Content.ReadAsAsync<List<RequestTypeModel>>();
            return requestTypes;
        }

        public async Task<RequestTypeModel> UpdateRequestType(RequestTypeModel requestType, string token)
        {
            try
            {
                var request = new RequestTypeModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("request-type", requestType);
                if (responseMessage.IsSuccessStatusCode)
                    request = await responseMessage.Content.ReadAsAsync<RequestTypeModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                  string ContentRequest = await responseMessage.Content.ReadAsStringAsync();
                  if(ContentRequest.Contains("UniqueTypeName"))
                    throw HttpException.HttpExceptionMessage(requestType.TypeName);
                  else
                    throw HttpException.HttpErrorMessage(ContentRequest);
                }
                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }

    public async Task<RequestTypeModel> GetRequestType(long Id, string token)
    {
       try
       {
         var request = new RequestTypeModel();
         _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
         HttpResponseMessage responseMessage = await _client.GetAsync("request-type/" + Id);
         if(responseMessage.IsSuccessStatusCode)
            request = await responseMessage.Content.ReadAsAsync<RequestTypeModel>();
         return request;
       }
       catch (System.Exception ex)
       {
          throw;
       }
    }

    #endregion
  }
}
