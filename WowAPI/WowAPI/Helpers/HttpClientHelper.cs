using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using WowAPI.Constants;
using WowAPI.Properties;

namespace WowAPI.Helpers
{
    public class HttpClientHelper
    {
        private CancellationTokenSource cts = null!;

        public void CancelRequest()
        {
            cts.Cancel();
            cts.Dispose();
        }

        public async Task<HttpDataResponse<T>> GetAsync<T>(string route) where T : new()
        {
            using HttpClient httpClient = CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync(route, cts.Token);
            try
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new HttpDataResponse<T>(response.StatusCode);
                }

                string result = await response.Content.ReadAsStringAsync(cts.Token);

                if (string.IsNullOrEmpty(result))
                {
                    return new HttpDataResponse<T>(response.StatusCode);
                }

                try
                {
                    T? data = JsonConvert.DeserializeObject<T>(result);
                    return new HttpDataResponse<T>(data, response.StatusCode);
                }
                catch (Exception)
                {
                    return new HttpDataResponse<T>(response.StatusCode);
                }
            }
            catch (HttpRequestException hre)
            {
                //logger
                return new HttpDataResponse<T>();
            }
            catch (TaskCanceledException tce)
            {
                //logger
                return new HttpDataResponse<T>();
            }
            catch (Exception ex)
            {
                //logger
                return new HttpDataResponse<T>();
            }
        }

        public async Task<HttpDataResponse<IEnumerable<T>>> GetCollectionAsync<T>(string route) where T : class, new()
        {
            using HttpClient httpClient = CreateClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(route, cts.Token);

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpDataResponse<IEnumerable<T>>(response.StatusCode);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return new HttpDataResponse<IEnumerable<T>>(new List<T>(), response.StatusCode);
                }

                string result = await response.Content.ReadAsStringAsync(cts.Token);

                if (string.IsNullOrEmpty(result))
                {
                    return new HttpDataResponse<IEnumerable<T>>(response.StatusCode);
                }

                try
                {
                    var data = JsonConvert.DeserializeObject<IEnumerable<T>>(result);

                    if (data is null)
                    {
                        return new HttpDataResponse<IEnumerable<T>>(response.StatusCode);
                    }

                    return new HttpDataResponse<IEnumerable<T>>(data, response.StatusCode);
                }
                catch (Exception)
                {
                    return new HttpDataResponse<IEnumerable<T>>(response.StatusCode);
                }
            }
            catch (HttpRequestException hre)
            {
                //logger
                return new HttpDataResponse<IEnumerable<T>>();
            }
            catch (TaskCanceledException tce)
            {
                //logger
                return new HttpDataResponse<IEnumerable<T>>();
            }
            catch (Exception ex)
            {
                //logger
                return new HttpDataResponse<IEnumerable<T>>();
            }

        }

        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient();
            {
                httpClient.BaseAddress = new Uri(ApiConstants.BaseURL);
            };

            //httpClient.DefaultRequestHeaders("Accept", DefaultMediaType);

            if (!string.IsNullOrEmpty(Settings.Default.AccesTokenAPI))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Default.AccesTokenAPI);
            }

            cts = new CancellationTokenSource();

            return httpClient;
        }
    }
}
