using System;
using Microsoft.EntityFrameworkCore;


namespace API.models;

public class AppDataContext : DbContext
{
    public DbSet<Aluno> alunos { get; set; }
    public DbSet<IMC> IMCs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = RICARDO.db");

    }



}
