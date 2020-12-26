using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProjectInducteeRepository
    {
        Task<List<ProjectInductee>> GetInducteesAsync(string url, string token);

        Task<ProjectInductee> GetInducteesByIdAsync(string url, string id, string token);

        Task<ProjectInductee> CreateInductee(string url, ProjectInductee inductee,string token);

    }
}
