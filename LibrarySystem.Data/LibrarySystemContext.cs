using LibrarySystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data
{
    public class LibrarySystemContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Establish the conection string
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AAT1VEH;Initial Catalog=LibrarySystemDB;Integrated Security=True;Encrypt=False")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                ;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                 new Author
                 {
                     Id = 1,
                     Name = "Isaac Asimov",
                     BirthDate = new DateTime(1920, 1, 2),
                     Books = new List<Book>() // Books will be added later
                 },
                 new Author
                 {
                     Id = 2,
                     Name = "J.K. Rowling",
                     BirthDate = new DateTime(1965, 7, 31),
                     Books = new List<Book>() // Books will be added later
                 },
                 new Author
                 {
                     Id = 3,
                     Name = "George Orwell",
                     BirthDate = new DateTime(1903, 6, 25),
                     Books = new List<Book>() // Books will be added later
                 },
                 new Author
                 {
                     Id = 4,
                     Name = "Jane Austen",
                     BirthDate = new DateTime(1775, 12, 16),
                     Books = new List<Book>() // Books will be added later
                 },
                 new Author
                 {
                     Id = 5,
                     Name = "Arthur C. Clarke",
                     BirthDate = new DateTime(1917, 12, 16),
                     Books = new List<Book>() // Books will be added later
                 }
            );
                 modelBuilder.Entity<Book>().HasData(
                     new Book
                     {
                         Id = 1,
                         Title = "Foundation",
                         Genre = "Science Fiction",
                         AuthorId = 1, // Isaac Asimov
                     },
                 new Book
                 {
                     Id = 2,
                     Title = "Harry Potter and the Philosopher's Stone",
                     Genre = "Fantasy",
                     AuthorId = 2, // J.K. Rowling
                 },
                 new Book
                 {
                     Id = 3,
                     Title = "1984",
                     Genre = "Dystopian",
                     AuthorId = 3, // George Orwell
                 },
                 new Book
                 {
                     Id = 4,
                     Title = "Pride and Prejudice",
                     Genre = "Classic",
                     AuthorId = 4, // Jane Austen
                 },
                 new Book
                 {
                     Id = 5,
                     Title = "Rendezvous with Rama",
                     Genre = "Science Fiction",
                     AuthorId = 5, // Arthur C. Clarke
                 },
                 new Book
                 {
                     Id = 6,
                     Title = "Harry Potter and the Chamber of Secrets",
                     Genre = "Fantasy",
                     AuthorId = 2, // J.K. Rowling
                 },
                 new Book
                 {
                     Id = 7,
                     Title = "Animal Farm",
                     Genre = "Political Satire",
                     AuthorId = 3, // George Orwell
                 },
                 new Book
                 {
                     Id = 8,
                     Title = "Emma",
                     Genre = "Classic",
                     AuthorId = 4, // Jane Austen
                 },
                 new Book
                 {
                     Id = 9,
                     Title = "Childhood's End",
                     Genre = "Science Fiction",
                     AuthorId = 5, // Arthur C. Clarke
                 },
                 new Book
                 {
                     Id = 10,
                     Title = "Foundation and Empire",
                     Genre = "Science Fiction",
                     AuthorId = 1, // Isaac Asimov
                 });
        }
    }
}
