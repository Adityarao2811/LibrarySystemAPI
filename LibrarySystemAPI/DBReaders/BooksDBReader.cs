using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LIBRARY_SYSTEM
{
    public static class BooksDBReader
    {
        public static Response AddBook(string authorName, string bookName)
        {
            Response response = new Response();
            if(!AuthorDBReader.CheckIfAuthorExists(authorName))
            {
                response.Message = KeyStore.AuthorDoesNotExistMessage;
                response.Status = Status.Failure;
                return response;
            }
            using (StreamWriter writer = new StreamWriter(KeyStore.BooksDBFilePath, true))
            {
                writer.WriteLine(authorName+" "+bookName+" Available");
                response.Status = Status.Success;
                return response;
            }
        }
        
        public static BooksResponse GetAvailableBooks()
        {
            var books = new List<string>();
            string[] lines = File.ReadAllLines(KeyStore.BooksDBFilePath);
            foreach (string line in lines)
            {
                if (line.Contains("Available"))
                {
                    books.Add(line.Split()[1]);
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
