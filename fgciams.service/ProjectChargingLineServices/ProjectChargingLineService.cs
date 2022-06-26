using fgciams.domain.clsProjectChargingLine;
using fgciams.domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgciams.service.ProjectChargingLineServices
{
    public class ProjectChargingLineService : IProjectChargingLineService
    {
        public ProjectChargingLineService(HttpClient client)
        {
            _client = client;
        }

        #region Properties

        private readonly HttpClient _client;

        #endregion

        #region Methods

        #region Add Project Charging line
        public async Task<ProjectChargingLineModel> AddProjectChargingLine(ProjectChargingLineModel projectChargingLineModel, string token)
        {
            try
            {
                var project = new ProjectChargingLineModel();
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PostAsJsonAsync("project-charging-line", projectChargingLineModel);
                if (responseMessage.IsSuccessStatusCode)
                    project = await responseMessage.Content.ReadAsAsync<ProjectChargingLineModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                  string ContentRequest = await responseMessage.Content.ReadAsStringAsync();
                  if(ContentRequest.Contains("UniqueProjectName"))
                    throw HttpException.HttpExceptionMessage(projectChargingLineModel.ProjectName);
                  else
                    throw HttpException.HttpErrorMessage(ContentRequest);

                }
                return project;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update Project Charging line
        public async Task<ProjectChargingLineModel> UpdateProjectChargingLine(ProjectChargingLineModel projectChargingLineModel, string token)
        {
            try
            {
                var project = new ProjectChargingLineModel();
                Console.WriteLine(projectChargingLineModel.ProjectName);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.PutAsJsonAsync("project-charging-line", projectChargingLineModel);
                if (responseMessage.IsSuccessStatusCode)
                    project = await responseMessage.Content.ReadAsAsync<ProjectChargingLineModel>();
                else if(responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                  string ContentRequest = await responseMessage.Content.ReadAsStringAsync();
                  if(ContentRequest.Contains("UniqueProjectName"))
                    throw HttpException.HttpExceptionMessage(projectChargingLineModel.ProjectName);
                  else
                    throw HttpException.HttpErrorMessage(ContentRequest);

                }                    
                return project;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Load Project Charging line
        public async Task<List<ProjectChargingLineModel>> LoadProjectChargingLine(string token)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await _client.GetAsync("project-charging-line/list/");
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsAsync<List<ProjectChargingLineModel>>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #endregion


    }
}
