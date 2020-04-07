using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ConPagos
    {
        string  connectionString = "Data Source=sql5052.site4now.net;User ID=DB_A56E4E_CoopITLA_admin;Password=CoopITLA2020";

        ConSQL conexionSQL = new ConSQL();
        VariablesUser varUser = new VariablesUser();

        // Listar Todos los Pagos
        public IEnumerable<ListarPagos> listarPagos()
        {
            List<ListarPagos> listPagos = new List<ListarPagos>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ListarTodosPagos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarPagos lsp = new ListarPagos();
                    lsp.IDPagos = Convert.ToInt32(dr["ID_Pago"].ToString());
                    lsp.Cliente = dr["FK_ID_Cliente"].ToString();
                    lsp.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.Estado = dr["EstadoPago"].ToString();
                    lsp.Restante = dr["Restante"].ToString();
                    lsp.CuotasPagadas = dr["CuotasCubiertas"].ToString();
                    lsp.CuotasRestantes = dr["CuotasFaltantes"].ToString();
                    
                    
                    listPagos.Add(lsp);
                }
                con.Close();
            }
            return listPagos;
        }

        // Listar Pagos por Cedula
        public IEnumerable<ListarPagos> listarPagosCedula()
        {
            List<ListarPagos> listPagos = new List<ListarPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("ListarTodosPagos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarPagos lsp = new ListarPagos();
                    lsp.IDPagos = Convert.ToInt32(dr["ID_Pgo"].ToString());
                    lsp.Cliente = dr["FK_ID_Cliente"].ToString();
                    lsp.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.Estado = dr["Estado"].ToString();
                    lsp.Restante = dr["Restante"].ToString();
                    lsp.CuotasPagadas = dr["CuotasCubieras"].ToString();
                    lsp.CuotasRestantes = dr["CuotasFaltantes"].ToString();
                   

                    listPagos.Add(lsp);
                }
                con.Close();
            }
            return listPagos;
        }


        public IEnumerable<ListarPagos> listarsolicitudesCliente(string IDPag)
        {
            List<ListarPagos> listPagos = new List<ListarPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("[ListarTodosPagos]", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPagos", IDPag);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarPagos lsp = new ListarPagos();
                    lsp.IDPagos = Convert.ToInt32(dr["ID_Pgo"].ToString());
                    lsp.Cliente = dr["FK_ID_Cliente"].ToString();
                    lsp.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.Estado = dr["Estado"].ToString();
                    lsp.Restante = dr["Restante"].ToString();
                    lsp.CuotasPagadas = dr["CuotasCubieras"].ToString();
                    lsp.CuotasRestantes = dr["CuotasFaltantes"].ToString();
                    
                    listPagos.Add(lsp);
                }
                con.Close();
            }
            return listPagos;
        }

        public IEnumerable<ListarPagos> listarPagosAprobadoCliente(string IDPag)
        {
            List<ListarPagos> listPagos = new List<ListarPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("[ListarTodosPagos]", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPagos", IDPag);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarPagos lsp = new ListarPagos();
                    lsp.IDPagos = Convert.ToInt32(dr["ID_Pgo"].ToString());
                    lsp.Cliente = dr["FK_ID_Cliente"].ToString();
                    lsp.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.Estado = dr["Estado"].ToString();
                    lsp.Restante = dr["Restante"].ToString();
                    lsp.CuotasPagadas = dr["CuotasCubieras"].ToString();
                    lsp.CuotasRestantes = dr["CuotasFaltantes"].ToString();
                    listPagos.Add(lsp);
                }
                con.Close();
            }
            return listPagos;
        }

        public IEnumerable<ListarPagos> listarPagosRechazadoCliente(string cedula)
        {
            List<ListarPagos> listPagos = new List<ListarPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listarsolicitudesRechazadasCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", cedula);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarPagos lsp = new ListarPagos();
                    lsp.IDPagos = Convert.ToInt32(dr["ID_Pgo"].ToString());
                    lsp.Cliente = dr["FK_ID_Cliente"].ToString();
                    lsp.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.Estado = dr["Estado"].ToString();
                    lsp.Restante = dr["Restante"].ToString();
                    lsp.CuotasPagadas = dr["CuotasCubieras"].ToString();
                    lsp.CuotasRestantes = dr["CuotasFaltantes"].ToString();
                    listPagos.Add(lsp);
                }
                con.Close();
            }
            return listPagos;
        }
        public void ActualizarEstadoDePagoAprobado(ListarPagos lsp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ActualizarEstadoPagos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pago", lsp.IDPagos);
                cmd.Parameters.AddWithValue("@Estado", lsp.Estado);
                cmd.Parameters.AddWithValue("@CuotasPagadas", lsp.CuotasPagadas);
                cmd.Parameters.AddWithValue("@CuotasRestantes", lsp.CuotasRestantes);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void ActualizarEstadoDePagosRechazado(ListarPagos lsp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CambiarEstadoSolicitudRechazada", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pago", lsp.IDPagos);
                cmd.Parameters.AddWithValue("@Estado", lsp.Estado);
                cmd.Parameters.AddWithValue("@CuotasPagadas", lsp.CuotasPagadas);
                cmd.Parameters.AddWithValue("@CuotasRestantes", lsp.CuotasRestantes);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public ListarPagos listarPagosPorID(int id)
        {
            ListarPagos listPagos = new ListarPagos();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPagosPorID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPago", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listPagos.IDPagos = Convert.ToInt32(dr["ID_Pgo"].ToString());
                    listPagos.Cliente = dr["FK_ID_Cliente"].ToString();
                    listPagos.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    listPagos.FechaPago = dr["FechaPago"].ToString();
                    listPagos.Monto = dr["Monto"].ToString();
                    listPagos.Estado = dr["Estado"].ToString();
                    listPagos.Restante = dr["Restante"].ToString();
                    listPagos.CuotasPagadas = dr["CuotasCubieras"].ToString();
                }
                con.Close();
            }
            return listPagos;
        }




    }
}
