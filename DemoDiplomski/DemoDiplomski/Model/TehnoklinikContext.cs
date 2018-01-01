namespace DemoDiplomski.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TehnoklinikContext : DbContext
    {
        public TehnoklinikContext()
            : base("TehnoklinikContext")
        {
        }

        public virtual DbSet<Deo> Delovi { get; set; }
        public virtual DbSet<Dostavnica> Dostavnice { get; set; }
        public virtual DbSet<Korisnik> Korisnici { get; set; }
        public virtual DbSet<LogKorisnik> LogKorisnici { get; set; }
        public virtual DbSet<Nalog> Nalozi { get; set; }
        public virtual DbSet<RedovanServis> RedovniServisi { get; set; }
        public virtual DbSet<Revers> Reversi { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Uredjaj> Uredjaji { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Zbog mogucnosti duplikata db-a
            //The model backing the 'Tehnoklinik' context has changed since the database was created
            Database.SetInitializer<TehnoklinikContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deo>()
                .Property(e => e.S_N)
                .IsUnicode(false);

            modelBuilder.Entity<Deo>()
                .Property(e => e.Naziv)
                .IsUnicode(true);

            modelBuilder.Entity<Deo>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Deo>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.Delovi)
                .Map(m => m.ToTable("UredjajDelovi").MapLeftKey("IDDelovi").MapRightKey("IDUredjaj"));

            modelBuilder.Entity<Dostavnica>()
                .Property(e => e.BrDostavnica)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.NazivUstanove)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Laboratorija)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Grad)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Adresa)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Drzava)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dostavnice)
                .WithRequired(e => e.Korisnici)
                .HasForeignKey(e => e.IDKoriscnik)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Nalozi)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Reversi)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.RedovniServisi)
                .WithRequired(e => e.Korisnik)
                .HasForeignKey(e => e.IDKorisnk)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.Korisnici)
                .Map(m => m.ToTable("UredjajKorisnik").MapLeftKey("IDKorisnik").MapRightKey("IDUredjaj"));

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Ime)
                .IsUnicode(true);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Prezime)
                .IsUnicode(true);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Uloga)
                .IsUnicode(true);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.KorisnickoIme)
                .IsUnicode(false);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Lozinka)
                .IsUnicode(false);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.BrRadNalog)
                .IsUnicode(true);

            modelBuilder.Entity<Revers>()
                .Property(e => e.BrRevers)
                .IsUnicode(true);

            modelBuilder.Entity<Uredjaj>()
                .Property(e => e.S_N)
                .IsUnicode(false);

            modelBuilder.Entity<Uredjaj>()
                .Property(e => e.Tip)
                .IsUnicode(true);

            modelBuilder.Entity<Uredjaj>()
                .Property(e => e.Detalji)
                .IsUnicode(true);

            modelBuilder.Entity<Uredjaj>()
                .HasMany(e => e.Dostavnice)
                .WithRequired(e => e.Uredjaj)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Uredjaj>()
                .HasMany(e => e.Nalozi)
                .WithRequired(e => e.Uredjaj)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Uredjaj>()
                .HasMany(e => e.RedovniServisi)
                .WithRequired(e => e.Uredjaj)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Uredjaj>()
                .HasMany(e => e.Reversi)
                .WithRequired(e => e.Uredjaj)
                .WillCascadeOnDelete(true);
        }
    }
}
