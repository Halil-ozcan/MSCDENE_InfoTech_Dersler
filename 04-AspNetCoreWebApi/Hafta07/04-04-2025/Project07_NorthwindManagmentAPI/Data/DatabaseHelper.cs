using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Project07_NorthwindManagmentAPI.Data;

public class DatabaseHelper
{
    private static readonly string _connectionString;
    static DatabaseHelper() // static classların constructor metotları bu şekilde tanımlanır.
    {
        _connectionString ="Server=HALIL\\MSCD8SQLSERVER;Database=Northwind;User=sa;Password=Qwe123.,;TrustServerCertificate=True";
    }
    
    /// <summary>
    /// Sorgu Sonucunu Datatable tipinde döndürür.
    /// </summary>
    /// <param name="query">Çalıştırılacak sorgu</param>
    /// <param name="parameters">Sorguya gönderilecek olan parametreler</param>
    /// <returns>Geriye Datatable döndürür.</returns>
    public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
    {
        var dataTable = new DataTable();

        using var connecttion = new SqlConnection(_connectionString); // basit yazım şekli böyle
        using (var command = new SqlCommand(query, connecttion))
        {
            command.Parameters.AddRange(parameters);
            connecttion.Open();
            using var adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
        }
       return dataTable;

        
    }

    /// <summary>
    /// Insert, Update Delete operasyonları yürütür.
    /// </summary>
    /// <param name="commandText">Çalıştırılacak sorgu</param>
    /// <param name="parameters">Sorguya gönderilecek olan parametreler</param>
    /// <returns>Etkilenen Satır Sayısını Döndürür</returns>
    public static int ExecuteNonQuery(string commandText,params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(commandText,connection);
        command.Parameters.AddRange(parameters);
        connection.Open();
        return command.ExecuteNonQuery();
        
    }

    /// <summary>
    /// Scalar Değer Döndürür.
    /// </summary>
    /// <param name="commandText">Çalıştırılacak sorgu</param>
    /// <param name="parameters">Sorguya gönderilecek olan parametreler</param>
    /// <returns>Sorgunun Sayısal Sonucunu Döndürür.</returns>
    public static object ExecuteScalar(string commandText, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(commandText,connection);
        command.Parameters.AddRange(parameters);
        connection.Open();
        return command.ExecuteScalar();
    }   
}

// var connecttion = new SqlConnection(_connectionString);
// var command = new SqlCommand(query,connecttion);
