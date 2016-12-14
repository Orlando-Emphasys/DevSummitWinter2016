using Microsoft.AspNetCore.Mvc;
using QRScanner_API.DAL;
using QRScanner_API.Models;
using QRScanner_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController: Controller
    {
        private APIDataContext _context;
        public InventoryController (APIDataContext api)
        {
            _context = api;
        }
        public IActionResult Get(int id)
        {

            ItemQR item = _context.ItemQRs.First(x => x.ID == id);
            Product returnVal = _context.Products.First(x => x.ID == item.ProductID);
            String returnOffice = _context.Offices.First(x => x.ID == returnVal.OfficeId).Description;
            Owner returnOwner = _context.Owners.First(x => x.ID == item.OwnerID);
            Location loc = _context.Locations.First(x => x.ID == returnOwner.LocationID);

            return Json (new { Brand = returnVal.Brand,
                               Type = returnVal.Type,
                               Quantity = returnVal.Quantity,
                               Model = returnVal.Model,
                               Office = returnOffice,
                               Owner = returnOwner.Name,
                               Location = loc.Description});
        }

        public IActionResult Post([FromBody]NewItemViewModel NewItem)
        {
            bool returnVal = false;
            int returnID = -1;

            //Increase quantity or create a new product
            var checkInv = _context.Products.FirstOrDefault(x => x.Brand == NewItem.brand && x.Model == NewItem.model && x.Type == NewItem.type);
            if(checkInv != null)
            {
                checkInv.Quantity++;
                _context.SaveChanges();
            }
            else
            {
                checkInv = new Product() { Brand = NewItem.brand, Model = NewItem.model, Quantity = 1, Type = NewItem.type };
                var officeloc = _context.Offices.First(x => x.City == NewItem.city);
                checkInv.OfficeId = officeloc.ID;
                _context.Products.Add(checkInv);
                _context.SaveChanges();
            }
            //Try to insert the itemQR
            try
            {
                //Trung... you set Owner.Name to int...
                var owner = _context.Owners.First(x => x.Name.ToString().Trim().ToLower() == NewItem.ownername.Trim().ToLower());
                var item = new ItemQR() { SerialNumber = NewItem.serialnumber, AssignedDate = DateTime.UtcNow, ProductID = checkInv.ID, OwnerID = owner.ID };
                _context.ItemQRs.Add(item);
                _context.SaveChanges();
                returnVal = true;
                returnID = item.ID;
            }
            catch
            {
                //ERROR HANDLING
            }

            return Json(new { Success = returnVal, itemID = returnID });
        }

        public bool Add(Product AddItem)
        {
            return false;
        }

        [HttpGet("ListModels")]
        //Will need to redo when the view models are changed
        public List<NewItemViewModel> ListModels()
        {
            var list = new List<NewItemViewModel>();
            //var office = _context.Offices.SingleOrDefault(x=>x.City == city);
            var products = _context.Products.ToList();
            foreach (var product in products)
            {
                var items = _context.ItemQRs.Where(x => x.ProductID == product.ID);
                foreach (var item in items)
                {
                    var owner = _context.Owners.SingleOrDefault(x => x.ID == item.OwnerID);
                    var location = _context.Locations.SingleOrDefault(x => x.ID == owner.LocationID);
                    var office = _context.Offices.SingleOrDefault(x => x.ID == product.OfficeId);
                    var newitem = new NewItemViewModel
                    {
                        brand = product.Brand,
                        city = office.City,
                        model = product.Model,
                        serialnumber = item.SerialNumber,
                        ownername = owner.Name,
                        location = location.Description,
                        type = product.Type
                    };
                    list.Add(newitem);
                }
            }
            return list;
        }

        // similar to the method above, will need to test
        public List<NewItemViewModel> FilteredList(string search, string city, int limit)
        {
            var list = new List<NewItemViewModel>();
            var office = _context.Offices.SingleOrDefault(x => x.City == city);
            var products = _context.Products.Where(x => x.OfficeId == office.ID &&  
                                                    (x.Model.Contains(search) ||
                                                     x.Type.Contains(search)));

            foreach (var product in products)
            {
                var item = _context.ItemQRs.SingleOrDefault(x => x.ProductID == product.ID);
                var owner = _context.Owners.SingleOrDefault(x => x.ID == item.OwnerID);
                var location = _context.Locations.SingleOrDefault(x => x.ID == owner.LocationID);

                var newitem = new NewItemViewModel
                {
                    brand = product.Brand,
                    city = office.City,
                    model = product.Model,
                    serialnumber = item.SerialNumber,
                    ownername = owner.Name,
                    location = location.Description,
                    type = product.Type
                };
                list.Add(newitem);
            }
            return list;
        }

        [HttpGet("{itemID}")]
        //still need to figure out what data is being sent back
        public ItemQR GenerateQR(int itemID)
        {
            return _context.ItemQRs.SingleOrDefault(x=>x.ID == itemID);
        }
    }
}
