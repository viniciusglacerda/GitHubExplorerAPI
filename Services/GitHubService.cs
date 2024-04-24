using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHubExplorerAPI.Services
{
    public class GitHubService
    {
        private readonly HttpClient _client;

        public GitHubService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", "Search Repo Infos");
        }

        public async Task<string> GetReposInfoAsync(string user, string language, string sort, string include_forks, string limit)
        {
            string query = $"q=user:{user} language:{language} sort:{sort} fork:{include_forks}";
            string apiUrl = "https://api.github.com/search/repositories?" + query;

            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(jsonString);
                
                // Extrair informações de cada item
                List<dynamic> reposInfo = new List<dynamic>();

                if (string.IsNullOrEmpty(limit))
                {
                    foreach (var item in result.items)
                    {
                        dynamic repoInfo = new
                        {
                            avatar_url = item.owner.avatar_url,
                            full_name = item.full_name,
                            description = item.description
                        };
                        reposInfo.Add(repoInfo);
                    }
                }
                else
                {
                    int limitValue = int.Parse(limit);
                    for (int i = 0; i < limitValue && i < result.items.Count; i++)
                    {
                        dynamic repoInfo = new
                        {
                            avatar_url = result.items[i].owner.avatar_url,
                            full_name = result.items[i].full_name,
                            description = result.items[i].description
                        };
                        reposInfo.Add(repoInfo);
                    }
                }


                string jsonResult = JsonConvert.SerializeObject(reposInfo);
                return jsonResult;
            }
            else
            {
                return JsonConvert.SerializeObject(null);
            }
        }
    }
}
