using System;
using Microsoft.EntityFrameworkCore;
using Project01_EFCore_Intro.Models;

namespace Project01_EFCore_Intro.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NoteTag>().HasKey(x=>new {x.NoteId,x.TagId}); // CompositPrimaryKey(Yani notId ve TagId Kolunu bir yapıp iksini bir primary key yaparak aynı kolondan birden fazla kayıt olmasını engellemiş olduk).

            modelBuilder.Entity<Category>().HasData(
                new Category{Id=1,Name="Görevler",Description=string.Empty},
                new Category{Id=2,Name="Yapılacaklar",Description=string.Empty},
                new Category{Id=3,Name="Yemek",Description=string.Empty}
            );

            modelBuilder.Entity<Note>()
                .Property(x=>x.CreatedAt)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Note>().HasData(
                new Note{Id=1,Title="Unutma!",Content="Elektrik Faturasını Yatır",CategoryId=1},
                new Note{Id=2,Title="Dikkat!",Content="Elektrik Faturasını Yatır1",CategoryId=1},
                new Note{Id=3,Title="Acil!",Content="Elektrik Faturasını Yatır2",CategoryId=2},
                new Note{Id=4,Title="Haber!",Content="Elektrik Faturasını Yatır3",CategoryId=3}
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag{Id=1,Title="İş"},
                new Tag{Id=2,Title="Aile"},
                new Tag{Id=3,Title="Arkadaş"},
                new Tag{Id=4,Title="Diğer"}
            );

            modelBuilder.Entity<NoteTag>().HasData(
                new NoteTag{NoteId=1, TagId=1},
                new NoteTag{NoteId=1, TagId=2},
                new NoteTag{NoteId=1, TagId=3},

                new NoteTag{NoteId=2, TagId=2},
                new NoteTag{NoteId=2, TagId=4},

                new NoteTag{NoteId=3, TagId=1},
                new NoteTag{NoteId=3, TagId=2},
                new NoteTag{NoteId=3, TagId=3},

                new NoteTag{NoteId=4, TagId=4}
                
            );
            base.OnModelCreating(modelBuilder);
        }
       
    }
}


//  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseSqlServer("Server=HALIL\\MSCD8SQLSERVER;Database=NoteAppDb;User=sa;Password=Qwe123.,;Trust Server Certificate=true");
//             base.OnConfiguring(optionsBuilder);
//         }

// Böyle kullanırsak, ne zaman bir AppDbContext'e ihtiyacımız varsa new AppDbContext demek zorundayız biz bunu istemiyoruz.