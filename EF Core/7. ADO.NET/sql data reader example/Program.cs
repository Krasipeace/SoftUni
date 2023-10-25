using Microsoft.Data.SqlClient;

SqlConnection dbCon = new(@"Server=.; Database=SoftUni; Integrated Security=True;TrustServerCertificate=True;");
dbCon.Open();

using (dbCon)
{
    SqlCommand command = new SqlCommand("SELECT * FROM Employees", dbCon);
    SqlDataReader reader = command.ExecuteReader();

    using (reader)
    {
        while (reader.Read())
        {
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader["LastName"];
            decimal salary = (decimal) reader["Salary"];
            Console.WriteLine($"{firstName} {lastName} - {salary}");
        }
    }
}

dbCon.Close();
