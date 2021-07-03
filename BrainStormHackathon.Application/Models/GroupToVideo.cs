using BrainStormHackathon.Application.Enums;
using Newtonsoft.Json;

namespace BrainStormHackathon.Application.Models
{
    public class GroupToVideo
    {
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
        [JsonProperty("videoId")]
        public int VideoId { get; set; }
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
    }
}