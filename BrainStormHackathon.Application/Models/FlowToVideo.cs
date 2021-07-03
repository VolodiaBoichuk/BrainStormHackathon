using Newtonsoft.Json;

namespace BrainStormHackathon.Application.Models
{
    public class FlowToVideo
    {
        [JsonProperty("flowId")]
        public int FlowId { get; set; }
        [JsonProperty("videoId")]
        public int VideoId { get; set; }
    }
}