
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace QBSIssueTrackerAPI
{
    public class RegisterUserAPI:APIBase
    {
      

       
        public async Task<string> Login(Models.LogeIn logInViewModel)
        {
            
            var content = new StringContent(JsonConvert.SerializeObject(logInViewModel), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl + "AspnetUser/login",content);
       
            

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<string>(responseContent);
                return token;
                // return JsonConvert.DeserializeObject<TokenViewModel>(responseContent);

            }
            else
            {
                throw GetException(response);
            }

        }
    }
}
