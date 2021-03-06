﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using RolePlayedGamesHelper.Repository.EntityFramework.SharpRepository;

namespace RolePlayedGamesHelper.Repository.IntegrationTests.TestObjects
{
    public class TestObjectContext : DbContext, IEfDbContext
    {
        public TestObjectContext(DbConnection connectionString) : base(connectionString, true)
        {
        }

        public DbSet<ContactInt> ContactInts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Node> Nodes { get; set; }

        // set the Compound Key for the User object
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => new { u.Username, u.Age });

            modelBuilder.Entity<Node>()
                        .HasKey(n => n.Id)
                        .Property(n => n.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Node>()
                        .HasOptional(n => n.Parent)
                        .WithMany()
                        .HasForeignKey(n => n.ParentId);
        }
    }
}
