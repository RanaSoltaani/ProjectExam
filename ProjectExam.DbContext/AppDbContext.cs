using Microsoft.EntityFrameworkCore;
using ProjectExam.Models;

using static System.Net.Mime.MediaTypeNames;

namespace ProjectExam.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }


    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        

    }





}