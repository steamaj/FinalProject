using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyBox.Domain.Abstract;
using ToyBox.Domain.Entities; //Added for details 
using ToyBox.WebUI.Models;
using ToyBox.Domain.Concrete;
using System.Collections;
using Microsoft.AspNet.Identity;


namespace ToyBox.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;

        public ProductController(IProductRepository productRepository)
        {
            this.myrepository = productRepository;
        }
        private IUserRepository repository;



        public int PageSize = 9;
        public ViewResult List( int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = myrepository.Products

                                             .OrderBy(p => p.ProductID)
                                             .Skip((page - 1) * PageSize)
                                             .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = myrepository.Products.Count()
                },

            };
            return View(model);
        }

        public ViewResult Details (int productID)
        {
           

            Product product = myrepository.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }



        public ViewResult PostedProducts()
        {
            

                return View(myrepository.Products);
        }


















        EFDbContext ds = new EFDbContext();


        public ViewResult Edit (int productID)
        {

            var itemss = ds.Categories.ToList();
            if (itemss != null)
            {
                ViewBag.datas = itemss;
            }


            var items = ds.Condition.ToList();
            if(items != null)
            {
                ViewBag.data = items;
            }
            Product product = myrepository.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            //ViewBag.ConditionID = new SelectList(ds.Condition, "ConditionID", "ConditionName", product.ConditionID);
            if (ModelState.IsValid)
            {

                myrepository.SaveProduct(product);
                TempData["message"] = string.Format
                    ("{0} has been saved", product.ProductName);
                return RedirectToAction("PostedProducts");
            }
            else
            {

                return View(product);
            }
        }



        public ViewResult Create()
        {
            var itemss = ds.Categories.ToList();
            if (itemss != null)
            {
                ViewBag.datas = itemss;
            }


            var items = ds.Condition.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }
            return View("Edit", new Product());
            
        }



        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deleteProduct = myrepository.DeleteProduct(productId);
            if (deleteProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deleteProduct.ProductName);
            }
            return RedirectToAction("PostedProducts");
        }
    }
}