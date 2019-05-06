using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_Entidades;

namespace Tienda_AccesoDatos
{
    public class TiposClientesDAL
    {

        public List<ETiposClientes> GetAll()
        {

            List<ETiposClientes> cliente = new List<ETiposClientes>();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ToString()))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM TIPOSCLIENTES ORDER BY Id ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto ECLIENTE para llenar sus propiedades
                        ETiposClientes c = new ETiposClientes
                        {
                            id = Convert.ToInt32(dataReader["Id"]),
                            nombre = Convert.ToString(dataReader["nombre"]),
                            
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        cliente.Add(c);
                    }
                }
            }
            return cliente;
        }
    }
}
