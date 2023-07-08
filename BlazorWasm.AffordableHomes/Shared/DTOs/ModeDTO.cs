using System;
using System.ComponentModel.DataAnnotations;
using BlazorWasm.AffordableHomes.Shared.Entities;

namespace BlazorWasm.AffordableHomes.Shared.DTOs
{
    public class ModeDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<House>? Houses { get; set; }
    }
}

