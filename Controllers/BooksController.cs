using Microsoft.AspNetCore.Mvc;
using BookQuoteAPI.Models;

namespace BookQuoteAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    // Tillfällig minneslista – i riktig app är detta en databas
    private static List<Book> books = new();

    [HttpGet]
    public ActionResult<List<Book>> GetBooks() => books;

    [HttpPost]
    public ActionResult AddBook(Book book)
    {
        book.Id = books.Count + 1;
        books.Add(book);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateBook(int id, Book updated)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();

        book.Title = updated.Title;
        book.Author = updated.Author;
        book.PublishedDate = updated.PublishedDate;
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null) return NotFound();

        books.Remove(book);
        return Ok();
    }
}