using Newtonsoft.Json;

namespace BrainStormHackathon.Domain.Entities
{
    public class Flow
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}