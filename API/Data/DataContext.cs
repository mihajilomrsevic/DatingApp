namespace API.Data
{
    using API.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        /// <summary>Initializes a new instance of the <see cref="DataContext" /> class.</summary>
        /// <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext">DbContext</see>.</param>
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>Gets or sets the likes.</summary>
        /// <value>The likes.</value>
        public DbSet<UserLike> Likes { get; set; }

        /// <summary>Gets or sets the messages.</summary>
        /// <value>The messages.</value>
        public DbSet<Message> Messages { get; set; }

        /// <summary>Configures the schema needed for the identity framework.</summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // jedan AppUser(korisnik) moze imati vise UserRoles(pravila pristupa)
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            // jedan AppRole(pravilo) moze imati vise UserRoles
            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Govori koji je slozeni kljuc u tabeli Likes
            builder.Entity<UserLike>()
                .HasKey(k => new { k.SourceUserId, k.LikedUserId });
            
            // Jedan AppUser(korisnik) moze da bude lajkovan od vise AppUser(korisnika)
            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
