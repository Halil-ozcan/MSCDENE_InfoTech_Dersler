using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Project07_NorthwindManagmentAPI.Models;

namespace Project07_NorthwindManagmentAPI.Data.Repositories;

public class NorthwindRepository
{
    /// <summary>
    /// Tüm Ürünleri Getirir.
    /// </summary>
    /// <returns></returns>
    public List<Product> GetAllProducts()
    {
        var query = @"
            select 
                p.ProductID,
                p.ProductName, 
                p.CategoryID ,
                p.UnitPrice,
                UnitsInStock
            from Products p  
        ";
        var dataTable = DatabaseHelper.ExecuteQuery(query);
        var products = new List<Product>();
        foreach (DataRow row in dataTable.Rows)
        {
            products.Add(new Product{
                ProductID=(int)row["ProductID"],
                ProductName=row["ProductName"].ToString(),
                CategoryID=row["CategoryID"]!=DBNull.Value ? (int)row["CategoryID"]:(int?) null,
                UnitPrice=row["UnitPrice"]!=DBNull.Value ? (decimal)row["UnitPrice"]:(decimal?) null,
                UnitsInStock=row["UnitsInStock"]!=DBNull.Value ? (short)row["UnitsInStock"]:(short?) null
            });
        }
        return products;
    }

    /// <summary>
    /// Id'si verilen ürünü döndürür.
    /// </summary>
    /// <param name="id">İd Bilgisi</param>
    /// <returns></returns>
    public Product GetProductById(int id)
    {
        var query=$@"
            select 
                p.ProductID,
                p.ProductName, 
                p.CategoryID ,
                p.UnitPrice,
                UnitsInStock
            from Products p  
            where ProductID = @p1
        ";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@p1",id)
        };
        var dataTable = DatabaseHelper.ExecuteQuery(query,parameters);
        if(dataTable.Rows.Count==0) return null!;
        var row = dataTable.Rows[0];
        var product = new Product{
            ProductID=(int)row["ProductID"],
            ProductName=row["ProductName"].ToString(),
            CategoryID=row["CategoryID"]!=DBNull.Value ? (int)row["CategoryID"]:(int?) null,
                UnitPrice=row["UnitPrice"]!=DBNull.Value ? (decimal)row["UnitPrice"]:(decimal?) null,
                UnitsInStock=row["UnitsInStock"]!=DBNull.Value ? (short)row["UnitsInStock"]:(short?) null
        };
        return product;
    }

    /// <summary>
    /// Yeni Ürün ekleme
    /// </summary>
    /// <param name="product">Ürün Bilgisi</param>
    /// <returns></returns>
    public Product AddProduct(Product product)
    {
        var query = $@"
                insert into Products(ProductName, CategoryID, UnitPrice, UnitsInStock)
            values
	            (@p1,@p2,@p3,@p4)
            select scope_identity()
        ";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@p0",product.ProductID),
            new SqlParameter("@p1",product.ProductName),
            new SqlParameter("@p2",product.CategoryID ?? (object)DBNull.Value),
            new SqlParameter("@p3",product.UnitPrice ?? (object)DBNull.Value),
            new SqlParameter("@p4",product.UnitsInStock ?? (object)DBNull.Value),
        };

        var newId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,parameters));
        return GetProductById(newId);
    }

    /// <summary>
    /// Ürün GÜNCELLEME
    /// </summary>
    /// <param name="product">Güncellenecek ürün bilgisi</param>
    /// <returns></returns>
    public bool UpdateProduct(Product product)
    {
        var commandText =$@"
            update Products 
            set
                ProductName ='@p1',
                CategoryID=@p2,
                UnitPrice =@p3,
                UnitsInStock=@p4
            where ProductID = @p0
        ";
        var parameters = new SqlParameter[]
        {
            new("@p0",product.ProductID),
            new("@p1",product.ProductName),
            new("@p2",product.CategoryID ?? (object)DBNull.Value),
            new("@p3",product.UnitPrice ?? (object)DBNull.Value),
            new("@p4",product.UnitsInStock ?? (object)DBNull.Value)
        };
        var affectedRows = DatabaseHelper.ExecuteNonQuery(commandText, parameters);
        return affectedRows>0;
    }


   /// <summary>
   /// Ürün Silme
   /// </summary>
   /// <param name="id"> Silinecek ürün bilgisi</param>
   /// <returns></returns>
    public bool DeleteProduct(int id)
    {
        var commandText ="delete Products where ProductID=@p1";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@p1",id)
        };
        var affectedRows =DatabaseHelper.ExecuteNonQuery(commandText,parameters);
        return affectedRows>0;
    }

  // Category'leri çeken metodu yazınız. Bunu yazdıktan sonra CategoriesController'ı oluşturarak tüm kategorileri listeleyen endpointi hazırlayınız.

  public List<Category> GetAllCategories()
  {
    var query = @"
            select 
                c.CategoryID,
                c.CategoryName,
                c.Description
            from Categories c
        ";
        var dataTable = DatabaseHelper.ExecuteQuery(query);
        var categories = new List<Category>();

        foreach (DataRow row in dataTable.Rows)
        {
            categories.Add(new Category{
                CategoryID=(int)row["CategoryID"],
                CategoryName=row["CategoryName"].ToString(),
                Description=row["Description"].ToString(),
               
            });
        }
        return categories;
  }

  public Category GetCategoryById(int id)
  {
    var query=@"
        select 
            c.CategoryID,
            c.CategoryName,
            c.Description
        from Categories c
        where c.CategoryID = @c1
    ";
    var parameters = new SqlParameter[]
    {
        new SqlParameter("@c1",id)
    };
    var dataTable = DatabaseHelper.ExecuteQuery(query,parameters);
    if(dataTable.Rows.Count==0) return null!;
    var rows = dataTable.Rows[0];
    var category = new Category{
        CategoryID=(int)rows["CategoryID"],
        CategoryName= rows["CategoryName"].ToString(),
        Description = rows["Description"].ToString()
    };
    return category; 
  }

  public Category AddCategory(Category category)
  {
    var query = @"
            insert into Categories(CategoryName,Description)
            values
                (@c1,@c2)
            select scope_identity()
        ";
        var parameters = new SqlParameter[]
        {
            new SqlParameter("@c0",category.CategoryID),
            new SqlParameter("@c1",category.CategoryName),
            new SqlParameter("@c2",category.Description),
        };
        var newId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query,parameters));
        return GetCategoryById(newId);
  }

  public bool UpdateCategory(Category category)
 {
    var query = $@"
        update Categories
        set
            CategoryName = @p1,
            Description = @p2
        where CategoryID = @p0
    ";
    var parameters = new SqlParameter[]
    {
        new SqlParameter("@p0",category.CategoryID),
        new SqlParameter("@p1",category.CategoryName),
        new SqlParameter("@p2",category.Description),
    };
    var affectedRows = DatabaseHelper.ExecuteNonQuery(query,parameters);
    return affectedRows> 0;
 } 

 public bool DeleteCategory(int id)
 {
    var commandText = $@"delete Categories where CategoryID=@c0";
    var parameters = new SqlParameter[]
    {
        new SqlParameter("@c0",id),
    };
    var affectedRows = DatabaseHelper.ExecuteNonQuery(commandText,parameters);
    return affectedRows>0;
 }  



}








/*
1-Tüm ürünleri Getir: List<Product> GetAllProducts()
2-Id'ye göre ürün getir: Product GetProductById(int id)
3-Ürün ekleme: int AddProduct(Product product)
.....
*/