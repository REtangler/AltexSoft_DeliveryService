using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Data;
using DeliveryService_EF.DTOs;
using DeliveryService_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService_EF.HwTasks
{
    public static class EfCoreCodeFirstTasks
    {
        public static DataContext db;

        public static void AddProducts(List<Product> products)
        {
            db.Products.AddRange(products);
            db.SaveChanges();
        }

        public static List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public static void AddCategories(List<Category> categories)
        {
            db.Categories.AddRange(categories);
            db.SaveChanges();
        }

        public static List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public static void AddSuppliers(List<Supplier> suppliers)
        {
            db.Suppliers.AddRange(suppliers);
            db.SaveChanges();
        }

        public static List<Supplier> GetSuppliers()
        {
            return db.Suppliers.ToList();
        }
    }
}
