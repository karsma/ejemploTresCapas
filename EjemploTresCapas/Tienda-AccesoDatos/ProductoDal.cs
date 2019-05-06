﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_Entidades;

namespace Tienda_AccesoDatos
{
    public class ProductoDal
    {
       

        public void Insert(EProducto producto)
        {
            
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            using (var cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ToString()))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    "INSERT INTO Producto (Descripcion, Marca, Precio) VALUES (@descripcion, @marca, @precio)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

       
        public List<EProducto> GetAll()
        {
            
            List<EProducto> productos = new List<EProducto>();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ToString()))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Producto ORDER BY Id ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProducto producto = new EProducto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDecimal(dataReader["Precio"])
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }

      
        public EProducto GetByid(int idProducto)
        {
            //var cadena = ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ConnectionString;

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ConnectionString))
            {
                cnx.Open();
                
                const string sqlGetById = "SELECT * FROM Producto WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    //
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EProducto producto = new EProducto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDecimal(dataReader["Precio"])
                        };

                        return producto;
                    }
                }
            }

            return null;
        }

      
        public void Update(EProducto producto)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE Producto SET Descripcion = @descripcion, Marca = @marca, Precio = @precio WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@id", producto.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
        public void Delete(int idproducto)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["miPrimeraVezConnectionString"].ToString()))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Producto WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idproducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
