using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BooksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            return await _context.Books.ToListAsync();
        }

    }
}
