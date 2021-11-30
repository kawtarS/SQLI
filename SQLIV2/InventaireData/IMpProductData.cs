using SQLIV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace SQLIV2.InventaireData
{
    public class IMpProductData : IProductData
    {
        private List<Product> products = new List<Product>()
        {
            new Product { name = "SAMSUNG GALAXY S21 Ultra", category ="GSM", price = 10000 , discount = 5, quantity = 100, barcode = 12546358 },
            new Product { name = "REFRIGERATEUR SAMSUNG NO-FROST", category ="REFRIGIRATEUR", price = 7000 , discount = 10, quantity = 20, barcode = 12454784 },
            new Product { name = "Easy T-Shirt Homme", category ="FASHION", price = 100 , discount = 1, quantity = 63, barcode = 25458778 },
            new Product { name = "New Balance Basket Homme", category ="FASHION", price = 300 , discount = 5, quantity = 15, barcode = 457887558 },
            new Product { name = "L'Oréal Paris Fond de Teint", category ="BEAUTE", price = 600 , discount = 4, quantity = 70, barcode = 987588 }
        };
        public Product AddProduct(Product product)
        {
            if (product == null) { throw new NotImplementedException(); }
            product.barcode++;
            products.Add(product);
            return product;
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                products.Remove(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product EditProduct(Product product)
        {
            try
            {
                var existingProduct = GetProduct(product.barcode);
                existingProduct.category = product.category;
                existingProduct.discount= product.discount;
                existingProduct.price = product.price;
                existingProduct.quantity = product.quantity;
                return existingProduct;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> GetProductsByCategory(string category)
            
        {
            try
            {
                return products.Where(c => c.category.Equals(category)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Product> GetProductdecroissant()

        {
            try
            {
                return products.OrderByDescending(p => p.price).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product GetProduct(int bar)
        {
            try
            {
                return products.FirstOrDefault(x => x.barcode == bar); // if not found return null
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Product GetByName(string name)
        {
            try
            {
                //  récupérer un seul element par nom
                return products.FirstOrDefault(p => p.name.Equals(name));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> GetProducts()
        {
            try { return products; }


            catch (Exception ex) {
                
                throw ex; 
            }




        }
        public List<Product> GetProductSup(int discount)
        {
            try { return products.Where(p => p.discount > discount).ToList();  }


            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
