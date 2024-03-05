using Microsoft.EntityFrameworkCore;
using ProjectExam.Models;

using static System.Net.Mime.MediaTypeNames;

namespace ProjectExam.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Propriété DbSet pour la table "object"
    public DbSet<MyObject> Objects { get; set; }

    // Propriété DbSet pour la table "user"
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        

    }





}