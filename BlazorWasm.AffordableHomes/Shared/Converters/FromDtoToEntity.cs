using System;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Entities;

namespace BlazorWasm.AffordableHomes.Shared.Converters
{
    public class FromDtoToEntity : IFromDtoToEntity
    {
        public Mode ConvertModeToEntity(ModeDTO model)
        {
            var mode = new Mode()
            {
                Name = model.Name
            };
            return mode;
        }

        House IFromDtoToEntity.ConvertToEntity(HouseRequestDTO model)
        {
            var house = new House()
            {
                Name = model.Name,
                Price = model.Price,
                Image = model.Image,
                Type = model.Type,
                Size = model.Size,
                NOfBath = model.NOfBath,
                NOfBed = model.NOfBed,
                Location = model.Location,
                ModeId = model.ModeId
            };

            return house;
        }
    }
}

