using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace LibrarySystemAPI
{
    public class AuthorController : ApiController
    {
        public Response Post([FromBody] string authorName)
        {
            return AuthorService.AddAuthor(authorName);
        }
    }  
}