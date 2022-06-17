using LibraryApp.Api.Identity;
using LibraryApp.BL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
      
        private readonly IBookService _bookService;
       
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> BookReserve()
        {

        }
   
    }
}
