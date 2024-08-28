using BookFair.Classes;
using BookFair.Controllers;
using BookFair.Interfaces;
using BookFair.Models;
using BookFair.Serializable;
using DevExpress.Xpo;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookFair.Services
{
    public class BookService
    {


        private static BookService _instance;
        private BookController _bookInstance = BookController.getInstance();

        private BookService() { }

        public static BookService getInstance()
        {
            if (_instance == null)
            {
                _instance = new BookService();
            }
            return _instance;

        }


        public async Task<(List<BookInfo>, int)> Get_Books_Info(int page_number, int page_size)
        {
            try
            {

                using (Session session = new Session())
                {
                    (List<BookInfo> data, int numberOfItems) = await _bookInstance.GetAllBooks(session, page_number, page_size, "all");
                    return (data, numberOfItems);

                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<(List<BookInfo>, int)> Get_Books_Info_By_Title(int page_number, int page_size, string title)
        {
            try
            {

                using (Session session = new Session())
                {
                    (List<BookInfo> data, int numberOfItems) = await _bookInstance.GetAllBooks(session, page_number, page_size, "search", title);
                    return (data, numberOfItems);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(List<BookInfo>, int)> Get_Books_Info_By_Subject(int page_number, int page_size, string subject)
        {
            try
            {

                using (Session session = new Session())
                {
                    (List<BookInfo> data, int numberOfItems) = await _bookInstance.GetAllBooks(session, page_number, page_size, "filter", subject);
                    return (data, numberOfItems);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<(List<BookInfo>, int)> Get_Books_Info_By_Title_And_Subject(int page_number, int page_size, string title, string subject)
        {
            try
            {

                using (Session session = new Session())
                {
                    (List<BookInfo> data, int numberOfItems) = await _bookInstance.GetAllBooks(session, page_number, page_size, "search&filter", title, subject);
                    return (data, numberOfItems);
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<Subject>> Get_Subjects()
        {
            try
            {
                Session session = new Session();

                List<Subject> Subjects = await _bookInstance.GetAllSubjects(session);
                return Subjects;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<List<Author>> Get_Authors()
        {
            try
            {
                Session session = new Session();

                List<Author> Subjects = await _bookInstance.GetAllAuthors(session);
                return Subjects;

            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public async Task<BookInfo> Get_Book_By_ID(int book_id)
        {
            try
            {

                using (Session session = new Session())
                {
                    BookInfo book = await _bookInstance.GetBookByID(session, book_id);
                    return book;

                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }


        public async Task<bool> Delete_Book(int book_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Book book = await _bookInstance.GetBookInstanceByID(uow, book_id);
                    if (book != null)
                    {
                        await _bookInstance.DeleteBook(uow, book);
                        await uow.CommitChangesAsync();
                        return true;
                    }
                    await uow.CommitChangesAsync();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<(bool, string)> Add_Book(string title, int subject_id, int author_id, decimal price, int quantity, string publisher = null, string description = null, string image_url = null)
        {
            try
            {

                using (UnitOfWork uow = new UnitOfWork())
                {
                    Author author = await _bookInstance.GetSingleAuthor(uow, author_id);

                    Subject subject = await _bookInstance.GetSingleSubject(uow, subject_id);
                    await _bookInstance.AddBook(uow, title, subject, author, price, quantity, publisher, description, image_url);

                    await uow.CommitChangesAsync();
                    return (true, "The Book Is Added To The Store");

                }

            }
            catch (DevExpress.Xpo.DB.Exceptions.ConstraintViolationException ex)
            {

                return (false, "This Book Title Is Taken");
            }

            catch (Exception ex)
            {
                return (false, "Error Ocurred");
            }

        }



        public async Task Edit_Book(int book_id, string title, int author_id, int subject_id, decimal price, int quantity, string image_url=null,string description = null, string publisher = null)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Author author = null;
                    Subject subject = null;
                    if (subject_id != 0)
                    {
                        subject = await _bookInstance.GetSingleSubject(uow, subject_id);
                    }
                    if (author_id != 0)
                    {
                        author = await _bookInstance.GetSingleAuthor(uow, author_id);
                    }

                    Book book = await _bookInstance.GetBookInstanceByID(uow, book_id);
                    if (book != null)
                    {

                        await _bookInstance.EditBook(uow, book, title, author, subject, price, quantity, image_url, description, publisher);
                    }
                    await uow.CommitChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}


