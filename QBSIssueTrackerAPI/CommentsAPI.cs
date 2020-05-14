using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QBSIssueTrackerAPI
{
   public class CommentsAPI:APIBase
    {
        public async Task<Comments[]> GetComments(string token, decimal issueId)
        {
            HttpClientHandler hndlr = new HttpClientHandler();
            hndlr.UseDefaultCredentials = true;
            _httpClient = new HttpClient(hndlr);
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            var comments = await _httpClient.GetAsync(_baseUrl + "Comments/getComments/" + issueId.ToString());
            if (comments.IsSuccessStatusCode)
            {
                var responseContent = await comments.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Models.Comments[]>(responseContent);
            }
            else
            {
                throw GetException(comments);
            }
        }
    }
}
