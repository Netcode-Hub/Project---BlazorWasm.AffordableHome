using System;
using BlazorWasm.AffordableHomes.Shared.Entities;

namespace BlazorWasm.AffordableHomes.Shared.DTOs
{
    public class HouseResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Type { get; set; }
        public double Price { get; set; }
        public string? Location { get; set; }
        public int Size { get; set; }
        public int NOfBed { get; set; }
        public int NOfBath { get; set; }
        public string? Image { get; set; }
        public Mode? Modes { get; set; }
        public int ModeId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

