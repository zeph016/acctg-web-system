using fgciams.domain.clsCustomer;
using System.Net;
using System.Net.Http.Headers;

namespace fgciams.service.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        List<CustomerTypeModel> types = new();
        List<CustomerModel> customers = new();
        CustomerTypeModel typeModel = new();
        CustomerModel customer = new();
        HttpClient client;
        public CustomerService(HttpClient _client){
            client =_client;
        }
        public async Task<List<CustomerTypeModel>> LaodCustomerTypes(string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("/project-customer-type/list");
                if(responseMessage.IsSuccessStatusCode){
                    types = await responseMessage.Content.ReadAsAsync<List<CustomerTypeModel>>();
                }
                return types;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
        public async Task<CustomerTypeModel> AddCustomerType(CustomerTypeModel typeModel,string token){
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("project-customer-type",typeModel);
                if(responseMessage.IsSuccessStatusCode)
                    typeModel = await responseMessage.Content.ReadAsAsync<CustomerTypeModel>();
                return typeModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<CustomerTypeModel> UpdateCustomerType(CustomerTypeModel typeModel,string token){
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("project-customer-type",typeModel);
                if(responseMessage.IsSuccessStatusCode)
                    typeModel = await responseMessage.Content.ReadAsAsync<CustomerTypeModel>();
                return typeModel;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<List<CustomerModel>> LoadCustomers(string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync("/project-customer/list");
                if(responseMessage.IsSuccessStatusCode){
                    customers = await responseMessage.Content.ReadAsAsync<List<CustomerModel>>();
                }
                return customers;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
        public async Task<CustomerModel> AddCustomer(CustomerModel typeModel,string token){
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/project-customer",typeModel);
                if(responseMessage.IsSuccessStatusCode)
                    customer = await responseMessage.Content.ReadAsAsync<CustomerModel>();
                return customer;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<CustomerModel> UpdateCustomer(CustomerModel typeModel,string token){
            try{   
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("/project-customer",typeModel);
                if(responseMessage.IsSuccessStatusCode)
                    customer = await responseMessage.Content.ReadAsAsync<CustomerModel>();
                return customer;
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                throw ee;
            }
        }
        public async Task<List<CustomerTypeModel>> GetCustomerSubTypes(long Id, string token)
        {
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                HttpResponseMessage responseMessage = await client.GetAsync(String.Format("project-customer-type/get-id/{0}",Id));
                if(responseMessage.IsSuccessStatusCode){
                    types = await responseMessage.Content.ReadAsAsync<List<CustomerTypeModel>>();
                }
                return types;
            }catch(Exception ee){
                  Console.WriteLine(ee.Message);
                  throw ee;
            }
        }
    } 
}