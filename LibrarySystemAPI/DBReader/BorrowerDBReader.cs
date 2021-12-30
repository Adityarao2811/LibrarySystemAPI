using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace LibrarySystemAPI
{
    public static class BorrowerDBReader
    {
        public static Response AddBorrower(string bookName,string borrower)
        {
            Response response = new Response();
            if (BookIsBorrowed(bookName))
            {
            
                  response.Message = KeyStore.BookIsAlreadyBorrowed;
                  response.Status = Status.Failure;
                  return response; 
            }

            /*using (StreamWriter writer = new StreamWriter(KeyStore.BooksDBFilePath, true))
            {
                writer.WriteLine(bookName+" "+borrower);
            }*/
            string[] lines = File.ReadAllLines(KeyStore.BooksDBFilePath);
            foreach (string line in lines)
            {
                if (line.Contains(bookName) && line.Contains("Available"))
                {
                    string strFile = File.ReadAllText(KeyStore.BooksDBFilePath);
                    string a = line.Replace("Available",borrower);
                    strFile = Regex.Replace(strFile , line, a);
                    File.WriteAllText(KeyStore.BooksDBFilePath, strFile);
                }
            }
                    response.Status = Status.Success;
            return response;
        }
        public static Response ReturnBook(string bookName)
        {
            Response response = new Response();
            if (BookIsBorrowed(bookName))
            {
                string[] lines = File.ReadAllLines(KeyStore.BooksDBFilePath);
                foreach (string line in lines)
                {
                    if (line.Contains(bookName))
                    {
                        string strFile = File.ReadAllText(KeyStore.BooksDBFilePath);
                        string a = line.Replace(line,line.Split()[0]+" "+line.Split()[1]+" "+ "Available");
                        strFile = Regex.Replace(strFile, line, a);
                        File.WriteAllText(KeyStore.BooksDBFilePath, strFile);
                        response.Status = Status.Success;
                        return response;
                    }
                }
                response.Message = KeyStore.BorrowerNameDoesNotMatch;
                return response;
            }
            response.Message = KeyStore.BookIsNotBorrowed;
            response.Status = Status.Failure;
            return response;
        }
    
        private static bool BookIsBorrowed(string bookName)
        {
            string[] lines = File.ReadAllLines(KeyStore.BooksDBFilePath);
            foreach (string line in lines)
            {
                if (line.Contains(bookName) && !line.Contains("Available"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
