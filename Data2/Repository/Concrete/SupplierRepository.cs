using System;
using Core.Entities;
using Data.Contents;
using Data.Repository.Abstract;

namespace Data.Repository.Concrete
{
    public class SupplierRepository : ISupplierRepository
    {
        public void Create(Supplier supplier)
        {
            DbContent.Suppliers.Add(supplier);
        }

        public void Update(Supplier supplier)
        {
            var dbSupplier = DbContent.Suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            dbSupplier.Name = supplier.Name;
            dbSupplier.Products = supplier.Products;
        }

        public void Delete(Supplier supplier)
        {
            DbContent.Suppliers.Remove(supplier);
        }

        public Supplier Get(int id)
        {
            return DbContent.Suppliers.FirstOrDefault(s => s.Id == id);
        }

        public List<Supplier> GetAll()
        {
            return DbContent.Suppliers;
        }
    }
}