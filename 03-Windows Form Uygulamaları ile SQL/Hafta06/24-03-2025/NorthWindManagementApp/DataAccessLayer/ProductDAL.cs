using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NorthWindManagementApp.Models;

namespace NorthWindManagementApp.DataAccessLayer
{
    public class ProductDAL // Burası Product ile ilgili db operasyonlarımızı yapacagımız sınıf
    {
        public DataTable GetAll() // DataGrideWiew'e veri aktarmak için dataTable tipi kullanıyoruz.
        {
            string query = @"
                select 
	                p.ProductID as 'Id',
	                p.ProductName as 'Name', 
	                p.CategoryID as 'CategoryId',
	                p.UnitPrice as 'Price',
	                UnitsInStock as 'Stock',
	                c.CategoryName as 'Category'
                from Products p  join Categories c on p.CategoryID = c.CategoryID
            ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, DataAccess.Connection); // bunun commandan farkı veri tabanını açma ya da kapatmak için uğraşmıyoruz otomatik kendisi yapıyor CategoryDAL da farkına bak!!!.
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public Product GetById(int id)
        {
            string query = @$"
                select 
	                p.ProductID as 'Id',
	                p.ProductName as 'Name', 
	                p.CategoryID as 'CategoryId',
	                p.UnitPrice as 'Price',
	                UnitsInStock as 'Stock'
                from Products p where ProductID={id}
            ";
            SqlCommand sqlCommand = new SqlCommand(query,DataAccess.Connection);
            DataAccess.ConnectDb();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Product product = null!;
            if(sqlDataReader.Read())
            {
                product = new Product()
                {
                    Id = (int)sqlDataReader[0],
                    Name = (string)sqlDataReader[1],
                    CategoryId = (int)sqlDataReader[2],
                    Price = (decimal)sqlDataReader[3],
                    Stock = sqlDataReader[4].ToString(),
                };
               
            }
            DataAccess.DisconnectDb();
            return product;
        }

        public void Update(UpdateProductModel updateProductModel)
        {

        }
    }
}
