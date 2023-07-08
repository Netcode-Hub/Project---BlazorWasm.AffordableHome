using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;

namespace BlazorWasm.AffordableHomes.Client.Services.ModeServices
{
    public interface IModeService
    {
        Task<Response> AddMode(ModeDTO model);
        Task<List<ModeDTO>> GetAllModes();
    }
}

