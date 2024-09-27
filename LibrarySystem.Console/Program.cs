using Azure;
using LibrarySystem.Data;
using LibrarySystem.Domain;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    public static void DisplayBooks(IQueryable<Book> books)
    {
        foreach(var book in books)
        {
            Console.WriteLine($"Book Title = {book.Title} \t Author = {book.Author.Name} \t Genre = {book.Genre}");
        }
    }
    public static void DisplayAuthors(IQueryable<Author> authors)
    {
        foreach(var author in authors)
        {
            Console.WriteLine($"Author Name = {author.Name}");
        }
    }
    public static void Main()
    {

        using (LibrarySystemContext context = new LibrarySystemContext())
        {
            var allBooks = context.Books.Select(book => book).ToList();
            var allAuthors = context.Authors.Select(author => author).ToList();
            // Link books to authors

            foreach (var book in allBooks)
            {
                var author = allAuthors.FirstOrDefault(a => a.Id == book.AuthorId);
                if (author != null)
                {
                    author.Books.Add(book);
                    book.Author = author;
                }

                
            }

            //2.Retrieve all books with the genre "Science Fiction".
            var scienceFictionBooks = context.Books.Where(book => book.Genre == "Science Fiction");
            DisplayBooks(scienceFictionBooks);
            //Output
            //Book Title = Foundation          Author = Isaac Asimov Genre = Science Fiction
            //Book Title = Rendezvous with Rama        Author = Arthur C.Clarke Genre = Science Fiction
            //Book Title = Childhood's End     Author = Arthur C. Clarke       Genre = Science Fiction
            //Book Title = Foundation and Empire       Author = Isaac Asimov Genre = Science Fiction

            //3.Find all authors who have written more than 3 books.
            var authorsWrittenMoreThreeBooks = context.Authors.Where(author => author.Books.Count() > 3);
            DisplayAuthors(authorsWrittenMoreThreeBooks);
            //Output
            // No author
            //4.Retrieve all books along with their authors using eager loading then print the book's title and   it's      author's name.
            var books = context.Books.Select(book => new {book.Title , AuthorName = book.Author.Name}).ToList();
            foreach(var book in books)
            {
                Console.WriteLine($"Book Title = {book.Title} \t Author = {book.AuthorName} ");
            }
            //Output
            //Book Title = Foundation          Author = Isaac Asimov
            //Book Title = Harry Potter and the Philosopher's Stone    Author = J.K. Rowling
            //Book Title = 1984        Author = George Orwell
            //Book Title = Pride and Prejudice         Author = Jane Austen
            //Book Title = Rendezvous with Rama        Author = Arthur C.Clarke
            //Book Title = Harry Potter and the Chamber of Secrets     Author = J.K.Rowling
            //Book Title = Animal Farm Author = George Orwell
            //Book Title = Emma        Author = Jane Austen
            //Book Title = Childhood's End     Author = Arthur C. Clarke
            //Book Title = Foundation and Empire       Author = Isaac Asimov

            //5.Find the author with the earliest birth date.
            var earliestAuthor = context.Authors.OrderBy(author => author.BirthDate).FirstOrDefault();
            Console.WriteLine($"Author Name = {earliestAuthor?.Name} \t BirthDate = {earliestAuthor?.BirthDate}");
            //Output
            //Author Name = Jane Austen BirthDate = 12 / 16 / 1775 12:00:00 AM
            //6.Calculate the average number of books written by each author.
            var averageOfBooksWrittenByEachAuthor = context.Authors.Select(author => new {Name = author.Name,Average = author.Books.Average(book => book.Id) });
            foreach( var author in averageOfBooksWrittenByEachAuthor)
            {
                Console.WriteLine($" Author name = {author.Name} \t Average = {author.Average}");
            }
            //Output
            //Author name = Isaac Asimov Average = 5.5
            //Author name = J.K.Rowling      Average = 6.333333333333333
            //Author name = George Orwell Average = 5
            //Author name = Jane Austen Average = 6
            //Author name = Arthur C.Clarke Average = 7

            //7.Group books by their genre and display the count of books in each genre.
            var groupedBooks = context.Books.GroupBy(book => book.Genre);
            foreach( var genre in groupedBooks)
            {
                Console.WriteLine($"Genre = {genre.Key}");
                foreach(var book in genre)
                {
                    Console.WriteLine($"Title = {book.Title} \t Author = {book.Author.Name} \t Genre = {book.Genre}");
                }
            }
            //Output
            //Genre = Classic
            //Title = Pride and Prejudice      Author = Jane Austen Genre = Classic
            //Title = Emma     Author = Jane Austen Genre = Classic
            //Genre = computer science
            //Title = Physics and computer science Author = J.K.Rowling   Genre = computer science
            //Genre = Dystopian
            //Title = 1984     Author = George Orwell Genre = Dystopian
            //Genre = Fantasy
            //Title = Harry Potter and the Chamber of Secrets          Author = J.K.Rowling   Genre = Fantasy
            //Title = Harry Potter and the Philosopher's Stone         Author = J.K. Rowling   Genre = Fantasy
            //Genre = Political Satire
            //Title = Animal Farm Author = George Orwell Genre = Political Satire
            //Genre = Science Fiction
            //Title = Childhood's End          Author = Arthur C. Clarke       Genre = Science Fiction
            //Title = Foundation and Empire    Author = Isaac Asimov Genre = Science Fiction
            //Title = Foundation       Author = Isaac Asimov Genre = Science Fiction
            //Title = Rendezvous with Rama     Author = Arthur C.Clarke Genre = Science Fiction
            //8.Check if there are any authors who have not written any books.
            var authors = context.Authors.Where(author => author.Books.Count() == 0);
            DisplayAuthors(authors);
            //No Author
            //9.Find all books where the author's name starts with the letter "J".
            var authorsName = context.Authors.Select(author => author.Name).Where(name => name.StartsWith("J"));
            foreach(var author in authorsName)
            {
                Console.WriteLine(author);
            }
            //Output
            //J.K.Rowling
            //Jane Austen
            //10.Add a new property of type "DateOnly" and call it "PublicationYear" then update your databse.
            //Ok
            //11.Find all books published after the year 2000.
           
            var booksPublishedAfteryear2000 = context.Books.Where(book => book.PublicationYear.Year > 2000);
            DisplayBooks(booksPublishedAfteryear2000);
            //Output
            // Book Title = Physics and computer science Author = J.K.Rowling   Genre = computer science

            //12.Get the most recently published book for each author.
            var recentlyPublishedBook = context.Authors.Select(author => new { AuthorName = author.Name, RecentlyPublishedBook = author.Books.Max(book => book.Title) });
            foreach( var book in recentlyPublishedBook)
            {
                Console.WriteLine($"Author name = {book.AuthorName} \t Publishing date = {book.RecentlyPublishedBook}");
            }
            //Output
            //Author name = Isaac Asimov Publishing date = Foundation and Empire
            //Author name = J.K.Rowling       Publishing date = Physics and computer science
            //Author name = George Orwell Publishing date = Animal Farm
            //Author name = Jane Austen Publishing date = Pride and Prejudice
            //Author name = Arthur C.Clarke Publishing date = Rendezvous with Rama
        }
    }
}