using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LodApp.DataAccess.DTO;
using Newtonsoft.Json;

namespace LodApp.DataAccess
{
	public class LodClient : ILodClient
	{
		static LodClient()
		{
			HttpClient = new HttpClient
			{
				BaseAddress = new Uri(BackendUrl)
			};
			HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public void AuthorizeBy(string token)
		{
			HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}

		public async Task<AuthorizationTokenInfo> LoginAsync(Credentials credentials)
		{
			var httpResponse = await HttpClient.PostAsync("login", GetContent(credentials));
			return await ParseResponseAsync<AuthorizationTokenInfo>(httpResponse);
		}

		public async Task<Developer> GetDeveloperAsync(int userId)
		{
			var httpResponse = await HttpClient.GetAsync("developers/" + userId);
			return await ParseResponseAsync<Developer>(httpResponse);
		}

		public async Task<IEnumerable<ProjectPreview>> GetProjectsPreviewAsync(int offset, int limit)
		{
			var httpResponse = await HttpClient.GetAsync($"projects/{offset}/{limit}");
			return await ParseResponseAsync<ProjectPreview[]>(httpResponse);
		}

		private static async Task<T> ParseResponseAsync<T>(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				var responseContent = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(responseContent);
			}

			throw new LodClientException($"Request to {response.RequestMessage.RequestUri} failed with {response.StatusCode:G} status code");
		}

		private static StringContent GetContent(object content)
		{
			var serialized = JsonConvert.SerializeObject(content);
			return new StringContent(serialized, Encoding.UTF8, "application/json");
		}

		private static readonly HttpClient HttpClient;
		private const string BackendUrl = "https://api.lod-misis.ru/";
	}
}