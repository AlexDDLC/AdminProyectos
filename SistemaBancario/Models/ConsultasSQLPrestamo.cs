using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ConsultasSQLPrestamo
    {
        ConSQL conexionSQL = new ConSQL();
        VariablesUser varUser = new VariablesUser();

        public IEnumerable<ListarSolicitudesPrestamo> listarsolicitudes()
        {
            List<ListarSolicitudesPrestamo> solList = new List<ListarSolicitudesPrestamo>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarSolicitudesPrestamo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id_sol = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.estado = dr["EstadoPrestamo"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    solList.Add(lsp);
                }
                con.Close();
            }
            return solList;
        }

        public IEnumerable<ListarSolicitudesPrestamo> listarsolicitudesCliente(string cedula)
        {
            List<ListarSolicitudesPrestamo> solList = new List<ListarSolicitudesPrestamo>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarsolicitudesCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id_sol = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.estado = dr["EstadoPrestamo"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    solList.Add(lsp);
                }
                con.Close();
            }
            return solList;
        }

        public IEnumerable<ListarSolicitudesPrestamo> listarsolicitudesAprobadoCliente(string cedula)
        {
            List<ListarSolicitudesPrestamo> solList = new List<ListarSolicitudesPrestamo>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarsolicitudesAprobadasCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id_sol = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.estado = dr["EstadoPrestamo"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    solList.Add(lsp);
                }
                con.Close();
            }
            return solList;
        }

        public IEnumerable<ListarSolicitudesPrestamo> listarsolicitudesRechazadoCliente(string cedula)
        {
            List<ListarSolicitudesPrestamo> solList = new List<ListarSolicitudesPrestamo>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarsolicitudesRechazadasCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id_sol = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.estado = dr["EstadoPrestamo"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    solList.Add(lsp);
                }
                con.Close();
            }
            return solList;
        }

        public IEnumerable<ListarSolicitudesPrestamo> listarSolicitudesRechazadas()
        {
            List<ListarSolicitudesPrestamo> listaPresRech = new List<ListarSolicitudesPrestamo>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarSolicitudesRechazadas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id_sol = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    lsp.fechaRehazo = dr["fechaRechazo"].ToString();
                    listaPresRech.Add(lsp);
                }
                con.Close();
            }
            return listaPresRech;
        }

        public IEnumerable<ListarSolicitudesPrestamo> listarSolicitudesAprobadas()
        {
            List<ListarSolicitudesPrestamo> listaPresAprob = new List<ListarSolicitudesPrestamo>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarSolicitudesAprobadas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarSolicitudesPrestamo lsp = new ListarSolicitudesPrestamo();
                    lsp.id_sol = dr["ID_Solicitud"].ToString();
                    lsp.solicitante = dr["nombreCliente"].ToString();
                    lsp.cedula = dr["Cedula"].ToString();
                    lsp.monto = dr["Monto"].ToString();
                    lsp.tipo = dr["TipoPrestamo"].ToString();
                    lsp.fechasolicitud = dr["FechaSolicitud"].ToString();
                    lsp.detalles = dr["Detalle"].ToString();
                    lsp.fechaRehazo = dr["fechaAprobado"].ToString();
                    lsp.cuotas = Convert.ToInt32(dr["Cuotas"]);
                    lsp.tasaInteres = Convert.ToSingle(dr["tasaInteres"]);
                    lsp.cuotaMensual = Convert.ToSingle(dr["CuotaMensual"]);
                    listaPresAprob.Add(lsp);
                }
                con.Close();
            }
            return listaPresAprob;
        }

        public void CrearSolicitudPrestamo(SolicitudPrestamo SP)
        {
            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
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

        public void ActualizarEstadoDePrestamoAprobado(ListarSolicitudesPrestamo lsp)
        {
            using(SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("CambiarEstadoSolicitudAprobada", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Solicitud", lsp.id_sol);
                cmd.Parameters.AddWithValue("@CedulaCliente", lsp.cedula);
                cmd.Parameters.AddWithValue("@cuotas", lsp.cuotas);
                cmd.Parameters.AddWithValue("@tasaInteres", lsp.tasaInteres);
                cmd.Parameters.AddWithValue("@nuevoEstado", lsp.NuevoEstadoPrestamo);
                cmd.Parameters.AddWithValue("@fechaCambio", lsp.fechaRehazo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void ActualizarEstadoDePrestamoRechazado(ListarSolicitudesPrestamo lsp)
        {
            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("CambiarEstadoSolicitudRechazada", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Solicitud", lsp.id_sol);
                cmd.Parameters.AddWithValue("@nuevoEstado", lsp.NuevoEstadoPrestamo);
                cmd.Parameters.AddWithValue("@fechaCambio", lsp.fechaRehazo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ListarSolicitudesPrestamo listarsolicitudPorID(int id)
        {
            ListarSolicitudesPrestamo solList = new ListarSolicitudesPrestamo();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerSolicitudPorID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_sol", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    solList.id_sol = dr["ID_Solicitud"].ToString();
                    solList.solicitante = dr["solicitante"].ToString();
                    solList.cedula = dr["CedulaCliente"].ToString();
                    solList.monto = dr["Monto"].ToString();
                    solList.estado = dr["EstadoPrestamo"].ToString();
                    solList.tipo = dr["TipoPrestamo"].ToString();
                    solList.fechasolicitud = dr["FechaSolicitud"].ToString();
                    solList.detalles = dr["Detalle"].ToString();
                }
                con.Close();
            }
            return solList;
        }
    }
}
