using System;
namespace BlazorWasm.AffordableHomes.Shared.Entities
{
    public class House
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
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Mode? Mode { get; set; }
        public int ModeId { get; set; }

    }
}

