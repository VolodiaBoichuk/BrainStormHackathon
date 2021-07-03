using BrainStormHackathon.Application.Enums;
using Newtonsoft.Json;

namespace BrainStormHackathon.Application.Models
{
    public class GroupToFlow
    {
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        [JsonProperty("flowId")]
        public int FlowId { get; set; }
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
    }
}