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

       
    }
}


//  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             optionsBuilder.UseSqlServer("Server=HALIL\\MSCD8SQLSERVER;Database=NoteAppDb;User=sa;Password=Qwe123.,;Trust Server Certificate=true");
//             base.OnConfiguring(optionsBuilder);
//         }

// Böyle kullanırsak, ne zaman bir AppDbContext'e ihtiyacımız varsa new AppDbContext demek zorundayız biz bunu istemiyoruz.