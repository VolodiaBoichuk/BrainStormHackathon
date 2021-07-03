using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;
using BrainStormHackathon.Domain.Entities;
using BrainStormHackathon.Services.Interfaces;
using Neo4jClient;

namespace BrainStormHackathon.Infrastructure.Repositories
{
    public class Neo4JContentReader : IContentReader
    {
        private readonly GraphClient _client;

        public Neo4JContentReader(GraphClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<ContentInfoDto>> SearchAsync(int userId, int videoId, string orderBy = "desc")
        {
            return Task.FromResult(Enumerable.Empty<ContentInfoDto>());
        }

        public async Task<IEnumerable<ContentDto>> SearchByUserIdAsync(int userId, string orderBy = "desc")
        {
            await _client.ConnectAsync();
            
            var result = await  _client.Cypher.Match($"(v:Video)-[r:ACTED_IN]->(u:User)")
                .Where((User u)=> u.Id == userId)
                .Return((v, u) => new ContentDto
                {
                    Name = v.As<Video>().Name,
                }).ResultsAsync;

            return result;
        }
    }
}