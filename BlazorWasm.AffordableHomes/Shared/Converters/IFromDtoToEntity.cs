using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Entities;

namespace BlazorWasm.AffordableHomes.Shared.Converters
{
    public interface IFromDtoToEntity
    {
        House ConvertToEntity(HouseRequestDTO model);
        Mode ConvertModeToEntity(ModeDTO model);

    }
}

