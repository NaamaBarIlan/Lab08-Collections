using System;
using Xunit;
using Lab08_Collections;
using Lab08_Collections.Classes;

namespace XUnitTest_Collections
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddABookToTheLibrary()
        {
            // Arrange - create a library and a book
            Library<Book> testLibrary = new Library<Book>();

            Book testBook = new Book()
            {
                Title = "Best Book",
                Author = new Author() { FirstName = "Jane", LastName = "Smith" },
                Genre = Genre.Romance
            };

            // Act - Add(Book) to the library
            testLibrary.Add(testBook);

            // Assert - does library contain new Book obj?
            Assert.Equal(1, testLibrary.Count());
        }

        [Fact]
        public void CanRemoveABookFromTheLibrary()
        {
            // Arrange - create a library and add 2 books
            Library<Book> testLibrary = new Library<Book>();

            Book testBookOne = new Book()
            {
                Title = "The Great Book",
                Author = new Author() { FirstName = "Jane", LastName = "Smith" },
                Genre = Genre.Romance
            };

            Book testBookTwo = new Book()
            {
                Title = "Second Greatest Book",
                Author = new Author() { FirstName = "Jane", LastName = "Smith" },
                Genre = Genre.Romance
            };

            testLibrary.Add(testBookOne);
            testLibrary.Add(testBookTwo);

            // Act - Remove a book from the library
            Book removedBook = testLibrary.Remove(testBookOne);

            // Assert - does library contain new Book obj?
            Assert.Equal(testBookOne, removedBook);
        }

        [Fact]
        public void GetAndSetBookProperties()
        {
            // Arrange 
            Book testBook = new Book();

            // Act 
            testBook.Title = "The Great Book";

            // Assert 
            Assert.Equal("The Great Book", testBook.Title);
        }

        [Fact]
        public void GetAndSetAuthorProperties()
        {
            // Arrange 
            Author testAuthor = new Author();

            // Act 
            testAuthor.FirstName = "Jane";

            // Assert 
            Assert.Equal("Jane", testAuthor.FirstName);
        }

        [Fact]
        public void CanCountNumberOfBooksInLibrary()
        {
            // Arrange - create a library and add 2 books
            Library<Book> testLibrary = new Library<Book>();

            Book testBookOne = new Book()
            {
                Title = "The Great Book",
                Author = new Author() { FirstName = "Jane", LastName = "Smith" },
                Genre = Genre.Romance
            };

            Book testBookTwo = new Book()
            {
                Title = "Second Greatest Book",
                Author = new Author() { FirstName = "Jane", LastName = "Smith" },
                Genre = Genre.Romance
            };

            testLibrary.Add(testBookOne);
            testLibrary.Add(testBookTwo);

            // Act - count the number of books in the library
            int count = testLibrary.Count();

            // Assert - does library contain 2 books?
            Assert.Equal(count, testLibrary.Count());
        }
    }
}
