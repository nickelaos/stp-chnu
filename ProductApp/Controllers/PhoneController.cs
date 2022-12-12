using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApp.Controllers
{
    public class PhoneController : ApiController
    {
        Phone[] phones = new Phone[]
       {
            new Phone { Id = 1, Model = "M32", Maker = "Samsung", Price = 22000 },
            new Phone { Id = 2, Model = "XS", Maker = "Apple", Price = 45000 },
            new Phone { Id = 3, Model = "Redmi", Maker = "Xiaomi", Price = 16000 }
       };

        public IEnumerable<Phone> GetAllPhones()
        {
            return phones;
        }
        public IHttpActionResult GetPhone(int id)
        {
            var phone = phones.FirstOrDefault((p) => p.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            return Ok(phone);
        }
    }

}
