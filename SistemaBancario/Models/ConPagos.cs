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

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("ListarTodosPagos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListarPagos lsp = new ListarPagos();
                    lsp.IDPagos = dr["ID_Pagos"].ToString();
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
                    lsp.IDPagos = dr["ID_Pagos"].ToString();
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
                    lsp.IDPagos = dr["ID_Pagos"].ToString();
                    lsp.Cliente = dr["FK_ID_Cliente"].ToString();
                    lsp.Prestamo = dr["FK_ID_Prestamo"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.Estado = dr["Estado"].ToString();
                    lsp.Restante = dr["Restante"].ToString();
                    lsp.CuotasPagadas = dr["CuotasCubieras"].ToString();
                    lsp.CuotasRestantes = dr["CuotasFaltantes"].ToString();
                    lsp.CuotasRestantes = dr["Detalle"].ToString();
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
                    lsp.IDPagos = dr["ID_Pagos"].ToString();
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
                    lsp.IDPagos = dr["ID_Pagos"].ToString();
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

        

        

    }
}
