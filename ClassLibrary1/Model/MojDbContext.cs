using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Model
{
    public class MojDbContext : IdentityDbContext<AppUser>
    {
        public MojDbContext(DbContextOptions<MojDbContext> options) : base(options)
        {

        }

        public DbSet<Cast> Cast { get; set; }
        public DbSet<CastPerson> CastPerson { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<CrewPerson> CrewPerson { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaCompany> MediaCompany { get; set; }
        public DbSet<MediaGenre> MediaGenre { get; set; }
        public DbSet<MediaLocation> MediaLocation { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<MistakeTickets> MistakeTickets { get; set; }
        public DbSet<MistakeTicketType> MistakeTicketType { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsType> NewsType { get; set; }
        public DbSet<Occupation> Occupation{ get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonOccupation> PersonOccupation { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<SoundMix> SoundMix { get; set; }
        public DbSet<SoundtrackPerson> SoundtrackPerson { get; set; }
        public DbSet<Soundtracks> Soundtracks { get; set; }
        public DbSet<TechnicalSpecifications> TechnicalSpecifications { get; set; }
        //public DbSet<AppUser> User { get; set; }
        public DbSet<UserRating> UserRating { get; set; }
        public DbSet<UserTickets> UserTickets { get; set; }
        public DbSet<UserTicketType> UserTicketType { get; set; }
        //public DbSet<UserType> UserType { get; set; }
        //public DbSet<WatchList> WatchList { get; set; }
        public DbSet<WatchListMedia> WatchListMedia { get; set; }
        public DbSet<WatchStatus> WatchStatus{ get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Bans> Bans { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //optionsBuilder.UseSqlServer(@"Server=localhost;
        //    //                                            Database=MyEntertainmentHubTest;
        //    //                                            Trusted_Connection=True;
        //    //                                            MultipleActiveResultSets=true;");

        //    optionsBuilder.UseSqlServer(@"Server=app.fit.ba,1431;
        //                                                Database=p1752_MEH;
        //                                                Trusted_Connection=False;
        //                                                MultipleActiveResultSets=true;
        //                                                User ID=MEH_user;
        //                                                Password=^xb56C4z");
        //}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
