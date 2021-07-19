using LockStep.Library.Domain;
using LockStep.Library.Domain.Finance;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockstep.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Author> Authors {get;set;}

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<BookComment> BookComments { get; set; }

        public DbSet<BookGenre> BookGenres { get; set; }

        public DbSet<BookVote> BookVotes { get; set; }

        public DbSet<Check> Checks { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
