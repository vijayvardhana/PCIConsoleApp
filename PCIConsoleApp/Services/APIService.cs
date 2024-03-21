using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace PCIApplication
{
    public class APIService
    {
        public async Task<Schedule[]> GetSchedulesAsync()
        {
            string apiUrl =  "https://rndfiles.blob.core.windows.net/pizzacabininc/2015-12-14.json";

            var httpClient = new System.Net.Http.HttpClient();
            try
            {
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<RootObject>(jsonString);
                    return root.ScheduleResult.Schedules;
                }
                else
                {
                    throw new Exception($"Failed to get schedules form API. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed Fetch data from API, due to : {ex.Message}");
                throw;
            }
            finally
            {
                if (httpClient != null)
                    httpClient.Dispose();
            }

        }
    }
}
