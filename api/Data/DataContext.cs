using System;
using api.Entities;
using API.Domain;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
    IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<UserInvite> Invites { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogPhoto> BlogPhotos { get; set; }
        public DbSet<EventAttendee> EventAttendees { get; set; }
        public DbSet<UserFollowing> UserFollowings { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.EnableSensitiveDataLogging();
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFollowing>(b => {
                b.HasKey(k => new {k.ObserverId, k.TargetId});
                b.HasOne(o => o.Observer)
                    .WithMany(f => f.Followings)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Cascade);
                b.HasOne(o => o.Target)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(o => o.TargetId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<EventAttendee>(x => x.HasKey(ea => new { ea.AppUserId, ea.EventId}));

            builder.Entity<EventAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Events)
                .HasForeignKey(ea => ea.AppUserId);

            builder.Entity<EventAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Events)
                .HasForeignKey(ea => ea.EventId);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
               

            builder.Entity<UserInvite>()
                .HasKey(k => new {k.SourceUserId, k.InvitedUserId});

            builder.Entity<UserInvite>()
                .HasOne(s => s.SourceUser)
                .WithMany(i => i.InvitedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserInvite>()
                .HasOne(s => s.InvitedUser)
                .WithMany(i => i.InvitedByUsers)
                .HasForeignKey(s => s.InvitedUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesRecieved)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public static class UtcDateAnnotation
    {
        private const String IsUtcAnnotation = "IsUtc";
        private static readonly ValueConverter<DateTime, DateTime> UtcConverter =
            new ValueConverter<DateTime, DateTime>(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        private static readonly ValueConverter<DateTime?, DateTime?> UtcNullableConverter =
            new ValueConverter<DateTime?, DateTime?>(v => v, v => v == null ? v : DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));

        public static PropertyBuilder<TProperty> IsUtc<TProperty>(this PropertyBuilder<TProperty> builder, Boolean isUtc = true) =>
            builder.HasAnnotation(IsUtcAnnotation, isUtc);

        public static Boolean IsUtc(this IMutableProperty property) =>
            ((Boolean?)property.FindAnnotation(IsUtcAnnotation)?.Value) ?? true;

        /// <summary>
        /// Make sure this is called after configuring all your entities.
        /// </summary>
        public static void ApplyUtcDateTimeConverter(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
            foreach (var property in entityType.GetProperties())
            {
                if (!property.IsUtc())
                {
                continue;
                }

                if (property.ClrType == typeof(DateTime))
                {
                property.SetValueConverter(UtcConverter);
                }

                if (property.ClrType == typeof(DateTime?))
                {
                property.SetValueConverter(UtcNullableConverter);
                }
            }
        }
    }
}
    
}