using CommonLayer.RequestModels.BookStore;
using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using RepositoryLayer.Entity;

namespace BookstoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookManager bookManager;
        public BooksController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }
        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBooks(AddBookModel model)
        {
            var response = bookManager.AddBook(model);
            if (response != null)
            {
                return Ok(new ResponseModel<BooksEntity>
                {
                    success = true,
                    Message = "Book Added Successfully",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<BooksEntity>
                {
                    success = false,
                    Message = "Failed Adding Book to Database",
                    Data = response
                });
            }
        }
    }
}
