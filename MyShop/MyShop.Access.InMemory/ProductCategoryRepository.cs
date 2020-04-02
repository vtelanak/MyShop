﻿using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Access.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productcategories;

        public ProductCategoryRepository()
        {
            productcategories = cache["productcategories"] as List<ProductCategory>;
            if (productcategories == null)
            {
                productcategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productcategories"] = productcategories;
        }

        public void Insert(ProductCategory p)
        {
            productcategories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productcategories.Find(p => p.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productcategories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }

        }
        public IQueryable<ProductCategory> Collection()
        {
            return productcategories.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelelte = productcategories.Find(p => p.Id == Id);
            if (productCategoryToDelelte != null)
            {
                productcategories.Remove(productCategoryToDelelte);
            }
            else
            {
                throw new Exception("product Category not found");
            }
        }
    }
}
