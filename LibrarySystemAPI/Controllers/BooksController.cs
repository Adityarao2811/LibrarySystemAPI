using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibrarySystemAPI
{
    public class BooksController : ApiController
    {
        // GET api/values
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET api/values/5
        
        /*public BooksResponse Get()
        {
            return BookService.GetBooks();
        }*/
        
        public BooksResponse Get(int filter)
        {
            return BookService.GetBooks(filter);
        }

        // POST api/values
        public Response Post([FromBody] AddBookRequest addBookRequest)
        {
            return BookService.AddBook(addBookRequest);
        }

        // PUT api/values/5
        /*
       public void Put(int id, [FromBody] string value)
        {
        }
    
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        */
    }
}
