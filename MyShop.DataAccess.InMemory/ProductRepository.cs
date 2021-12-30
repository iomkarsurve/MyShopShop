using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Products> products = new List<Products>();

        public ProductRepository()
        {
            products = cache["products"] as List<Products>;
            if(products == null)
            {
                products = new List<Products>();
            }

        }
        public void Commit()
        {
            cache["products"] = products;
        }


        public void Insert(Products p)
        {
            products.Add(p);
        }

        public void Update(Products product)
        {
            Products productsToUpdate = products.Find(p => p.Id == product.Id);

            if(productsToUpdate != null)
            {
                productsToUpdate = product;
            }
            else
            {
                throw new Exception("Product no found");
            }

        }
        public Products Find(string Id)
        {
            Products product= products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product no found");
            }
        }

        public IQueryable<Products> Collection()
        {
            return products.AsQueryable();
        }
        public void Delete(String Id)
        {
            Products productsToDelete = products.Find(p => p.Id == p.Id);

            if (productsToDelete != null)
            {
                products.Remove(productsToDelete);
            }
            else
            {
                throw new Exception("Product no found");
            }

        }
    }
}
