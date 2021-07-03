using Newtonsoft.Json;

namespace BrainStormHackathon.Domain.Entities
{
    public class Video
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}