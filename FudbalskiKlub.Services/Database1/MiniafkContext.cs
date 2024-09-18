using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FudbalskiKlub.Services.Database1;

public partial class MiniafkContext : DbContext
{
    public MiniafkContext()
    {
    }

    public MiniafkContext(DbContextOptions<MiniafkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bolest> Bolests { get; set; }

    public virtual DbSet<Clanarina> Clanarinas { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<KorisnikBolest> KorisnikBolests { get; set; }

    public virtual DbSet<KorisnikPozicija> KorisnikPozicijas { get; set; }

    public virtual DbSet<KorisnikTransakcijskiRacun> KorisnikTransakcijskiRacuns { get; set; }

    public virtual DbSet<KorisnikUloga> KorisnikUlogas { get; set; }

    public virtual DbSet<Narudzba> Narudzbas { get; set; }

    public virtual DbSet<NarudzbaStavke> NarudzbaStavkes { get; set; }

    public virtual DbSet<Platum> Plata { get; set; }

    public virtual DbSet<Pozicija> Pozicijas { get; set; }

    public virtual DbSet<Proizvod> Proizvods { get; set; }

    public virtual DbSet<Stadion> Stadions { get; set; }

    public virtual DbSet<Statistika> Statistikas { get; set; }

    public virtual DbSet<Termin> Termins { get; set; }

    public virtual DbSet<TransakcijskiRacun> TransakcijskiRacuns { get; set; }

    public virtual DbSet<Trening> Trenings { get; set; }

    public virtual DbSet<TreningStadion> TreningStadions { get; set; }

    public virtual DbSet<Uloga> Ulogas { get; set; }
    public virtual DbSet<ToDo4924> ToDo4924 { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=miniafk; user=sa1; Password=ASDqwe123!; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bolest>(entity =>
        {
            entity.HasKey(e => e.BolestId).HasName("PK__Bolest__345EDD63C1FF3573");

            entity.ToTable("Bolest");

            entity.Property(e => e.SifraPovrede)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipPovrede)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Clanarina>(entity =>
        {
            entity.HasKey(e => e.ClanarinaId).HasName("PK__Clanarin__C51E3B9744FDF577");

            entity.ToTable("Clanarina");

            entity.Property(e => e.DatumPlacanja).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Clanarinas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikClanarina");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.KorisnikId).HasName("PK__Korisnik__80B06D41D28B3EED");

            entity.ToTable("Korisnik");

            entity.Property(e => e.DatumRodjenja).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KorisnickoIme)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LozinkaHash)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LozinkaSalt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PodUgovoromDo).HasColumnType("datetime");
            entity.Property(e => e.PodUgovoromOd).HasColumnType("datetime");
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StrucnaSprema)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Uloga)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KorisnikBolest>(entity =>
        {
            entity.HasKey(e => e.KorisnikBolestId).HasName("PK__Korisnik__8ECF77DF3087028A");

            entity.ToTable("KorisnikBolest");

            entity.HasOne(d => d.Bolest).WithMany(p => p.KorisnikBolests)
                .HasForeignKey(d => d.BolestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BolestKorisnikBolest");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikBolests)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikKorisnikBolest");
        });

        modelBuilder.Entity<KorisnikPozicija>(entity =>
        {
            entity.HasKey(e => e.KorisnikPozicijaId).HasName("PK__Korisnik__F374D25700F98E73");

            entity.ToTable("KorisnikPozicija");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikPozicijas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikKorisnikPozicija");

            entity.HasOne(d => d.Pozicija).WithMany(p => p.KorisnikPozicijas)
                .HasForeignKey(d => d.PozicijaId)
                .HasConstraintName("FK_PozicijaKorisnikPozicija");
        });

        modelBuilder.Entity<KorisnikTransakcijskiRacun>(entity =>
        {
            entity.HasKey(e => e.KorisnikTransakcijskiRacunId).HasName("PK__Korisnik__1608726E51D03733");

            entity.ToTable("KorisnikTransakcijskiRacun");

            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikTransakcijskiRacuns)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikKorisnikTransakcijskiRacun");

            entity.HasOne(d => d.TransakcijskiRacun).WithMany(p => p.KorisnikTransakcijskiRacuns)
                .HasForeignKey(d => d.TransakcijskiRacunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransakcijskiRacunKorisnikTransakcijskiRacun");
        });

        modelBuilder.Entity<KorisnikUloga>(entity =>
        {
            entity.HasKey(e => e.KorisnikUlogaId).HasName("PK__Korisnik__1608726E78CD53A3");

            entity.ToTable("KorisnikUloga");

            entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikUlogas)
                .HasForeignKey(d => d.KorisnikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KorisnikKorisnikUloga");

            entity.HasOne(d => d.Uloga).WithMany(p => p.KorisnikUlogas)
                .HasForeignKey(d => d.UlogaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UlogaKorisnikUloga");
        });

        modelBuilder.Entity<Narudzba>(entity =>
        {
            entity.HasKey(e => e.NarudzbaId).HasName("PK__Narudzba__FBEC1377D43365F9");

            entity.ToTable("Narudzba");

            entity.Property(e => e.BrojNarudzba)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Datum).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            //entity.HasOne(d => d.Korisnik).WithMany(p => p.)
            //    .HasForeignKey(d => d.KorisnikId)
            //    .HasConstraintName("FK_NarudzbaProizvod");
        });

        modelBuilder.Entity<NarudzbaStavke>(entity =>
        {
            entity.HasKey(e => e.NarudzbaStavkeId).HasName("PK__Narudzba__7DC8EFED3DA2E1FE");

            entity.ToTable("NarudzbaStavke");

            entity.HasOne(d => d.Narudzba).WithMany(p => p.NarudzbaStavkes)
                .HasForeignKey(d => d.NarudzbaId)
                .HasConstraintName("FK_NarudzbaStavkeNarudzba");

            entity.HasOne(d => d.Proizvod).WithMany(p => p.NarudzbaStavkes)
                .HasForeignKey(d => d.ProizvodId)
                .HasConstraintName("FK_NarudzbaStavkeProizvod");
        });

        modelBuilder.Entity<Platum>(entity =>
        {
            entity.HasKey(e => e.PlataId).HasName("PK__Plata__373F7313BACBD819");

            entity.Property(e => e.DatumSlanja).HasColumnType("datetime");
            entity.Property(e => e.StateMachine)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TransakcijskiRacun).WithMany(p => p.Plata)
                .HasForeignKey(d => d.TransakcijskiRacunId)
                .HasConstraintName("FK_TransakcijskiRacunPlata");
        });

        modelBuilder.Entity<Pozicija>(entity =>
        {
            entity.HasKey(e => e.PozicijaId).HasName("PK__Pozicija__C25169AEA95BEC4D");

            entity.ToTable("Pozicija");

            entity.Property(e => e.KategorijaPozicije)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NazivPozicije)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proizvod>(entity =>
        {
            entity.HasKey(e => e.ProizvodId).HasName("PK__Proizvod__21A8BFF81155EE96");

            entity.ToTable("Proizvod");

            entity.Property(e => e.Kategorija)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sifra)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stadion>(entity =>
        {
            entity.HasKey(e => e.StadionId).HasName("PK__Stadion__DDB3F389E8282FAE");

            entity.ToTable("Stadion");

            entity.Property(e => e.NazivStadiona)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Statistika>(entity =>
        {
            entity.HasKey(e => e.StatistikaId).HasName("PK__Statisti__B718DBB73CB4E6D2");

            entity.ToTable("Statistika");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Statistikas)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikStatistika");
        });

        modelBuilder.Entity<Termin>(entity =>
        {
            entity.HasKey(e => e.TerminId).HasName("PK__Termin__42126C95BA3670B3");

            entity.ToTable("Termin");

            entity.Property(e => e.Rezultat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SifraTermina)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipTermina)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Datum).HasColumnType("datetime");

            entity.HasOne(d => d.Stadion).WithMany(p => p.Termins)
                .HasForeignKey(d => d.StadionId)
                .HasConstraintName("FK_StadionTermin");
        });

        modelBuilder.Entity<TransakcijskiRacun>(entity =>
        {
            entity.HasKey(e => e.TransakcijskiRacunId).HasName("PK__Transakc__2F0E2ED1FF943D6E");

            entity.ToTable("TransakcijskiRacun");

            entity.Property(e => e.AdresaPrebivalista)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BrojRacuna)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NazivBanke)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Korisnik).WithMany(p => p.TransakcijskiRacuns)
                .HasForeignKey(d => d.KorisnikId)
                .HasConstraintName("FK_KorisnikTransakcijski");
        });

        modelBuilder.Entity<Trening>(entity =>
        {
            entity.HasKey(e => e.TreningId).HasName("PK__Trening__3B04A8D37D605210");

            entity.ToTable("Trening");

            entity.Property(e => e.DatumTreninga).HasColumnType("datetime");
            entity.Property(e => e.NazivTreninga)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipTreninga)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TreningStadion>(entity =>
        {
            entity.HasKey(e => e.TreningStadionId).HasName("PK__TreningS__83078871C7602F15");

            entity.ToTable("TreningStadion");

            entity.HasOne(d => d.Stadion).WithMany(p => p.TreningStadions)
                .HasForeignKey(d => d.StadionId)
                .HasConstraintName("FK_StadionTreningStadion");

            entity.HasOne(d => d.Trening).WithMany(p => p.TreningStadions)
                .HasForeignKey(d => d.TreningId)
                .HasConstraintName("FK_TreningTreningStadion");
        });

        modelBuilder.Entity<Uloga>(entity =>
        {
            entity.HasKey(e => e.UlogaId).HasName("PK__Uloga__DCAB23CBA0BD3CE4");

            entity.ToTable("Uloga");

            entity.Property(e => e.NazivUloge)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PodtipUloge)
                .HasMaxLength(50)
                .IsUnicode(false);


        });

        var saltAdmin = KorisnikService.GenerateSalt();
        var saltTrener = KorisnikService.GenerateSalt();
        var saltDoktor = KorisnikService.GenerateSalt();
        var saltIgrac = KorisnikService.GenerateSalt();
        var saltKupac = KorisnikService.GenerateSalt();

        modelBuilder.Entity<Korisnik>().HasData(
            new Korisnik { KorisnikId=1, Ime="Ajdin", Prezime="Admin", KorisnickoIme="ajdo", Email="ajdinaganovic23@gmail.com", Uloga="Administrator", PodUgovorom=true, 
                PodUgovoromOd=DateTime.Now, PodUgovoromDo=new DateTime(2026, 08, 08), StrucnaSprema="VSS", Izbrisan=false, 
                DatumRodjenja=new DateTime(1999, 1, 1, 0, 0, 0), LozinkaSalt=saltAdmin, LozinkaHash=KorisnikService.GenerateHash(saltAdmin, "string") },
            new Korisnik
            {
                KorisnikId = 2, Ime = "Glavni", Prezime = "Trener", KorisnickoIme = "trener1", Email = "trener1@gmail.com", Uloga = "Glavni trener",
                PodUgovorom = true, PodUgovoromOd = DateTime.Now, PodUgovoromDo = new DateTime(2026, 08, 08), StrucnaSprema = "VSS", Izbrisan = false,
                DatumRodjenja = new DateTime(1999, 1, 1, 0, 0, 0), LozinkaSalt = saltTrener, LozinkaHash = KorisnikService.GenerateHash(saltTrener, "string") },
            new Korisnik
            {
                KorisnikId = 3, Ime = "Glavni", Prezime = "Doktor", KorisnickoIme = "doktor1", Email = "doktor1@gmail.com", Uloga = "Doktor",
                PodUgovorom = true, PodUgovoromOd = DateTime.Now, PodUgovoromDo = new DateTime(2026, 08, 08), StrucnaSprema = "VSS", Izbrisan = false,
                DatumRodjenja = new DateTime(1999, 1, 1, 0, 0, 0), LozinkaSalt = saltDoktor, LozinkaHash = KorisnikService.GenerateHash(saltDoktor, "string") },
            new Korisnik
            {
                KorisnikId = 4, Ime = "Igrac", Prezime = "Prvi", KorisnickoIme = "igrac1", Email = "igrac1@gmail.com", Uloga = "Igrac",
                PodUgovorom = true, PodUgovoromOd = DateTime.Now, PodUgovoromDo = new DateTime(2026, 08, 08), StrucnaSprema = "SSS", Izbrisan = false,
                DatumRodjenja = new DateTime(1999, 1, 1, 0, 0, 0), LozinkaSalt = saltIgrac, LozinkaHash = KorisnikService.GenerateHash(saltIgrac, "string") },

            new Korisnik
            {
                KorisnikId = 5, Ime = "Kupac", Prezime = "Prvi", KorisnickoIme = "kupac1", Email = "kupac1@gmail.com", Uloga = "Kupac",
                PodUgovorom = true, PodUgovoromOd = DateTime.Now, PodUgovoromDo = new DateTime(2026, 08, 08), StrucnaSprema = "VSS", Izbrisan = false,
                DatumRodjenja = new DateTime(1999, 1, 1, 0, 0, 0), LozinkaSalt = saltKupac, LozinkaHash = KorisnikService.GenerateHash(saltKupac, "string") }

            );

        modelBuilder.Entity<Bolest>().HasData(
            new Bolest { BolestId=1, Izbrisan=false, SifraPovrede="RK1", TipPovrede="Prijelom koljena", TrajanjePovredeDani=30}

            );

        modelBuilder.Entity<Clanarina>().HasData(
            new Clanarina { ClanarinaId=1, DatumPlacanja=DateTime.Now, Dug=0, Izbrisan=false, KorisnikId=4, Placena=false, IznosClanarine=60 }
            );

        modelBuilder.Entity<Pozicija>().HasData(
            new Pozicija { PozicijaId = 1, Izbrisan=false, NazivPozicije="Centarfor", KategorijaPozicije="Napad" },
            new Pozicija { PozicijaId = 2, Izbrisan=false, NazivPozicije="Srednji vezni", KategorijaPozicije="Vezni red" },
            new Pozicija { PozicijaId = 3, Izbrisan=false, NazivPozicije="Srednji stoper", KategorijaPozicije="Odbrana" },
            new Pozicija { PozicijaId = 4, Izbrisan=false, NazivPozicije="Ofanzivni vezni", KategorijaPozicije="Vezni red" },
            new Pozicija { PozicijaId = 5, Izbrisan=false, NazivPozicije="Golman", KategorijaPozicije="Odbrana" }

            );

        modelBuilder.Entity<KorisnikPozicija>().HasData(
            new KorisnikPozicija { KorisnikPozicijaId=1, KorisnikId=4, PozicijaId=1}
            );

        modelBuilder.Entity<Narudzba>().HasData(
            new Narudzba { NarudzbaId=1, BrojNarudzba= "AJSDJWAIAfasfh1h23hs", Datum=DateTime.Now, Status="kreirano", KorisnikId=5 }
            );

        modelBuilder.Entity<Proizvod>().HasData(
            new Proizvod { ProizvodId=1, Naziv="Gostujuci dres 24/25", Sifra="GD2425", Kategorija="Dresovi", Cijena=55, Kolicina=50, Izbrisan=false, StateMachine="draft"},
            new Proizvod { ProizvodId=2, Naziv="Domaci dres 24/25", Sifra="DD2425", Kategorija="Dresovi", Cijena=55, Kolicina=50, Izbrisan=false, StateMachine="draft"},
            new Proizvod { ProizvodId=3, Naziv="Sal", Sifra="Sal2425", Kategorija="Dodaci", Cijena=25, Kolicina=150, Izbrisan=false, StateMachine="draft"},
            new Proizvod { ProizvodId=4, Naziv="Fudbalske slicice (5 kom.)", Sifra="FS2425", Kategorija="Razno", Cijena=1, Kolicina=1000, Izbrisan=false, StateMachine="draft"}
            );
        
        modelBuilder.Entity<NarudzbaStavke>().HasData(
            new NarudzbaStavke { NarudzbaStavkeId = 1, NarudzbaId=1, ProizvodId=1, Kolicina=2 },
            new NarudzbaStavke { NarudzbaStavkeId = 2, NarudzbaId=1, ProizvodId=3, Kolicina=1 },
            new NarudzbaStavke { NarudzbaStavkeId = 3, NarudzbaId=1, ProizvodId=4, Kolicina=20 }
            );


        modelBuilder.Entity<TransakcijskiRacun>().HasData(
            new TransakcijskiRacun { TransakcijskiRacunId=1, BrojRacuna="12341234", AdresaPrebivalista="Mahala b.b.", NazivBanke="Univerzitetskih kredita", KorisnikId=1, Izbrisan=false },
            new TransakcijskiRacun { TransakcijskiRacunId=2, BrojRacuna="47474747", AdresaPrebivalista="Alipasino polje 47", NazivBanke="Lipo halve hamdija", KorisnikId=2, Izbrisan=false }
            );


        modelBuilder.Entity<Platum>().HasData(
            new Platum { PlataId=1, TransakcijskiRacunId=1, StateMachine="active", DatumSlanja=DateTime.Now, Izbrisan=false, Iznos=1200 },
            new Platum { PlataId=2, TransakcijskiRacunId=2, StateMachine="active", DatumSlanja=DateTime.Now, Izbrisan=false, Iznos=900 }
            );

        modelBuilder.Entity<Stadion>().HasData(
            new Stadion { StadionId = 1, NazivStadiona = "Podbrdo", KapacitetStadiona = 2000, Izbrisan = false },
            new Stadion { StadionId = 2, NazivStadiona = "Uzbrdo", KapacitetStadiona = 2000, Izbrisan = false }
            );

        modelBuilder.Entity<Statistika>().HasData(
            new Statistika { StatistikaId=1, Golovi=10, Asistencije=5, IgracMjeseca=false, BezPrimGola=0, 
                ZutiKartoni=2, CrveniKartoni=1, ProsjecnaOcjena=8, OcjenaZadUtak=3, KorisnikId=4, Izbrisan=false }
            );

        modelBuilder.Entity<Termin>().HasData(
            new Termin { TerminId=1, SifraTermina="UTK1", TipTermina="Domaca utakmica", Rezultat="0:0", StadionId=1, Datum=DateTime.Now }
            );

        modelBuilder.Entity<Trening>().HasData(
            new Trening { TreningId=1, NazivTreninga="TPT", TipTreninga="Trening prvog tipa", DatumTreninga=DateTime.Now, Izbrisan=false }
            );

        modelBuilder.Entity<Uloga>().HasData(
            new Uloga { UlogaId=1, NazivUloge="Administrator", PodtipUloge="Administracija", Izbrisan=false },
            new Uloga { UlogaId=2, NazivUloge="Glavni trener", PodtipUloge="Strucni stab", Izbrisan=false },
            new Uloga { UlogaId=3, NazivUloge="Glavni doktor", PodtipUloge="Medicinsko osoblje", Izbrisan=false },
            new Uloga { UlogaId=4, NazivUloge="Igrac", PodtipUloge="Clan", Izbrisan=false },
            new Uloga { UlogaId=5, NazivUloge="Kupac", PodtipUloge="Navijac", Izbrisan=false },
            new Uloga { UlogaId=6, NazivUloge="Bez uloge", PodtipUloge="Bez uloge", Izbrisan=false }
            );



        //OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
