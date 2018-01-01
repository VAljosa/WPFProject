namespace DemoDiplomski.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TehnoklinikModel : DbContext
    {
        public TehnoklinikModel()
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
        public virtual DbSet<VandredniServis> VandredniServisi { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TehnoklinikModel>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deo>()
                .Property(e => e.K_Broj)
                .IsUnicode(false);

            modelBuilder.Entity<Deo>()
                .Property(e => e.Naziv)
                .IsUnicode(true);

            modelBuilder.Entity<Deo>()
                .Property(e => e.Cena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Deo>()
                .HasMany(e => e.Nalozi)
                .WithMany(e => e.Delovi)
                .Map(m => m.ToTable("NalogDeo").MapLeftKey("IDDeo").MapRightKey("IDNalog"));

            modelBuilder.Entity<Deo>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.Delovi)
                .Map(m => m.ToTable("UredjajDeo").MapLeftKey("IDDeo").MapRightKey("IDUredjaj"));

            modelBuilder.Entity<Dostavnica>()
                .Property(e => e.BrDostavnica)
                .IsUnicode(false);

            modelBuilder.Entity<Dostavnica>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.Dostavnice)
                .Map(m => m.ToTable("DostavnicaUredjaj").MapLeftKey("IDDostavnica").MapRightKey("IDUredjaj"));

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
                .Property(e => e.Telefon)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Adresa)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Drzava)
                .IsUnicode(true);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Dostavnice)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Nalozi)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .HasMany(e => e.Reversi)
                .WithRequired(e => e.Korisnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Ime)
                .IsUnicode(true);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Prezime)
                .IsUnicode(true);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Uloga)
                .IsUnicode(false);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.KorisnickoIme)
                .IsUnicode(true);

            modelBuilder.Entity<LogKorisnik>()
                .Property(e => e.Lozinka)
                .IsUnicode(false);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.BrRadNalog)
                .IsUnicode(true);

            modelBuilder.Entity<Nalog>()
                .Property(e => e.Komentar)
                .IsUnicode(true);

            modelBuilder.Entity<Nalog>()
                .HasMany(e => e.VandredniServisi)
                .WithRequired(e => e.Nalog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nalog>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.Nalozi)
                .Map(m => m.ToTable("NalogUredjaj").MapLeftKey("IDNalog").MapRightKey("IDUredjaj"));

            modelBuilder.Entity<RedovanServis>()
                .Property(e => e.OpisPosla)
                .IsUnicode(true);

            modelBuilder.Entity<RedovanServis>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.RedovniServisi)
                .Map(m => m.ToTable("RedovanServisUredjaj").MapLeftKey("IDRedovanServis").MapRightKey("IDUredjaj"));

            modelBuilder.Entity<Revers>()
                .Property(e => e.BrRevers)
                .IsUnicode(true);

            modelBuilder.Entity<Revers>()
                .HasMany(e => e.Uredjaji)
                .WithMany(e => e.Reversi)
                .Map(m => m.ToTable("ReversUredjaj").MapLeftKey("IDRevers").MapRightKey("IDUredjaj"));

            modelBuilder.Entity<Uredjaj>()
                .Property(e => e.S_N)
                .IsUnicode(true);

            modelBuilder.Entity<Uredjaj>()
                .Property(e => e.Tip)
                .IsUnicode(true);

            modelBuilder.Entity<Uredjaj>()
                .Property(e => e.Detalji)
                .IsUnicode(true);

            modelBuilder.Entity<Uredjaj>()
                .HasMany(e => e.VandredniServisi)
                .WithMany(e => e.Uredjaji)
                .Map(m => m.ToTable("VandredniServisUredjaj").MapLeftKey("IDUredjaj").MapRightKey("IDVandredniServis"));

            modelBuilder.Entity<VandredniServis>()
                .Property(e => e.OpisPosla)
                .IsUnicode(true);
        }
    }
}
