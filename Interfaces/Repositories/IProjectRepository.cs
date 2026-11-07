using Microsoft.AspNetCore.Mvc;
using TaskFlow.Models;

namespace TaskFlow.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetProjectsAsync();
}
