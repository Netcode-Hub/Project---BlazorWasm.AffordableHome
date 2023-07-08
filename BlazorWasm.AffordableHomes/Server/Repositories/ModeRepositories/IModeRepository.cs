using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;

namespace BlazorWasm.AffordableHomes.Server.Repositories.ModeRepositories
{
    public interface IModeRepository
    {
        Task<Response> CreateMode(ModeDTO model);
        Task<List<ModeDTO>> GetAllModes();
    }
}

