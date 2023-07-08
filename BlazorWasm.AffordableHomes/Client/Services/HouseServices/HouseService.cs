using System;
using System.Net.Http.Json;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;

namespace BlazorWasm.AffordableHomes.Client.Services.HouseServices
{
    public class HouseService : IHouseService
    {
        private readonly HttpClient httpClient;

        public HouseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Response> AdHouseData(HouseRequestDTO model)
        {
            var result = await httpClient.PostAsJsonAsync("api/house", model);
            var response = await result.Content.ReadFromJsonAsync<Response>();
            return response!;
        }

        public async Task<Response> DeleteHouseData(int id)
        {
            var result = await httpClient.DeleteAsync($"api/house/{id}");
            var response = await result.Content.ReadFromJsonAsync<Response>();
            return response!;
        }

        public async Task<List<HouseResponseDTO>> GetAllHouseData()
        {
            var results = await httpClient.GetAsync("api/house");
            var responses = await results.Content.ReadFromJsonAsync<List<HouseResponseDTO>>();
            return responses!;
        }

        public async Task<HouseResponseDTO> GetSingleHouseData(int id)
        {
            var result = await httpClient.GetAsync($"api/house/{id}");
            var response = await result.Content.ReadFromJsonAsync<HouseResponseDTO>();
            return response!;
        }

        public async Task<Response> UpdateHouseData(HouseRequestDTO model)
        {
            var result = await httpClient.PutAsJsonAsync("api/house", model);
            var response = await result.Content.ReadFromJsonAsync<Response>();
            return response!;
        }
    }
}

