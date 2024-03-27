using CommonLayer.RequestModels.BookStore;
using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using RepositoryLayer.Entity;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult GetAllBooks()
        {
            var response = bookManager.GetAllBook();
            if (response != null)
            {
                return Ok(new ResponseModel<List<BooksEntity>> { success = true, Message = "Books Displayed", Data = response });
            }
            return BadRequest(new ResponseModel<List<BooksEntity>> { success = false, Message = " Books Displayed Failed", Data = null });
        }

        [HttpGet]
        [Route("GetBookByID")]
        public ActionResult GetBookbyID(int Id)
        {
            var response = bookManager.GetBookByID(Id);
            if (response != null)
            {
                return Ok(new ResponseModel<BooksEntity>
                {
                    success= true,
                    Message="fetched book with bookId",
                    Data=response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<BooksEntity>
                {
                    success = false,
                    Message = "Internal Error, Failed to fetch data",
                    Data = response
                });
            }
        }


        [HttpGet]
        [Route("SortDataByAccendingOrder")]
        public ActionResult SortAndDisplayElementsInAscendingOrder()
        {
            var response = bookManager.SortAndDisplayElementsInAscendingOrder();
            if (response != null)
            {
                return Ok(new ResponseModel<List<BooksEntity>>
                {
                    success = true,
                    Message = "Books Sorted in Ascending Order",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<List<BooksEntity>>
                {
                    success = false,
                    Message = "Failed to sort elements",
                    Data = response
                });
            }
        }
        [HttpGet]
        [Route("SortDataByDescendingOrder")]
        public ActionResult SortBooksByPriceDescending()
        {
            var response = bookManager.SortBooksByPriceDescending();
            if (response != null)
            {
                return Ok(new ResponseModel<List<BooksEntity>>
                {
                    success = true,
                    Message = "Books Sorted in Descending Order",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<List<BooksEntity>>
                {
                    success = false,
                    Message = "Failed to sort elements",
                    Data = response
                });
            }
        }

        [HttpGet]
        [Route("SortByRecentArrival")]
        public ActionResult SortByRecentArrival()
        {
            var response = bookManager.SortByRecentArrival();
            if (response != null)
            {
                return Ok(new ResponseModel<List<BooksEntity>>
                {
                    success = true,
                    Message = "Books Sorted as per recent arrival",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<List<BooksEntity>>
                {
                    success = false,
                    Message = "Failed to sort book as per recent arrival",
                    Data = response
                });
            }
        }


        [HttpGet]
        [Route("SortByOlderArrival")]
        public ActionResult SortByOlderFirstArrival()
        {
            var response = bookManager.SortByOlderFirstArrival();
            if (response != null)
            {
                return Ok(new ResponseModel<List<BooksEntity>>
                {
                    success = true,
                    Message = "Books Sorted as per oldest arrival first",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<List<BooksEntity>>
                {
                    success = false,
                    Message = "Failed to sort book as per older arrival",
                    Data = response
                });
            }
        }

        [HttpGet]
        [Route("Search")]
        public ActionResult Search(string query)
        {
            var response = bookManager.Search(query);
            if (response != null)
            {
                return Ok(new ResponseModel<List<BooksEntity>>
                {
                    success = true,
                    Message = "Search successfully",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<List<BooksEntity>>
                {
                    success = false,
                    Message = "Failed to Search",
                    Data = response
                });
            }
        }
    }
}
