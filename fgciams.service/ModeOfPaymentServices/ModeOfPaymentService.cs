using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsModeOfPayment;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using fgciams.domain.common;

namespace fgciams.service.ModeOfPaymentServices
{
    public class ModeOfPaymentService : IModeOfPaymentService
    {
        #region Properties
        List<ModeOfPaymentModel> modeOfPaymentList;
        ModeOfPaymentModel modeOfPaymentModel;
        HttpClient client;
        #endregion
        #region Constructor
         public ModeOfPaymentService(HttpClient _client)
        {
            this.client = _client;
        }
        #endregion 
        #region Methods
        #region Load List Method
        public async Task<List<ModeOfPaymentModel>> LoadModeOfPaymentList(string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.GetAsync("mode-of-payment/list");
                if (httpResponse.IsSuccessStatusCode)
                {
                    modeOfPaymentList = await httpResponse.Content.ReadAsAsync<List<ModeOfPaymentModel>>();
                }
                return modeOfPaymentList.OrderBy(x => x.ModeName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #region Add Method
        public async Task<ModeOfPaymentModel> AddModeOfPayment(ModeOfPaymentModel model, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync("mode-of-payment", model);
                if (httpResponse.IsSuccessStatusCode)
                    modeOfPaymentModel = await httpResponse.Content.ReadAsAsync<ModeOfPaymentModel>();
                else if(httpResponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    string errorContent = await httpResponse.Content.ReadAsStringAsync();
                    if(errorContent.Contains("UniqueAccountingStatus"))
                        throw HttpException.HttpExceptionMessage(model.ModeName);
                    else
                        throw HttpException.HttpErrorMessage(errorContent);
                }
                return modeOfPaymentModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #region Update Method 
        public async Task<ModeOfPaymentModel> UpdateModeOfpayment(ModeOfPaymentModel model, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.PutAsJsonAsync("mode-of-payment", model);
                if (httpResponse.IsSuccessStatusCode)
                {
                    modeOfPaymentModel = await httpResponse.Content.ReadAsAsync<ModeOfPaymentModel>();
                }
                return modeOfPaymentModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #region GetSingleValue using Mode of Payment ID
        public async Task<ModeOfPaymentModel> GetModeOfPaymentSingleValue(Int64 modeOfPaymentId,string token){
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage httpResponse = await client.GetAsync("mode-of-payment/"+modeOfPaymentId);
                if (httpResponse.IsSuccessStatusCode)
                {
                    modeOfPaymentModel = await httpResponse.Content.ReadAsAsync<ModeOfPaymentModel>();
                }
                return modeOfPaymentModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion
        #endregion
    }
}
