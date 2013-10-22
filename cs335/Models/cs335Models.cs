using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs335.Models
{
    public class CategoryModel
    {
        public CategoryModel(int CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class JointProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
    }

    public class ProductModel
    {
        public ProductModel(int ProductID, string ProductName, int CategoryID, int SupplierID)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.CategoryID = CategoryID;
            this.SupplierID = SupplierID;
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
    }

    public class SupplierModel
    {
        public SupplierModel(int SupplierID, string CompanyName, string Country)
        {
            this.SupplierID = SupplierID;
            this.CompanyName = CompanyName;
            this.Country = Country;
        }
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
    }
}