using Microsoft.EntityFrameworkCore;
using Movies.Application.Helpers;
using Movies.Core.Entities;

namespace Movies.Application;

public partial class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Actor> Actors { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Rating> Ratings { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<MovieCast> MovieCast { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "JfJzsL3ngGWki+Dn67C+8WLy73I=",
                PasswordSalt = "7TUJfmgkkDvcY3PB/M4fhg==",
                CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0)
            }
        );
        modelBuilder.Entity<Actor>().HasData(
            new Actor { Id = 1, Name = "Brad Pitt", CreatedAt= new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 2, Name = "Denzel Washington", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 3, Name = "Adam Sandler", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 4, Name = "Leonardo DiCaprio", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 5, Name = "Nicolas Cage", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 6, Name = "Morgan Freeman", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 7, Name = "Penelope Cruz", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 8, Name = "Julia Roberts", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 9, Name = "Sandra Bullock", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 10, Name = "Jennifer Aniston", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 11, Name = "Angelina Jolie", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) },
            new Actor { Id = 12, Name = "Emma Stone", CreatedAt = new DateTime(2025, 9, 14, 23, 0, 0) }
        );
    }
}
