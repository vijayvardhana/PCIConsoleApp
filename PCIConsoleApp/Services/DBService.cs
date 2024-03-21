using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace PCIApplication
{
    public class DBService
    {
        public async Task SaveDataAsync(Schedule[] schedules)
        {
            var dbContext = new PCIDbContext();
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                dbContext.Schedules.AddRange(schedules);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save data into database, due to : {ex.Message}");
                throw;
            }
            finally
            {
                if (dbContext != null)
                    dbContext.Dispose();
            }
        }

        public void GetDataFromDatabase()
        {
            using (var dbContext = new PCIDbContext())
            {
                var schedules = dbContext.Schedules.Include(s => s.Projection);
                foreach (var item in schedules)
                {
                    Console.WriteLine($"\n{item.Name}\t{item.PersonId}\t{item.Date}\t+" +
                        $"{item.ContractTimeMinutes}\t{item.IsFullDayAbsence}");
                    foreach (var p in item.Projection)
                    {
                        Console.WriteLine($"\t{p.Color}\t{p.Description}\t{p.Start}\t{p.Minutes}");
                    }
                }
            }
        }
    }
}
