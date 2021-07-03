using System.Collections.Generic;
using Newtonsoft.Json;
using BrainStormHackathon.Domain.Entities;

namespace BrainStormHackathon.Application.Models
{
    public class SeedObject
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }
        [JsonProperty("videos")]
        public List<Video> Videos { get; set; }
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
        [JsonProperty("flows")]
        public List<Flow> Flows { get; set; }
        [JsonProperty("usersToVideos")]
        public List<UserToVideo> UsersToVideos { get; set; }
        [JsonProperty("usersToGroups")]
        public List<UserToGroup> UsersToGroups { get; set; }
        [JsonProperty("usersToFlows")]
        public List<UserToFlow> UsersToFlows { get; set; }
        [JsonProperty("groupsToVideos")]
        public List<GroupToVideo> GroupsToVideos { get; set; }
        [JsonProperty("groupsToFlows")]
        public List<GroupToFlow> GroupsToFlows { get; set; }
        [JsonProperty("flowsToVideos")]
        public List<FlowToVideo> FlowsToVideos { get; set; }
    }
}