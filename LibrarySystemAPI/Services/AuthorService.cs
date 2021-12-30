using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystemAPI
{
    public static class AuthorService
    {
        public static Response AddAuthor(string authorName)
        {
            return AuthorDBReader.AddAuthor(authorName);
        }
    }
}