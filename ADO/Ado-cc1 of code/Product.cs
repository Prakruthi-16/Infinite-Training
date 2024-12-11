using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=ICS-LT-3TXLV44\\SQLEXPRESS;database=pro;trusted_connection=true;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create command to call the stored procedure
            using (SqlCommand command = new SqlCommand("InsertProduct", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@ProductName", "Sample Product");
                command.Parameters.AddWithValue("@Price", 100.00);

                // Output parameters
                SqlParameter productIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(productIdParam);

                SqlParameter discountedPriceParam = new SqlParameter("@DiscountedPrice", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(discountedPriceParam);

                // Execute the stored procedure
                command.ExecuteNonQuery();

                // Retrieve the output values
                int generatedProductId = (int)productIdParam.Value;
                decimal discountedPrice = (decimal)discountedPriceParam.Value;

                // Display the results
                Console.WriteLine($"Generated Product ID: {generatedProductId}");
                Console.WriteLine($"Discounted Price: {discountedPrice}");
            }
        }
    }
}