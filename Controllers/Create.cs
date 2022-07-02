using library_db_book.Models.Class_Book;
using library_db_book.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library_db_book.Controllers
{
    public class Create : Controller
    {
        // To create View of this Action result
        public ActionResult create()
        {
            return View();
        }

        // Specify the type of attribute i.e.
        // it will add the record to the database
        [HttpPost]
        public ActionResult create(Book model)
        {

            // To open a connection to the database
 //           using (var context = new BookEntities())
//           {
//                // Add data to the particular table
//                context.Book.Add(model);

                // save the changes
//                context.SaveChanges();
//            }
//            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
//            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View();
        }
    }
}