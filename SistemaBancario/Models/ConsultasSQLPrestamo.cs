using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ConsultasSQLPrestamo
    {
        string conexion = "Data Source=.;Initial Catalog=CoopITLA;Integrated Security=True";

        public IEnumerable<SolicitudPrestamo> obtenerID_cliente()
        {
            List<SolicitudPrestamo> cliList = new List<SolicitudPrestamo>();

            using(SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("buscarCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    SolicitudPrestamo sp = new SolicitudPrestamo();
                    sp.cedulaCliente = dr[""].ToString();
                    cliList.Add(sp);
                }
                con.Close();
            }
            return cliList;
        }

        public void CrearSolicitudPrestamo(SolicitudPrestamo SP)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("crearSolicitudPrestamo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CedulaCliente", SP.cedulaCliente);
                cmd.Parameters.AddWithValue("@EstadoPrestamo", SP.estadoPrestamo);
                cmd.Parameters.AddWithValue("@TipoPrestamo", SP.tipoPrestamoSolicitado);
                cmd.Parameters.AddWithValue("@Monto", SP.montoPrestamo);
                cmd.Parameters.AddWithValue("@Detalle", SP.detalles);
                cmd.Parameters.AddWithValue("@FechaSolicitud", SP.fechaSolicitud);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
