using eUcionica.Models;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Services
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Predmet> Predmet { get; set; }
		public DbSet<Pitanje> Pitanje { get; set; }
		public DbSet<Oblast> Oblast { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<Predmet>()
				.Property(p => p.NazivPredmeta)
				.IsRequired();


			modelBuilder.Entity<Pitanje>()
				.Property(u => u.NivoTezine)
				.IsRequired();
			modelBuilder.Entity<Pitanje>()
				.Property(u => u.PitanjeText)
				.IsRequired();
			modelBuilder.Entity<Pitanje>()
			   .Property(u => u.TacanOdgovor)
			   .IsRequired();
			modelBuilder.Entity<Pitanje>()
			  .Property(u => u.OblastID)
			  .IsRequired();
			modelBuilder.Entity<Pitanje>()
			   .Property(u => u.PredmetID)
			   .IsRequired();


			modelBuilder.Entity<Oblast>()
			   .Property(o => o.Name)
			   .IsRequired();
			modelBuilder.Entity<Oblast>()
			   .Property(o => o.PredmetID)
			   .IsRequired();


			modelBuilder.Entity<Predmet>()
				.HasMany(s => s.Pitanja).WithOne(p => p.Predmet).HasForeignKey(p => p.PredmetID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Predmet>()
				.HasMany(s => s.Oblasti).WithOne(p => p.Predmet).HasForeignKey(p => p.PredmetID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Oblast>()
				.HasMany(s => s.OblastPredmeta).WithOne(p => p.Oblast).HasForeignKey(p => p.OblastID)
				.OnDelete(DeleteBehavior.NoAction);
		}

	}
}