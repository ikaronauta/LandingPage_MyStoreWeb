using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Landing_page.Models
{
    public class ActualizacionVendedor
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Vendedor ven)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into landing_page(nombre_tienda, categoria_tienda, nombres_vendedor, apellidos_vendedor, correo_vendedor, celular_vendedor) values(@nombre_tienda, @categoria_tienda, @nombres_vendedor, @apellidos_vendedor, @correo_vendedor, @celular_vendedor)", con);
            comando.Parameters.Add("@nombre_tienda", SqlDbType.VarChar);
            comando.Parameters.Add("@categoria_tienda", SqlDbType.VarChar);
            comando.Parameters.Add("@nombres_vendedor", SqlDbType.VarChar);
            comando.Parameters.Add("@apellidos_vendedor", SqlDbType.VarChar);
            comando.Parameters.Add("@correo_vendedor", SqlDbType.VarChar);
            comando.Parameters.Add("@celular_vendedor", SqlDbType.VarChar);

            comando.Parameters["@nombre_tienda"].Value = ven.Nombre_tienda;
            comando.Parameters["@categoria_tienda"].Value = ven.Categoria_tienda;
            comando.Parameters["@nombres_vendedor"].Value = ven.Nombres_vendedor;
            comando.Parameters["@apellidos_vendedor"].Value = ven.Apellidos_vendedor;
            comando.Parameters["@correo_vendedor"].Value = ven.Correo_vendedor;
            comando.Parameters["@celular_vendedor"].Value = ven.Celular_vendedor;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Vendedor> RecuperarTodos()
        {
            Conectar();
            List<Vendedor> vendedor = new List<Vendedor>();

            SqlCommand com = new SqlCommand("select id_vendedor, nombre_tienda, categoria_tienda, nombres_vendedor, apellidos_vendedor, correo_vendedor, celular_vendedor from landing_page", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Vendedor ven = new Vendedor
                {
                    Id_vendedor = int.Parse(registros["id_vendedor"].ToString()),
                    Nombre_tienda = registros["nombre_tienda"].ToString(),
                    Categoria_tienda = registros["categoria_tienda"].ToString(),
                    Nombres_vendedor = registros["nombres_vendedor"].ToString(),
                    Apellidos_vendedor = registros["apellidos_vendedor"].ToString(),
                    Correo_vendedor = registros["correo_vendedor"].ToString(),
                    Celular_vendedor = registros["celular_vendedor"].ToString(),
                };
                vendedor.Add(ven);
            }
            con.Close();
            return vendedor;
        }
        public Vendedor Recuperar(int id_vendedor)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id_vendedor, nombre_tienda, categoria_tienda, nombres_vendedor, apellidos_vendedor, correo_vendedor, celular_vendedor from landing_page where id_vendedor = @id_vendedor", con);
            comando.Parameters.Add("@id_vendedor", SqlDbType.Int);
            comando.Parameters["@id_vendedor"].Value = id_vendedor;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Vendedor vendedor = new Vendedor();
            if (registros.Read())
            {
                vendedor.Id_vendedor = int.Parse(registros["id_vendedor"].ToString());
                vendedor.Nombre_tienda = registros["nombre_tienda"].ToString();
                vendedor.Categoria_tienda = registros["categoria_tienda"].ToString();
                vendedor.Nombres_vendedor = registros["nombres_vendedor"].ToString();
                vendedor.Apellidos_vendedor = registros["apellidos_vendedor"].ToString();
                vendedor.Correo_vendedor = registros["correo_vendedor"].ToString();
                vendedor.Celular_vendedor = registros["celular_vendedor"].ToString();
            }
            else
            {
                vendedor = null;
            }
            con.Close();
            return vendedor;
        }
        public int Modificar(Vendedor ven)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update landing_page set nombre_tienda = @nombre_tienda, categoria_tienda = @categoria_tienda, nombres_vendedor = @nombres_vendedor, apellidos_vendedor = @apellidos_vendedor, correo_vendedor = @correo_vendedor, celular_vendedor = @celular_vendedor where id_vendedor = @id_vendedor", con);
            comando.Parameters.Add("@id_vendedor", SqlDbType.Int);
            comando.Parameters["@id_vendedor"].Value = ven.Id_vendedor;
            comando.Parameters.Add("@nombre_tienda", SqlDbType.VarChar);
            comando.Parameters["@nombre_tienda"].Value = ven.Nombre_tienda;
            comando.Parameters.Add("@categoria_tienda", SqlDbType.VarChar);
            comando.Parameters["@categoria_tienda"].Value = ven.Categoria_tienda;
            comando.Parameters.Add("@nombres_vendedor", SqlDbType.VarChar);
            comando.Parameters["@nombres_vendedor"].Value = ven.Nombres_vendedor;
            comando.Parameters.Add("@apellidos_vendedor", SqlDbType.VarChar);
            comando.Parameters["@apellidos_vendedor"].Value = ven.Apellidos_vendedor;
            comando.Parameters.Add("@correo_vendedor", SqlDbType.VarChar);
            comando.Parameters["@correo_vendedor"].Value = ven.Correo_vendedor;
            comando.Parameters.Add("@celular_vendedor", SqlDbType.VarChar);
            comando.Parameters["@celular_vendedor"].Value = ven.Celular_vendedor;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int id_vendedor)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from landing_page where id_vendedor = @id_vendedor", con);
            comando.Parameters.Add("@id_vendedor", SqlDbType.Int);
            comando.Parameters["@id_vendedor"].Value = id_vendedor;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}