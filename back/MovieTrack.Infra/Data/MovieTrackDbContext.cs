using Microsoft.EntityFrameworkCore;
using MovieTrack.Domain.Entities;

namespace MovieTrack.Infra.Data
{
    public class MovieTrackDbContext : DbContext
    {
        public MovieTrackDbContext(DbContextOptions<MovieTrackDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieInteraction> MovieInteractions { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Address).HasColumnName("Email").IsRequired();
                });

            modelBuilder.Entity<UserRelation>()
                .HasKey(uf => uf.Id);

            modelBuilder.Entity<UserRelation>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserRelations)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRelation>()
                .HasOne(uf => uf.RelatedUser)
                .WithMany()
                .HasForeignKey(uf => uf.RelatedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovieInteraction>()
                .HasOne(mi => mi.User)
                .WithMany(u => u.MovieInteractions)
                .HasForeignKey(mi => mi.UserId);

            modelBuilder.Entity<MovieInteraction>()
                .HasOne(mi => mi.Movie)
                .WithMany()
                .HasForeignKey(mi => mi.MovieId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
