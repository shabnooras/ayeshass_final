using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BASITraining.Models
{
    public class DBInitialise : DropCreateDatabaseIfModelChanges<p_context>

    {
        protected override void Seed(p_context context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<category> GetCategories()
        {
            var categories = new List<category> {
                new category
                {
                    CategoryID = 1,
                    CategoryName = "Courses"
                },
                new category
                {
                    CategoryID = 2,
                    CategoryName = "Certifications"
                },
            };

            return categories;
        }

        private static List<product> GetProducts()
        {
            var products = new List<product> {
                new product
                {
                    ProductID = 1,
                    ProductName = "C and C++",
                    Duration = "1 Month",
                    ImagePath="c.jpeg",
                    UnitPrice = 22.50,
                    CategoryID = 1
               },
                new product
                {
                    ProductID = 2,
                    ProductName = "HTML5",
                    Duration = "3 Weeks",
                    ImagePath="html5.png",
                    UnitPrice = 30.00,
                    CategoryID = 1
               },
                new product
                {
                    ProductID = 3,
                    ProductName = "MS Windows 10",
                    Duration = "1 Month",
                    ImagePath="windows10.jpeg",
                    UnitPrice = 100.00,
                    CategoryID = 1
               },
                new product
                {
                    ProductID = 4,
                    ProductName = "MS Word",
                    Duration = "2 Weeks",
                    ImagePath="word.jpg",
                    UnitPrice = 10.00,
                    CategoryID = 1
               },
                new product
                {
                    ProductID = 5,
                    ProductName = "SQL Server Database",
                    Duration = "3 Months",
                    ImagePath="mssql-server.png",
                    UnitPrice = 120.00,
                    CategoryID = 1
               },
                new product
                {
                    ProductID = 6,
                    ProductName = "Oracle db database",
                    Duration = "2 Months",
                    ImagePath="oracle.jpg",
                    UnitPrice = 100.00,
                    CategoryID = 1
               },
                new product
                {
                    ProductID = 7,
                    ProductName = "MCSD: App Builder",
                    Duration = "2 Months",
                    ImagePath="mcsd.png",
                    UnitPrice = 115.00,
                    CategoryID = 2
               },
                new product
                {
                    ProductID = 8,
                    ProductName = "MS Visual Studio 2017",
                    Duration = "2 Months",
                    ImagePath="VS.jpg",
                    UnitPrice = 160.00,
                    CategoryID = 2
               },
                new product
                {
                    ProductID = 9,
                    ProductName = "MCSA: Office 365",
                    Duration = "2 Months",
                    ImagePath="office365.png",
                    UnitPrice = 130.00,
                    CategoryID = 2
               },
                new product
                {
                    ProductID = 10,
                    ProductName = "MCSA: Windows 10",
                    Duration = "3 Months",
                    ImagePath="mcsa10.png",
                    UnitPrice = 200.00,
                    CategoryID = 2
               },
            };

            return products;
        }
    }
}
