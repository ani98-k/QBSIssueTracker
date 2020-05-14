using Microsoft.AspNetCore.Http;
using Models;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace QBSIssueTrackerAPI
{
    public class IssuesAPI:APIBase
    {
        public async Task<Issues> GetIssues(string token,decimal issueId)
        {
            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            _httpClient = new HttpClient(hndlr);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            var issues = await _httpClient.GetAsync(_baseUrl + "getIssue/"+issueId.ToString());
            if (issues.IsSuccessStatusCode)
            {
                var responseContent = await issues.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Issues>(responseContent);
            }
            else
            {
                throw GetException(issues);
            }

        }
        public async Task<decimal> AddIssue(string token,Models.Issues issues)
        {
            InitializeHttpClient(token);
            StringContent content = new StringContent(JsonConvert.SerializeObject(issues));
            var responce = await _httpClient.PostAsync(_baseUrl + "Issues/addIssue",content);
            if (responce.IsSuccessStatusCode)
            {
                var responceContent = await responce.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<decimal>(responceContent);
            }
            else
            {
                throw GetException(responce);
            }
        }
        public async Task<string> GetAttachments(string token,string Url)
        {
            InitializeHttpClient(token);
            var attachment = await _httpClient.GetAsync(_baseUrl + $"getAttachments?attacmentUrl={Url}");
            if (attachment.IsSuccessStatusCode)
            {
                var responseContent = await attachment.Content.ReadAsStreamAsync();
                //  return JsonConvert.DeserializeObject<IFormFile>(responseContent);
                return "";
            }
            else
            {
                throw GetException(attachment);
            }

        }
        public async Task<bool> SentAttanchments( MediaFile mediaFiles,decimal IssueId,string token)
        {
            InitializeHttpClient(token);
            var content = new MultipartFormDataContent();
            content.Headers.ContentType.MediaType = "multipart/form-data";
            
            content.Add(new StreamContent(mediaFiles.GetStream()));
            var response = await _httpClient.PostAsync(_baseUrl+ $"Issue/addAttachments?issueId = {IssueId}",content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Issues[]> GetIssues(string token)
        {
            InitializeHttpClient(token);
            var issues = await _httpClient.GetAsync(_baseUrl + "getIssue");
            if (issues.IsSuccessStatusCode)
            {
                var responseContent = await issues.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Issues[]>(responseContent);
            }
            else
            {
                throw GetException(issues);
            }
        }

        private void InitializeHttpClient(string token)
        {
            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            _httpClient = new HttpClient(hndlr);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
        }

        public async Task<Issues[]> SearchIssues(string token,string searchString)
        {
            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            _httpClient = new HttpClient(hndlr);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            var searchResult = await _httpClient.GetAsync(_baseUrl + "searchIssue"+ "?namePart="+searchString);
            if (searchResult.IsSuccessStatusCode)
            {
                var responseContent = await searchResult.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Issues[]>(responseContent);
            }
            else
            {
                throw GetException(searchResult);
            }
        }
        public async Task<Boolean> EditIssue(decimal id, Comments[] commentsViewList,string token)
        {
            InitializeHttpClient(token);
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(commentsViewList));
            var responseContent = await _httpClient.PutAsync(_baseUrl+$"Issue/editIssue/{id}",stringContent);
            if (responseContent.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  async Task<Boolean> EditIssueBySupport(decimal issueId,Issues issues,string token )
        {
            InitializeHttpClient(token);
            var issueStringContent = new StringContent(JsonConvert.SerializeObject(issues));
            var resonceContent = await _httpClient.PutAsync(_baseUrl + $"Issue/editIssueSupport/{issueId}", issueStringContent);
            if (resonceContent.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw GetException(resonceContent);
            }
        }
        public async Task<IEnumerable<Status>> GetIssueStatuses(string token)
        {
            InitializeHttpClient(token);
            var statusesResponse = await _httpClient.GetAsync(_baseUrl + "getStatuses");
            if (statusesResponse.IsSuccessStatusCode)
            {
                var response = await statusesResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Models.Status>>(response);
            }
            else
            {
                throw GetException(statusesResponse);
            }
        }
        public async Task<IEnumerable<Severity>> GetSeveritiesAsync(string token)
        {
            InitializeHttpClient(token);
            var severityResponse = await _httpClient.GetAsync(_baseUrl + "getSeverities");
            if (severityResponse.IsSuccessStatusCode)
            {
                var repsponse = await severityResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Severity>>(repsponse);
            }
            else
            {
                throw GetException(severityResponse);
            }
        }
        public async Task<Models.Projects[]> GetProjectsAsync(string token)
        {
            InitializeHttpClient(token);
            var projectsResponse = await _httpClient.GetAsync(_baseUrl + "Projects/getProjects");
            if (projectsResponse.IsSuccessStatusCode)
            {
                var result = await projectsResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Projects[]>(result);
            }
            else
            {
                throw GetException(projectsResponse);
            }
        }
        public async Task<IEnumerable<Categories>> GetCategoriesAsync(string token)
        {
            InitializeHttpClient(token);
            var categoriesResponse = await _httpClient.GetAsync(_baseUrl + "Categories/getCategories");
            if (categoriesResponse.IsSuccessStatusCode)
            {
                var response = await categoriesResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Categories>>(response);
            }
            else
            {
                throw GetException(categoriesResponse);
            }
        }
    }
}
