using System.Collections.Generic;
using System.Threading.Tasks;
using BrainStormHackathon.Application.Models;

namespace BrainStormHackathon.Services.Interfaces
{
    public interface IContentViewService
    {
        Task<IEnumerable<ContentInfoDto>> SearchAsync(int userId,int videoId, string orderBy = "desc");
        Task<IEnumerable<ContentDto>> SearchByUserIdAsync(int userId, string orderBy = "desc");
    }
}