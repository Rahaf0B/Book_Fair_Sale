using BookFair.Models;
using BookFair.Serializable;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace BookFair.Controllers
{


    public class BookController
    {
        private static BookController _instance;

        private BookController() { }

        public static BookController getInstance()
        {
            if (_instance == null)
            {
                _instance = new BookController();
            }
            return _instance;

        }

        public async Task AddBook(Session session, string title, Subject subject, Author author, decimal price, int quantity, string publisher = null, string description = null, string imageurl = null)
        {
            try
            {
                Book book = new Book(session)
                {
                    Subject = subject,
                    Author = author,
                    Title = title,
                    Price = price,
                    Quantity = quantity,
                    Publisher = publisher,
                    Description = description,
                    Image = imageurl

                };
                await session.SaveAsync(book);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<(List<BookInfo>, int)> GetAllBooks(Session session, int PageNumber, int PageSize, string option, string value = null, string secValue = null)
        {
            try
            {


                XPQuery<Book> books = new XPQuery<Book>(session);
                XPQuery<Subject> subjects = new XPQuery<Subject>(session);
                XPQuery<Author> authors = new XPQuery<Author>(session);


                var booksItem = books.Join(subjects, book => book.Subject, subject => subject, (book, subject) => new
                {
                    book,
                    subject = subject.Title != null ? subject.Title.ToString() : string.Empty,

                }).Join(authors, book => book.book.Author, author => author, (book, author) => new BookInfo
                {


                    id = book.book.Book_id,
                    title = book.book.Title,
                    description = book.book.Description != null ? book.book.Description.ToString() : string.Empty,
                    price = book.book.Price,
                    subject = book.subject,
                    publisher = book.book.Publisher != null ? book.book.Publisher.ToString() : string.Empty,
                    quantity = book.book.Quantity,
                    image = book.book.Image != null ? book.book.Image.ToString() : string.Empty,
                    author = author.Name != null ? author.Name.ToString() : string.Empty,

                }).ToList();

                if (option == "all")
                {
                    return await getAllBooksInfo(booksItem, PageNumber, PageSize);

                }
                else if (option == "search")
                {
                    return await getAllBooksInfoByTitle(booksItem, PageNumber, PageSize, value);
                }
                else if (option == "filter")
                {
                    return await getAllBooksInfoBySubject(booksItem, PageNumber, PageSize, value);

                }
                else if (option == "search&filter")
                {
                    return await getAllBooksInfoByTitleAndSubject(booksItem, PageNumber, PageSize, value, secValue);
                }
                else
                {
                    return await getAllBooksInfo(booksItem, PageNumber, PageSize);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(List<BookInfo>, int)> getAllBooksInfo(List<BookInfo> booksItem, int PageNumber, int PageSize)
        {
            try
            {
                int numberOfItems = booksItem.Count;
                List<BookInfo> dataToBind = await Task.Run(() => booksItem
                   .OrderBy(book => book.id)
                   .Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize)
                   .ToList());

                return (dataToBind, numberOfItems);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<(List<BookInfo>, int)> getAllBooksInfoByTitle(List<BookInfo> booksItem, int PageNumber, int PageSize, string value)
        {
            try
            {
                IEnumerable<BookInfo> dataAfterSearch = booksItem.Where(book => book.title.ToLower().Contains(value.ToLower()));

                int numberOfItems = dataAfterSearch.Count();
                var dataToBind = await Task.Run(() => dataAfterSearch
                   .OrderBy(book => book.id)
                   .Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize)
                   .ToList());

                return (dataToBind, numberOfItems);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<(List<BookInfo>, int)> getAllBooksInfoBySubject(List<BookInfo> booksItem, int PageNumber, int PageSize, string value)
        {
            try
            {
                IEnumerable<BookInfo> dataAfterFilter = booksItem.Where(book => book.subject == value);

                int numberOfItems = dataAfterFilter.Count();
                var dataToBind = await Task.Run(() => dataAfterFilter
                   .OrderBy(book => book.id)
                   .Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize)
                   .ToList());

                return (dataToBind, numberOfItems);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<(List<BookInfo>, int)> getAllBooksInfoByTitleAndSubject(List<BookInfo> booksItem, int PageNumber, int PageSize, string title, string subject)
        {
            try
            {
                IEnumerable<BookInfo> dataAfterFilter = booksItem.Where(book => book.subject == subject && book.title.ToLower().Contains(title.ToLower()));

                int numberOfItems = dataAfterFilter.Count();
                var dataToBind = await Task.Run(() => dataAfterFilter
                   .OrderBy(book => book.id)
                   .Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize)
                   .ToList());

                return (dataToBind, numberOfItems);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<BookInfo> GetBookByID(Session session, int book_id)
        {
            try
            {

                var book = await session.GetObjectByKeyAsync<Book>(book_id);
                if (book != null) {
                    var data = new BookInfo
                    {

                        id = book.Book_id,
                        title = book.Title,
                        description = book.Description != null ? book.Description.ToString() : string.Empty,
                        price = book.Price,
                        subject = book.Subject.Title,
                        publisher = book.Publisher != null ? book.Publisher.ToString() : string.Empty,
                        quantity = book.Quantity,
                        image = book.Image != null ? book.Image.ToString() : string.Empty,
                        author = book.Author.Name != null ? book.Author.Name.ToString() : string.Empty,


                    };


                    return data; }
                return null;


            }catch(System.NullReferenceException ex) { return null; }
            catch (Exception ex)
            {
                throw;

            }
        }



        public async Task<Book> GetBookInstanceByID(Session session, int book_id)
        {
            try
            {

                var book = await session.GetObjectByKeyAsync<Book>(book_id);
                return book;


            }
            catch (Exception ex)
            {
                throw;

            }
        }



        public async Task UpdateBookQuantity(Session session, Book book, int quantity)
        {
            try
            {

                if (book != null)
                {
                    book.Quantity = quantity;

                    await session.SaveAsync(book);
                }


            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<List<Subject>> GetAllSubjects(Session session)
        {
            try
            {

                XPQuery<Subject> subjects = new XPQuery<Subject>(session);

                List<Subject> subjectsInfo = await Task.Run(() => subjects.ToList<Subject>());

                return subjectsInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Subject> GetSingleSubject(Session session, int id)
        {
            try
            {
                Subject subject = await session.GetObjectByKeyAsync<Subject>(id);
                return subject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<Author>> GetAllAuthors(Session session)
        {
            try
            {

                XPQuery<Author> authors = new XPQuery<Author>(session);
                List<Author> authorsInfo = await Task.Run(() => authors.ToList());
                return authorsInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Author> GetSingleAuthor(Session session, int id)
        {
            try
            {
                Author author = await session.GetObjectByKeyAsync<Author>(id);
                return author;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteBook(Session session, Book book)
        {
            try
            {
                await session.DeleteAsync(book);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task EditBook(Session session, Book book, string title, Author author, Subject subject, decimal price, int quantity,string image_url=null, string description = null, string publisher = null)
        {
            try
            {
                if (title != null && title != string.Empty)
                {
                    book.Title = title;
                }
                if (author != null)
                {
                    book.Author = author;
                }
                if (subject != null)
                {
                    book.Subject = subject;
                }
                if (image_url != null)
                {
                    book.Image = image_url;
                }
                if (price != 0)
                {
                    book.Price = price;
                }
                if (quantity != 0)
                {
                    book.Quantity = quantity;
                }
                if (description != null)
                {
                    book.Description = description;
                }
                await session.SaveAsync(book);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}