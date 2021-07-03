using Newtonsoft.Json;

namespace BrainStormHackathon.Application.Models
{
    public class UserToGroup
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("groupId")]
        public int GroupId { get; set; }
    }
}