using System;
using System.Threading.Tasks;

namespace PCIApplication
{
    class Program
    {
        private static readonly APIService _apiService = new APIService();
        private static readonly DBService _dbService = new DBService();

        static async Task Main(string[] args)
        {
            // Pulling Data from the REST API
            var schedules = await _apiService.GetSchedulesAsync();

            // Save the Data to the database
            await _dbService.SaveDataAsync(schedules);

            //Fetching data from database
            _dbService.GetDataFromDatabase();
        }
    }
}
