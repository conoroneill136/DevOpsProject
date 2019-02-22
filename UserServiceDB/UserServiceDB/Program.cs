using System;
using System.Data.SqlClient;   // System.Data.dll
//using System.Data;           // For:  SqlDbType , ParameterDirection

namespace csharp_db_test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "userservice.database.windows.net";
                cb.UserID = "user";
                cb.Password = "devOps_pass";
                cb.InitialCatalog = "user_service_db";

                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();

                    Submit_Tsql_NonQuery(connection, "2 - Create-Tables", Build_Tsql_CreateTables());

                    Submit_Tsql_NonQuery(connection, "3 - Inserts", Build_Tsql_Inserts());

                    //Submit_Tsql_Select001(connection);

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("View the report output here, then press any key to end the program...");
            Console.ReadKey();
        }


        static string Build_Tsql_CreateTables()
        {
            return @"
        DROP TABLE IF EXISTS userInfo;

        CREATE TABLE userInfo
        (
            userID      int identity(1,1)   not null    PRIMARY KEY
            ,email      nvarchar(200)       not null
            ,password   nvarchar(50)        not null
            ,forename   nvarchar(100)       not null
            ,surname    nvarchar(100)       not null
        );
    ";
        }

        
        static string Build_Tsql_Inserts()
        {
            return @"
        INSERT INTO userInfo (email, password, forename, surname)
        VALUES
            ('anthony.losty@version1.com', 'pass01', 'Anthony', 'Losty'),
            ('Francois.Malgreve@version1.com', 'pass02', 'Francois', 'Malgreve'),
            ('Conor.ONeill@version1.com', 'pass03', 'Conor', 'ONeill'),
            ('Derek.Mulhern@version1.com', 'pass04', 'Derek', 'Mulhern'),
            ('Christian.Bachert@version1.com', 'pass05', 'Christian', 'Bachert')
        ;
    ";
        }

        /*
        static string Build_Tsql_Select001()
        {
            return @"
        SELECT
            *
        FROM
            userInfo
        ORDER BY
            userID;
    ";
        }
        */

        /*
        static void Submit_Tsql_Select001(SqlConnection connection)
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("Now, SelectEmployees (6)...");

            string tsql = Build_Tsql_Select001();

            using (var command = new SqlCommand(tsql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} , {1} , {2} , {3} , {4}",
                            reader.GetGuid(0),
                            reader.GetString(1),
                            reader.GetInt32(2),
                            (reader.IsDBNull(3)) ? "NULL" : reader.GetString(3),
                            (reader.IsDBNull(4)) ? "NULL" : reader.GetString(4));
                    }
                }
            }
        }
        */

        static void Submit_Tsql_NonQuery(
            SqlConnection connection,
            string tsqlPurpose,
            string tsqlSourceCode,
            string parameterName = null,
            string parameterValue = null
            )
        {
            Console.WriteLine();
            Console.WriteLine("=================================");
            Console.WriteLine("T-SQL to {0}...", tsqlPurpose);

            using (var command = new SqlCommand(tsqlSourceCode, connection))
            {
                if (parameterName != null)
                {
                    command.Parameters.AddWithValue(  // Or, use SqlParameter class.
                        parameterName,
                        parameterValue);
                }
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " = rows affected.");
            }
        }
    } // EndOfClass
}