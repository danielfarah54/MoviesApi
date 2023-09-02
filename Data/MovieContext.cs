using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Data;

public class MovieContext : DbContext
{
  public MovieContext(DbContextOptions<MovieContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Session>().HasKey(s => new { s.MovieId, s.MovieTheaterId });
    modelBuilder.Entity<Session>()
      .HasOne(s => s.Movie)
      .WithMany(m => m.Sessions)
      .HasForeignKey(s => s.MovieId);

    modelBuilder.Entity<Session>()
      .HasOne(s => s.MovieTheater)
      .WithMany(mt => mt.Sessions)
      .HasForeignKey(s => s.MovieTheaterId);

    modelBuilder.Entity<Address>()
      .HasOne(a => a.MovieTheater)
      .WithOne(mt => mt.Address)
      .OnDelete(DeleteBehavior.Restrict);
  }

  public DbSet<Movie> Movies { get; set; } = default!;
  public DbSet<MovieTheater> MovieTheaters { get; set; } = default!;
  public DbSet<Address> Addresses { get; set; } = default!;
  public DbSet<Session> Sessions { get; set; } = default!;
}