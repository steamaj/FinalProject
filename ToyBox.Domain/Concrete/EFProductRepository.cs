using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyBox.Domain.Abstract;
using ToyBox.Domain.Entities;

namespace ToyBox.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext contex = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return contex.Products; }
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {





                Product db = new Product();
                db.PostedDate = DateTime.Now;
                db.ProductName = product.ProductName;
                db.Description = product.Description;
                db.Price = product.Price;
                db.Brand = product.Brand;
                db.YearOfProduct = product.YearOfProduct;
                db.CategoryID = product.CategoryID;
                db.ConditionID = product.ConditionID;

                db.Condition = product.Condition;
                db.AvaliableStatus = true;

                db.userID = product.userID;

                contex.Products.Add(db);






            }
            else
            {
                Product dbEntry = contex.Products.Find(product.ProductID);

                if (dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Brand = product.Brand;
                    dbEntry.YearOfProduct = product.YearOfProduct;
                    dbEntry.PostedDate = product.PostedDate;
                    dbEntry.ConditionID = product.ConditionID;
                    dbEntry.CategoryID = product.CategoryID;

                    dbEntry.AvaliableStatus = true;
                    dbEntry.Condition = product.Condition;

                }
            }
            contex.SaveChanges();
        }


        public Product DeleteProduct(int productID)
        {
            Product dbEntry = contex.Products.Find(productID);
            if(dbEntry != null)
            {
                contex.Products.Remove(dbEntry);
                contex.SaveChanges();
            }
            return dbEntry;
        }
    }
}
