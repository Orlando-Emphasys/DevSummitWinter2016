using Microsoft.AspNetCore.Mvc;
using QRScanner_API.DAL;
using QRScanner_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.Controllers
{
    public class InventoryController: Controller
    {
        private APIDataContext _context;
        public InventoryController (APIDataContext api)
        {
            _context = api;
        }
        public IActionResult InventoryDescription(int id)
        {
            int returnVal = 0;

            returnVal = _context.Products.First(x => x.ID == id).Quantity;
            
            return Json (new { value = returnVal });
        }

        public bool AddNewProduct( Product NewItem)
        {

            return false;
        }
    }
}
