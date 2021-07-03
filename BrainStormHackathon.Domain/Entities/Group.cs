using Newtonsoft.Json;

namespace BrainStormHackathon.Domain.Entities
{
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}