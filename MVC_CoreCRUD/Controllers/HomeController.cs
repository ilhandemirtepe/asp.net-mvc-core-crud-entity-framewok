using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_CoreCRUD.Models;

namespace MVC_CoreCRUD.Controllers
{
    public class HomeController : Controller
    {
        DataContext dataContext = new DataContext();
        public IActionResult Index()
        {
           
            return View();
        }
        public JsonResult GetEmployees()
        {
           
            List<Product> products = dataContext.Product.ToList();
            return Json(products);
        }


        public JsonResult AddEmployee([FromBody] Product obj)
        {
            dataContext.Product.Add(obj);
            dataContext.SaveChanges();
            return Json(obj);
        }

        public JsonResult DeleteEmployee(int id)
        {
            dataContext.Product.Remove(dataContext.Product.Find(id));
            dataContext.SaveChanges();
            return Json(id);
        }


        
        public JsonResult UpdateEmployee([FromBody]Product obj)
        {
           Product product=  dataContext.Product.FirstOrDefault(x=>x.id==obj.id);

            product.id = obj.id;
            product.gender = obj.gender;
            product.name = obj.name;
            product.salary = obj.salary;
            dataContext.SaveChanges();
            return Json(obj);

        }

    }
}
