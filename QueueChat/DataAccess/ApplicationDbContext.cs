﻿using Microsoft.EntityFrameworkCore;
using QueueChat.Models;

namespace QueueChat.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public DbSet<ChatMember> ChatMembers { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
    }
}
