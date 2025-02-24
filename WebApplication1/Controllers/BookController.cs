using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        ApplecationDBcontext db = new ApplecationDBcontext();
        [HttpGet]
        public IActionResult getAll()
        {
            var books = db.Books.ToList();
            if (books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult getBookpyID(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);

        }
    }
}
