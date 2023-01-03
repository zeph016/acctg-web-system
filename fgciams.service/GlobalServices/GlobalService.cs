using fgciams.domain.clsEmployee;
using fgciams.domain.clsFilterParameter;
using fgciams.domain.clsProject;
using fgciams.domain.clsUserAccount;
using fgciams.domain.clsPayee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using fgciams.domain.clsProjectChargingLine;
using fgciams.domain.clsPO;
using fgciams.domain.clsScopeOfWork;
using fgciams.domain.clsSubConGeneralInformation;
using fgciams.domain.clsSubContractProject;
using fgciams.domain.clsCollection;
using System.Net.Http.Json;

namespace fgciams.service.GlobalServices
{
    public class GlobalService : IGlobalService
    {
        public GlobalService(HttpClient client) => _client = client;

        #region Properties

        private readonly HttpClient _client;

        #endregion

        #region Methods

        #region Load Employee
        public async Task<List<UserAccount>> LoadAllEmployee(FilterParameter filterParameter, string token)
        {
            try
            {
                var employees = new List<UserAccount>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("masterlist/employees/fgciemployees", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    employees = await responseMessage.Content.ReadAsAsync<List<UserAccount>>();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Load Project
        public async Task<List<Project>> LoadProjects(FilterParameter filterParameter, string token)
        {
            var projects = new List<Project>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("masterlist/projects/fgcioverallprojects", filterParameter);
            if (responseMessage.IsSuccessStatusCode)
                projects = await responseMessage.Content.ReadAsAsync<List<Project>>();
            return projects;

        }
        #endregion

        #region Get Employee by Id
        public async Task<UserAccount> GetEmployeeById(long EmployeeId, string token)
        {
            var employeeName = new UserAccount();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.GetAsync("masterlist/employees/" + EmployeeId);
            if (responseMessage.IsSuccessStatusCode)
                employeeName = await responseMessage.Content.ReadAsAsync<UserAccount>();
            return employeeName;
        }
        #region Load Payees
        public async Task<List<Project>> LoadPayees(FilterParameter filterParameter, string token)
        {
            var payee = new List<Project>();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("accounting-global/payee-list", filterParameter);
            if (responseMessage.IsSuccessStatusCode)
                payee = await responseMessage.Content.ReadAsAsync<List<Project>>();
            return payee;
        }
        #endregion

        #region Load Project Charging Line
        public async Task<List<Project>> LoadChargeProjectLine(FilterParameter filterParameter, string token)
        {
            try
            {
                var projectCharging = new List<Project>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("accounting-global/charging-list", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    projectCharging = await responseMessage.Content.ReadAsAsync<List<Project>>();

                return projectCharging;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        public async Task<List<ProjectChargingLineModel>> projectChargingLine(FilterParameter filterParameter, string token)
        {
            try
            {
                var projectlines = new List<ProjectChargingLineModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("accounting-global/charging-list", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    projectlines = await responseMessage.Content.ReadAsAsync<List<ProjectChargingLineModel>>();

                return projectlines;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region PO 
        public async Task<List<POModel>> LoadPOs(FilterParameter filterParameter, string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("po/approved-po-list", filterParameter);
                responseMessage.EnsureSuccessStatusCode();

                return await responseMessage.Content.ReadAsAsync<List<POModel>>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region PO 
        public async Task<List<Project>> LoadLocationRoutes(FilterParameter filterParameter, string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("accounting-global/location-list", filterParameter);
                responseMessage.EnsureSuccessStatusCode();

                return await responseMessage.Content.ReadAsAsync<List<Project>>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region Payor
        public async Task<List<Project>> LoadPayorList(FilterParameter filterParameter, string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("accounting-global/payor-list ", filterParameter);
                responseMessage.EnsureSuccessStatusCode();

                return await responseMessage.Content.ReadAsAsync<List<Project>>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Project>> SubConProjects(FilterParameter filterParameter, string token)
        {
            try
            {
                var subConProjects = new List<Project>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("masterlist/projects/fgciprojects", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    subConProjects = await responseMessage.Content.ReadAsAsync<List<Project>>();
                return subConProjects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ScopeOfWorkModel>> SubConScopeOfWorks(FilterParameter filterParameter, string token)
        {
            try
            {
                var subConSOW = new List<ScopeOfWorkModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("subcon-scope-of-work/list", filterParameter);
                if (responseMessage.IsSuccessStatusCode)
                    subConSOW = await responseMessage.Content.ReadAsAsync<List<ScopeOfWorkModel>>();
                return subConSOW;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<SubContractorProjectModel>> VoucherDetailsSubCon(long projectID, string token)
        {
            try
            {
                var vDetailsSubCobProjects = new List<SubContractorProjectModel>();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("subcon-projects/subcon/"+projectID);
                if (responseMessage.IsSuccessStatusCode)
                    vDetailsSubCobProjects = await responseMessage.Content.ReadAsAsync<List<SubContractorProjectModel>>();
                return vDetailsSubCobProjects;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion

        #region  Load Server Time
        public async Task<DateTime?> GetServerTime()
        {
            var result = await _client.GetFromJsonAsync<DateTime>("ticket/server-date");
            if (result != null)
                return result;
            else
                return null;
        }
        #endregion

    }
}
