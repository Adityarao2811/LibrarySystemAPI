using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibrarySystemAPI
{
    public static class BooksDBReader
    {
        public static Response AddBook(AddBookRequest addBookRequest)
        {
            Response response = new Response();
            if(!AuthorDBReader.CheckIfAuthorExists(addBookRequest.AuthorName))
            {
                response.Message = KeyStore.AuthorDoesNotExistMessage;
                response.Status = Status.Failure;
                return response;
            }
            using (StreamWriter writer = new StreamWriter(KeyStore.BooksDBFilePath, true))
            {
                writer.WriteLine(addBookRequest.AuthorName +" "+ addBookRequest.BookName +" Available");
                response.Status = Status.Success;
                return response;
            }
        }
        
        public static BooksResponse GetAvailableBooks(bool isAvailable)
        {
            
            var books = new List<Books>();
            string[] lines = File.ReadAllLines(KeyStore.BooksDBFilePath);
            foreach (string line in lines)
            {
                if (line.Contains("Available") == isAvailable)
                {
                    books.Add(
                        new Books()
                        {
                            BookName = line.Split()[1],
                            AuthorName = line.Split()[0],
                            BorrowerName = line.Split()[2]
                        }

                     );
                }
               
            }

            return new BooksResponse()
            {
                Books = books,
                Status = Status.Success
            };

        }
    }
}
