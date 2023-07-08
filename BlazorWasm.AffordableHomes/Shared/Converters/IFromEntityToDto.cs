using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Entities;

namespace BlazorWasm.AffordableHomes.Shared.Converters
{
    public interface IFromEntityToDto
    {
        HouseResponseDTO ConvertToDto(House model);
        List<HouseResponseDTO> ConvertToDtoList(List<House> models);
        List<ModeDTO> ConvertModeToDtoList(List<Mode> model);
    }
}

