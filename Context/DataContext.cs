using Microsoft.EntityFrameworkCore;

namespace Tickets.API.Models
{
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> option)
            : base(option) { }

        public DbSet<Ticket> Tickets { get; set; }


        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=tickets2;Data Source=DESKTOP-AS1PBTC");
        }*/

        /*protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Ticket>(entity => {
                entity.ToTable("Tickets");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.AuthorName).IsRequired();
                entity.Property(p => p.Date).IsRequired();
            });

            #region TicketSeed
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket() {Id = 1, Description = "Lâmpada queimada", AuthorName = "Washington", Date = "26/11/2019"},
                new Ticket() {Id = 2, Description = "Pintar parede", AuthorName = "Pedro", Date = "12/12/2019"},
                new Ticket() {Id = 3, Description = "Monitor com defeito", AuthorName = "João", Date = "07/01/2020"},
                new Ticket() {Id = 4, Description = "Monitor com defeito2", AuthorName = "João2", Date = "07/01/2020222"});
            #endregion
        }*/
    }
}