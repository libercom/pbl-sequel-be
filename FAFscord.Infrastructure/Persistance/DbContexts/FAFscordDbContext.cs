using FAFscord.Domain;
using FAFscord.Infrastructure.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace FAFscord.Infrastructure.Persistance.DbContexts
{
    public class FAFscordDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AcademicGroup> AcademicGroups { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatRole> ChatRoles { get; set; }
        public DbSet<ChatStudent> ChatStudents { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Chats)
                .WithMany(x => x.Users)
                .UsingEntity<ChatStudent>(
                    t => t.HasOne(pt => pt.Chat)
                          .WithMany(pt => pt.ChatStudents)
                          .HasForeignKey(pt => pt.ChatId),
                    t => t.HasOne(pt => pt.User)
                          .WithMany(pt => pt.ChatStudents)
                          .HasForeignKey(x => x.UserId),
                    t =>
                    {
                        t.HasKey(pt => new { pt.UserId, pt.ChatId });
                    });

            modelBuilder.Entity<ChatStudent>()
                .HasMany(x => x.Messages)
                .WithOne(x => x.ChatStudent)
                .HasForeignKey(x => new { x.UserId, x.ChatId })
                .IsRequired();

            modelBuilder.Entity<ChatStudent>()
                .Navigation(x => x.Role)
                .AutoInclude();

            modelBuilder.Entity<ChatStudent>()
                .Navigation(x => x.User)
                .AutoInclude();

            modelBuilder.Entity<ChatStudent>()
                .Navigation(x => x.Chat)
                .AutoInclude();

            modelBuilder.Entity<ChatStudent>()
                .Navigation(x => x.Messages)
                .AutoInclude();

            modelBuilder.Entity<Chat>()
                .Navigation(x => x.ChatStudents)
                .AutoInclude();

            modelBuilder.SeedChatRole();
        }

        public FAFscordDbContext(DbContextOptions<FAFscordDbContext> options) : base(options)
        {

        }
    }
}
