using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;

namespace BlazorWasm.AffordableHomes.Client.Services.HouseServices
{
    public interface IHouseService
    {
        Task<Response> AdHouseData(HouseRequestDTO model);
        Task<Response> UpdateHouseData(HouseRequestDTO model);
        Task<List<HouseResponseDTO>> GetAllHouseData();
        Task<HouseResponseDTO> GetSingleHouseData(int id);
        Task<Response> DeleteHouseData(int id);
    }
}

