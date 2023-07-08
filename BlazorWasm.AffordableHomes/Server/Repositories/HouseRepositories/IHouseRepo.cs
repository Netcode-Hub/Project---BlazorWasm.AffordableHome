using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Entities;
using BlazorWasm.AffordableHomes.Shared.Reponses;

namespace BlazorWasm.AffordableHomes.Server.Repositories.HouseRepositories
{
    public interface IHouseRepo
    {
        Task<Response> AddHouseData(HouseRequestDTO model);
        Task<Response> UpdateHouseData(HouseRequestDTO model);
        Task<Response> DeleteHouseData(int id);
        Task<HouseResponseDTO> GetSingeHouseData(int id);
        Task<List<HouseResponseDTO>> GetAllHouseData();
    }
}

