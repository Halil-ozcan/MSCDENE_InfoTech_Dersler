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
        public DataTable GetAll(int categoryId=0) // DataGrideWiew'e veri aktarmak için dataTable tipi kullanıyoruz.
        {
            string whereText = categoryId == 0 ? string.Empty : $"where p.CategoryId = {categoryId}";
            string query = $@"
                select 
	                p.ProductID as 'Id',
	                p.ProductName as 'Name', 
	                p.CategoryID as 'CategoryId',
	                p.UnitPrice as 'Price',
	                UnitsInStock as 'Stock',
	                c.CategoryName as 'Category'
                from Products p  join Categories c on p.CategoryID = c.CategoryID
                {whereText}
                order by p.ProductId desc
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
            string price = updateProductModel.Price.ToString().Replace(",", ".");
            string query = $@"
                update Products 
                set
	                ProductName ='{updateProductModel.Name}',
	                CategoryID={updateProductModel.CategoryId},
	                UnitPrice ={price},
	                UnitsInStock={updateProductModel.Stock}
                where ProductID = {updateProductModel.Id}
            ";
            DataAccess.ConnectDb();
            SqlCommand cmd = new SqlCommand(query, DataAccess.Connection);
            cmd.ExecuteNonQuery();// sadece update edeceği ve geriye bir değer dönrümeyeceği için bu metodu kullanıyoruz.
            DataAccess.DisconnectDb();
        }

        // Diğer üç metotta sql injection olabilecek bir açıklıkla yaptık. 
        // ama aşağıdaki metotta buna nasıl izin vermeyeceğimizin kodunu yazdık.
        public void  Create(CreateProductModel createProductModel)
        {
            string price = createProductModel.Price.ToString().Replace(",", ".");
            string query = $@"
                    insert into Products(
                        ProductName, 
                        UnitPrice, 
                        UnitsInStock, 
                        CategoryID)
                    values
	                    (@p1,@p2,@p3,@p4)
            ";
            DataAccess.ConnectDb();
            SqlCommand cmd = new SqlCommand(query, DataAccess.Connection);

            cmd.Parameters.AddWithValue("@p1", createProductModel.Name); // burada sql injection da kaçtık.
            cmd.Parameters.AddWithValue("@p2", price);
            cmd.Parameters.AddWithValue("@p3", createProductModel.Stock);
            cmd.Parameters.AddWithValue("@p4", createProductModel.CategoryId);

            cmd.ExecuteNonQuery();
            DataAccess.DisconnectDb();
        }

        public void Delete(int id)
        {
            string query = $@"
                      delete Products where ProductID=@p1
            ";
            DataAccess.ConnectDb();
            SqlCommand sqlCommand = new SqlCommand(query, DataAccess.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);
            sqlCommand.ExecuteNonQuery();
            DataAccess.DisconnectDb();
        }

        public DataTable Search(string searchText, bool status)
        {
            searchText = status ? $"{searchText}%" : $"%{searchText}%"; 
            string query = $@"
                 Select
                    p.ProductID as 'Id',
	                p.ProductName as 'Name', 
	                p.CategoryID as 'CategoryId',
	                p.UnitPrice as 'Price',
	                UnitsInStock as 'Stock',
	                c.CategoryName as 'Category'
                from Products p  join Categories c on p.CategoryID = c.CategoryID
                where p.ProductName like '{searchText}'
                order by p.ProductId desc
            ";
             SqlDataAdapter sqlDataAdapter  = new SqlDataAdapter(query, DataAccess.Connection);
             DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;   
        }


    }
}
