using System;
using System.Reflection;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Entities;

namespace BlazorWasm.AffordableHomes.Shared.Converters
{
    public class FromEntityToDto : IFromEntityToDto
    {
        public List<ModeDTO> ConvertModeToDtoList(List<Mode> model)
        {
            var newList = new List<ModeDTO>();
            foreach (var item in model)
            {
                var tempData = new ModeDTO()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                newList.Add(tempData);
            }
            return newList;
        }

        public HouseResponseDTO ConvertToDto(House model)
        {
            var r = new HouseResponseDTO()
            {
                Id = model.Id,
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
            return r;
        }

        public List<HouseResponseDTO> ConvertToDtoList(List<House> models)
        {
            var newList = new List<HouseResponseDTO>();
            foreach (var item in models)
            {
                var tempData = new HouseResponseDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Image = item.Image,
                    Type = item.Type,
                    Size = item.Size,
                    NOfBath = item.NOfBath,
                    NOfBed = item.NOfBed,
                    Location = item.Location,
                    ModeId = item.ModeId,
                    Modes = new Mode() { Id = item.ModeId, Name = item.Mode!.Name }
                };
                newList.Add(tempData);
            }
            return newList;
        }
    }
}

