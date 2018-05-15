using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace sqlAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadenaConexion = @"Data Source=DESKTOP-7KN5JV1\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True";
            string query = "update Customers set CompanyName=@CompanyNueva  where CustomerID= @clienteID ";

            Console.WriteLine("Introduce ID del cliente");
            string clienteID = Console.ReadLine();

            Console.WriteLine("Introduce compañía nueva");
            string compañiaNueva = Console.ReadLine();

           
            try
            {
                using (SqlConnection objConexion = new SqlConnection (cadenaConexion))
                {
                    objConexion.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    SqlCommand commandUpdate = new SqlCommand(query, objConexion);

                    commandUpdate.Parameters.Add("@CompanyNueva", SqlDbType.NVarChar, 40);
                    commandUpdate.Parameters["@CompanyNueva"].Value = compañiaNueva;

                    commandUpdate.Parameters.Add("@ClienteID", SqlDbType.NChar, 5);
                    commandUpdate.Parameters["@ClienteID"].Value = clienteID;

                    adapter.UpdateCommand = commandUpdate;

                    int filasActualizadas = adapter.UpdateCommand.ExecuteNonQuery();
                    Console.WriteLine("{0} filas actualizadas" , filasActualizadas);
                    
                    Console.ReadKey();
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
/*Actualizo la tabla de clientes de customer para un determinado cliente.*/
 /*Voy a pedir el id del cliente concatenando el nombre y apellido*/