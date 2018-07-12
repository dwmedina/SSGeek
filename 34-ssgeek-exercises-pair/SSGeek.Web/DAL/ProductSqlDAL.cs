using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        private readonly string ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=SSGeek;Integrated Security=True";

        public Product GetProduct(int id)
        {
            Product product = null;

            string query = "Select * from products where product_id = @id;";
            try
            {
                using (SqlConnection conn = new SqlConnection (ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();                    
                    // only one product, so we need an if instead of while
                    if (reader.Read())
                    {
                        // re-use our mapping method
                        product = MapRowToProduct(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return product;
        }

        public IList<Product> GetProducts()
        {
            string query = "Select * From products";
            var products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(MapRowToProduct(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            return products;
        }

        public Product MapRowToProduct (SqlDataReader reader)
        {
            return new Product()
            {
                Id= Convert.ToInt32(reader["product_id"]),
                Name= Convert.ToString(reader["name"]),
                Description= Convert.ToString(reader["description"]),
                Cost=Convert.ToInt32(reader["price"]),
                ImageName= Convert.ToString(reader["image_name"])
                
            };
        }

    }

}
