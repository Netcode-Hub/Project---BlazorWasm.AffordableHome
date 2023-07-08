using System;
namespace BlazorWasm.AffordableHomes.Shared.Entities
{
    public class Mode
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<House>? Houses { get; set; }
    }
}

