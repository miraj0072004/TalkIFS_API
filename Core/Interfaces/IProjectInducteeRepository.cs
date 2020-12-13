using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProjectInducteeRepository
    {
        Task<List<ProjectInductee>> GetInducteesAsync();

        Task<ProjectInductee> GetInducteesByIdAsync(int id);
    }
}
