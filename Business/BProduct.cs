﻿using System;
using System.Collections.Generic;
using Entity;
using Data;
using System.Linq;

namespace Business
{
    public class BProduct
    {
        private DProduct data;

        public BProduct()
        {
            data = new DProduct();
        }

        public List<Product> GetByName(string name)
        {
            List<Product> result = new List<Product>();

            var products = data.Get();

            result= products.Where(x => x.Name.Contains(name)).ToList();

            return result;
        }
        public Product GetById(int Id)
        {

            var products = data.Get();

            var result = products.FirstOrDefault(x => x.ProductId == Id);

            return result;
        }

        public void CreateProduct(Product product)
        {
            data.Create(product);
        }

        public void DeleteProduct(int productId)
        {

            
            data.Delete(productId);
        }
    }
}