using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LIBRARY_SYSTEM
{
    public static class AuthorDBReader
    {

        public static Response AddAuthor(string newAuthorName)
        {
            Response response = new Response();
            if(CheckIfAuthorExists(newAuthorName))
            {
                    response.Message = KeyStore.AuthorAlreadyExistsMessage; 
                    response.Status = Status.Failure;
                    return response;
            }
            using (StreamWriter writer = new StreamWriter(KeyStore.AuthorDBFilePath, true))
            {
                writer.WriteLine(newAuthorName);
            }
            response.Status = Status.Success;
            return response;
        }

        public static bool CheckIfAuthorExists(string authorName)
        {
            string[] lines = File.ReadAllLines(KeyStore.AuthorDBFilePath);
            foreach (string line in lines)
            {
                if (string.Equals(authorName, line))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
