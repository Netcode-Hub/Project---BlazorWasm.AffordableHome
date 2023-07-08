using System;
using BlazorWasm.AffordableHomes.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.AffordableHomes.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; } = default!;
        public DbSet<Mode> Modes { get; set; } = default!;
    }
}

