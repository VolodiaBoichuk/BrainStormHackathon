using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;
using BrainStormHackathon.Domain.Entities;
using BrainStormHackathon.Services.Interfaces;
using Neo4j.Driver;
using Newtonsoft.Json;

namespace BrainStormHackathon.Infrastructure.Services.Neo4J
{
    public class Neo4JClientSeed : IDataSeed
    {
        private readonly IDriver _driver;

        public Neo4JClientSeed(IDriver driver)
        {
            _driver = driver;
        }

        public async Task SeedAsync()
        {
            var seedObject = await GetSeedObject();
            
            await CreateUsers(seedObject.Users);
            await CreateVideos(seedObject.Videos);
            await CreateGroups(seedObject.Groups);
            await CreateFlow(seedObject.Flows);

            await CreateRelationships(seedObject.UsersToVideos);
            await CreateRelationships(seedObject.UsersToGroups);
            await CreateRelationships(seedObject.UsersToFlows);
            await CreateRelationships(seedObject.GroupsToVideos);
            await CreateRelationships(seedObject.GroupsToFlows);
            await CreateRelationships(seedObject.FlowsToVideos);
        }

        private async Task<SeedObject> GetSeedObject()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data.json");
            if(!File.Exists(path)) throw new FileNotFoundException("Data.json");
            
            var content = await File.ReadAllTextAsync(path);

            var result = JsonConvert.DeserializeObject<SeedObject>(content);
            return result;
        }

        private async Task CreateUsers(List<User> users)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $users AS user")
                .AppendLine("MERGE (u:User {id: user.id})")
                .AppendLine("SET u = user")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"users", ParameterSerializer.ToDictionary(users)}});
        }

        private async Task CreateVideos(List<Video> videos)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $videos AS video")
                .AppendLine("MERGE (v:video {name: video.name, id: video.id})")
                .AppendLine("SET v = video")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"videos", ParameterSerializer.ToDictionary(videos)}});
        }

        private async Task CreateGroups(List<Group> groups)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $groups AS group")
                .AppendLine("MERGE (g:Group {id: group.id})")
                .AppendLine("SET g = group")
                .ToString();

            await ExecuteAsync(cypher, new Dictionary<string, object> {{"groups", ParameterSerializer.ToDictionary(groups)}});
        }

        private async Task CreateFlow(List<Flow> flows)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $flows AS flow")
                .AppendLine("MERGE (f:Flow {id: flow.id})")
                .AppendLine("SET f = flow")
                .ToString();

            await ExecuteAsync(cypher, new Dictionary<string, object> {{"flows", ParameterSerializer.ToDictionary(flows)}});
        }

        private async Task CreateRelationships(List<UserToVideo> relationships)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $relationships AS relationship")
                .AppendLine("MATCH (u:User {id: relationship.userId}), (v:Video {id: relationship.videoId})")
                .AppendLine("MERGE (v)-[r:ACTED_IN { roles: ['relationship.priority']}]->(u)")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"relationships", ParameterSerializer.ToDictionary(relationships)}});
        } 
        
        private async Task CreateRelationships(List<UserToGroup> relationships)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $relationships AS relationship")
                .AppendLine("MATCH (u:User {id: relationship.userId}), (g:Group {id: relationship.groupId})")
                .AppendLine("MERGE (u)-[r:DIRECTED]->(g)")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"relationships", ParameterSerializer.ToDictionary(relationships)}});
        } 
        
        private async Task CreateRelationships(List<UserToFlow> relationships)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $relationships AS relationship")
                .AppendLine("MATCH (u:User {id: relationship.userId}), (f:Flow {id: relationship.flowId})")
                .AppendLine("MERGE (f)-[r:ACTED_IN { roles: ['relationship.priority']}]->(u)")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"relationships", ParameterSerializer.ToDictionary(relationships)}});
        } 
        
        private async Task CreateRelationships(List<GroupToVideo> relationships)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $relationships AS relationship")
                .AppendLine("MATCH (g:Group {id: relationship.groupId}), (v:Video {id: relationship.videoId})")
                .AppendLine("MERGE (v)-[r:ACTED_IN { roles: ['relationship.priority']}]->(g)")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"relationships", ParameterSerializer.ToDictionary(relationships)}});
        }
        
        private async Task CreateRelationships(List<GroupToFlow> relationships)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $relationships AS relationship")
                .AppendLine("MATCH (g:Group {id: relationship.groupId}), (f:Flow {id: relationship.flowId})")
                .AppendLine("MERGE (f)-[r:ACTED_IN { roles: ['relationship.priority']}]->(g)")
                .ToString();
            
            await ExecuteAsync(cypher, new Dictionary<string, object> {{"relationships", ParameterSerializer.ToDictionary(relationships)}});
        }
        
        private async Task CreateRelationships(List<FlowToVideo> relationships)
        {
            var cypher = new StringBuilder()
                .AppendLine("UNWIND $relationships AS relationship")
                .AppendLine("MATCH (f:Flow {id: relationship.flowId}), (v:Video {id: relationship.videoId})")
                .AppendLine("MERGE (f)-[r:DIRECTED]->(v)")
                .ToString();

            await ExecuteAsync(cypher, new Dictionary<string, object> {{"relationships", ParameterSerializer.ToDictionary(relationships)}});
        }

        private async Task ExecuteAsync(string cypher, Dictionary<string, object> parameters)
        {
            await using var session = _driver.AsyncSession();
            await session.RunAsync(cypher, parameters);
        }
    }
}