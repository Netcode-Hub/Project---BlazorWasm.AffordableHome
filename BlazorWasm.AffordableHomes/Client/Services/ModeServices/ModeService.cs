using System;
using System.Net.Http;
using System.Net.Http.Json;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;

namespace BlazorWasm.AffordableHomes.Client.Services.ModeServices
{
    public class ModeService : IModeService
    {
        private readonly HttpClient httpClient;

        public ModeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }
        public async Task<Response> AddMode(ModeDTO model)
        {
            var result = await httpClient.PostAsJsonAsync("api/mode", model);
            var response = await result.Content.ReadFromJsonAsync<Response>();
            return response!;
        }

        public async Task<List<ModeDTO>> GetAllModes()
        {
            var results = await httpClient.GetAsync("api/mode");
            var responses = await results.Content.ReadFromJsonAsync<List<ModeDTO>>();
            return responses!;
        }
    }
}

