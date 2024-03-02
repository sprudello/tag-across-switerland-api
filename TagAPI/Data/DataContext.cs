﻿using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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
        public DbSet<TransportationType> Transportations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //USERCHALLENGE S
            // Define relationships and any configuration for the GroupChallenge entity
            modelBuilder.Entity<UserChallenge>()
                .HasKey(g => g.UserChallengeID); // Primary Key

            modelBuilder.Entity<UserChallenge>()
                .HasOne<User>(g => g.User) // Define the relationship to Group
                .WithMany() // Assuming Group has a collection of GroupChallenges
                .HasForeignKey(g => g.UserID); // Foreign Key

            modelBuilder.Entity<UserChallenge>()
                .HasOne<ChallengeCard>(g => g.ChallengeCard) // Define the relationship to ChallengeCard
                .WithMany() // Assuming ChallengeCard can be related to many GroupChallenges
                .HasForeignKey(g => g.CardID); // Foreign Key
                                               //USERCHALLENGE E

            //USERTRANSACTION S
            // Define the primary key for the GroupTransaction
            modelBuilder.Entity<UserTransaction>()
                .HasKey(gt => gt.TransactionID);

            // Define the foreign key relationship between GroupTransactions and Groups
            modelBuilder.Entity<UserTransaction>()
                .HasOne<User>(gt => gt.User)
                .WithMany() // Assuming a Group can have many transactions
                .HasForeignKey(gt => gt.UserID);
            //USERTRANSACTION E

            //USERITEM S
            modelBuilder.Entity<UserItem>()
           .HasKey(gi => gi.UserItemID);

            // Define foreign key relationship between GroupItems and Groups
            modelBuilder.Entity<UserItem>()
                .HasOne<User>(gi => gi.User)
                .WithMany() // Assuming a Group can have many items
                .HasForeignKey(gi => gi.UserID);

            // Define foreign key relationship between GroupItems and Items
            modelBuilder.Entity<UserItem>()
                .HasOne<Item>(gi => gi.Item)
                .WithMany() // Assuming an Item can be associated with many group purchases
                .HasForeignKey(gi => gi.ItemID);
            //USERITEM E

            //USERTRANSPORTATION S
            modelBuilder.Entity<UserTransportation>()
           .HasKey(gt => gt.UserTransportID);

            // Define foreign key relationship between GroupTransportation and Groups
            modelBuilder.Entity<UserTransportation>()
                .HasOne<User>(gt => gt.User)
                .WithMany() // Assuming a Group can have many transportation records
                .HasForeignKey(gt => gt.UserID);

            // Define foreign key relationship between GroupTransportation and TransportationModes
            modelBuilder.Entity<UserTransportation>()
                .HasOne<TransportationType>(gt => gt.TransportationType)
                .WithMany() // Assuming a TransportationMode can be used in many group transportations
                .HasForeignKey(gt => gt.TypeID);
            //USERTRANSPORTATION E
        }

    }
}
