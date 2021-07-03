using Newtonsoft.Json;

namespace BrainStormHackathon.Domain.Entities
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}