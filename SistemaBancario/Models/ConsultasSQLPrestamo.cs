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

        public List<ListarSolicitudesPrestamo> cliList = new List<ListarSolicitudesPrestamo>();

        public IEnumerable<ListarSolicitudesPrestamo> listarsolicitudes()
        {
            using(SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("listarSolicitudesPrestamo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.estado = dr["EstadoPrestamo"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    cliList.Add(lsp);
                    Console.WriteLine(cliList);
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
