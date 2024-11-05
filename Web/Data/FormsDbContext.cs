using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Web.Models;

namespace Web.Data
{
    public class FormsDbContext : DbContext
    {
        public FormsDbContext(DbContextOptions<FormsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageTopic> MessageTopics { get; set; }
    }
}