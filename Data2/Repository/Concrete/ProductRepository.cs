using System;
using Core.Entities;
using Data.Contents;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
	public class ProductRepository : IProductRepository
	{
        public void Create(Product product)
        {
            DbContent.Products.Add(product);
        }


        public void Update(Product product)
        {
            var dbProduct = DbContent.Products.FirstOrDefault(p => p.Id == product.Id);
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Count = product.Count;
            dbProduct.Supplier = product.Supplier;
        }

        public void Delete(Product product)
        {
            DbContent.Products.Remove(product);
        }

        public Product Get(int id)
        {
            return DbContent.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            return DbContent.Products;
        }
    }
}

