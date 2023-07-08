using System;
using BlazorWasm.AffordableHomes.Server.Data;
using BlazorWasm.AffordableHomes.Shared.Converters;
using BlazorWasm.AffordableHomes.Shared.DTOs;
using BlazorWasm.AffordableHomes.Shared.Reponses;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.AffordableHomes.Server.Repositories.HouseRepositories
{
    public class HouseRepo : IHouseRepo
    {
        private readonly AppDbContext appDbContext;
        private readonly IFromDtoToEntity fromDtoToEntity;
        private readonly IFromEntityToDto fromEntityToDto;

        public HouseRepo(AppDbContext appDbContext, IFromDtoToEntity fromDtoToEntity, IFromEntityToDto fromEntityToDto)
        {
            this.appDbContext = appDbContext;
            this.fromDtoToEntity = fromDtoToEntity;
            this.fromEntityToDto = fromEntityToDto;
        }

        public async Task<Response> AddHouseData(HouseRequestDTO model)
        {
            if (model == null)
                return new Response { Success = false, Message = "No content" };

            if (await CheckName(model.Name!))
                return new Response { Success = false, Message = "Data added already" };

            var result = fromDtoToEntity.ConvertToEntity(model);
            appDbContext.Houses.Add(result);
            await appDbContext.SaveChangesAsync();
            return new Response { Message = "Data Added Done!" };
        }

        public async Task<Response> DeleteHouseData(int id)
        {
            if (id <= 0)
                return new Response { Success = false, Message = "No content Id" };

            var result = await GetSingeHouseData(id);
            if (result == null)
                return new Response { Success = false, Message = "No data found" };

            if (await Delete(id))
                return new Response { Message = "Data successfully deleted" };
            return new Response { Success = false, Message = "Error occured...." };
        }

        public async Task<List<HouseResponseDTO>> GetAllHouseData()
        {
            var result = await appDbContext.Houses.Include(m => m.Mode).ToListAsync();
            return fromEntityToDto.ConvertToDtoList(result);
        }

        public async Task<HouseResponseDTO> GetSingeHouseData(int id)
        {
            var result = await appDbContext.Houses.FirstOrDefaultAsync(h => h.Id == id);
            var r = fromEntityToDto.ConvertToDto(result!);
            return r;
        }


        public async Task<Response> UpdateHouseData(HouseRequestDTO model)
        {
            if (model == null)
                return new Response { Success = false, Message = "No content" };

            var data = GetSingeHouseData(model.Id);
            if (data == null)
                return new Response { Success = false, Message = "Not found" };

            if (await Update(model))
                return new Response { Message = "Data updated done!" };
            return new Response { Success = false, Message = "Error occured..." };
        }

        private async Task<bool> CheckName(string name)
        {
            var DoesExist = await appDbContext.Houses.Where(h => h.Name!.ToLower().Equals(name.ToLower())).FirstOrDefaultAsync();
            return DoesExist == null ? false : true;
        }

        private async Task<bool> Update(HouseRequestDTO model)
        {
            var result = await appDbContext.Houses.FirstOrDefaultAsync(x => x.Id == model.Id);
            result!.Name = model.Name;
            result.Image = model.Image;
            result.Price = model.Price;
            result.Location = model.Location;
            result.ModeId = model.ModeId;
            result.NOfBath = model.NOfBath;
            result.NOfBed = model.NOfBed;
            result.Size = model.Size;
            result.Type = model.Type;
            await appDbContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> Delete(int id)
        {
            var result = await appDbContext.Houses.FirstOrDefaultAsync(x => x.Id == id);
            appDbContext.Houses.Remove(result!);
            await appDbContext.SaveChangesAsync();
            return true;
        }
    }
}

