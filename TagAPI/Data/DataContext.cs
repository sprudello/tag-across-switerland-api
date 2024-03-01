using Microsoft.EntityFrameworkCore;
using TagAPI.Models;

namespace TagAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<User> Groups { get; set; }
        public DbSet<UserChallenge> GroupChallenges { get; set; }
        public DbSet<UserItem> GroupItems { get; set; }
        public DbSet<UserTransaction> GroupTransactions { get; set; }
        public DbSet<ChallengeCard> ChallengeCards { get; set; }
        public DbSet<UserTransportation> GroupTransportations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TransportationTypes> Transportations { get; set; }

    }
}
