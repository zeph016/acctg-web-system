using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsDivision;
using System.Net;
using fgciams.domain.common;

namespace fgciams.service.DivisionServices
{
    public class DivisionService : IDivisionService
    {
        #region Properties
        List<DivisionModel> divisionModelList = new();
        DivisionModel divisionModel = new();
        HttpClient client;
        #endregion
        #region  Constructor
        public DivisionService(HttpClient _client){
            client =_client;
        }
        #endregion
        #region Methods
        #region LoadDivision Method
        public async Task<List<DivisionModel>> LoadDivisionList(string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("division/list");
                if(responseMessage.IsSuccessStatusCode){
                    divisionModelList = await responseMessage.Content.ReadAsAsync<List<DivisionModel>>();
                }
                return divisionModelList;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
        #endregion
        #region AddDivision Method
        public async Task<DivisionModel> AddDivision(DivisionModel divisionModel,string token){
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("division",divisionModel);
                if(responseMessage.IsSuccessStatusCode)
                    divisionModel = await responseMessage.Content.ReadAsAsync<DivisionModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    string errorContent = await responseMessage.Content.ReadAsStringAsync();
                    if(errorContent.Contains("UniqueAccountingStatus"))
                        throw HttpException.HttpExceptionMessage(divisionModel.divisionName);
                    else
                        throw HttpException.HttpErrorMessage(errorContent);
                }
                return divisionModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        #endregion
        #region UpdateDivision Method
        public async Task<DivisionModel> UpdateDivision(DivisionModel divisionModel,string token){
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("division",divisionModel);
                if(responseMessage.IsSuccessStatusCode){
                    divisionModel = await responseMessage.Content.ReadAsAsync<DivisionModel>();
                }
                return divisionModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        #endregion
        #region GetSingleValue Method
        public async Task<DivisionModel> GetDivisionSingleValue(Int64 divisionId, string token){
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("division/"+divisionId);
                if(responseMessage.IsSuccessStatusCode){
                    divisionModel = await responseMessage.Content.ReadAsAsync<DivisionModel>();
                }
                return divisionModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        #endregion
        #endregion
    }
    
}