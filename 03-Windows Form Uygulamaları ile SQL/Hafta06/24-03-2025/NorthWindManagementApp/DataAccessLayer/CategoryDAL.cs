using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NorthWindManagementApp.Models;

namespace NorthWindManagementApp.DataAccessLayer
{
    public class CategoryDAL // Burası Category ile ilgili db operasyonlarımızı yapacağımız sınıf
    {
        // Buraya NortWind db içindeki Categories tablosundan verileri çekmeye yarayan bir metot yazacağız.

        public LinkedList<Category>GetAll()
        {
            string query = @"
                select 
	                CategoryID as 'Id',
	                CategoryName as 'Name',
	                Description
                from Categories
            ";
            SqlCommand cmd = new SqlCommand(query,DataAccess.Connection);
            DataAccess.ConnectDb(); // Bağlantıyı Aç
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            LinkedList<Category> categoryList = [];
            Category category;
            while (sqlDataReader.Read())
            {
                category = new Category
                {
                    Id = (int)sqlDataReader[0],
                    Name = (string)sqlDataReader[1],
                    Description = (string)sqlDataReader[2]
                };
                categoryList.AddLast(category); // sona ekleme
            }
            DataAccess.DisconnectDb();
            return categoryList;    
        }

    }
}
