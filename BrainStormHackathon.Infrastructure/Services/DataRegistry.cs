using System.IO;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;
using Newtonsoft.Json;

namespace BrainStormHackathon.Infrastructure.Services
{
    public static class DataRegistry
    {
        public static async Task<SeedObject> GetDataAsync()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data.json");
            if(!File.Exists(path)) throw new FileNotFoundException("data.json");
            
            var content = await File.ReadAllTextAsync(path);

            var result = JsonConvert.DeserializeObject<SeedObject>(content);
            return result; 
        }
    }
}