using BrainStormHackathon.Application.Enums;
using Newtonsoft.Json;

namespace BrainStormHackathon.Application.Models
{
    public class UserToVideo
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("videoId")]
        public int VideoId { get; set; }
        [JsonProperty("priority")]
        public Priority Priority { get; set; }
    }
}