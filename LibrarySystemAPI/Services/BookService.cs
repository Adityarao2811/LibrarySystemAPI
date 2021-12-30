using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemAPI
{
    public static class BookService
    {
        public static Response AddBook(AddBookRequest addBookRequest)
        {
            return BooksDBReader.AddBook(addBookRequest);
        }
        public static BooksResponse GetBooks(int filter =2)
        {
            if (filter == 0)
            {
                return BooksDBReader.GetAvailableBooks(true);
            }
            if(filter==1)
            {
                return BooksDBReader.GetAvailableBooks(false);
            }
            return null;
        }
    }
}