using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ConPagos
    {
        ConSQL conexionSQL = new ConSQL();

        public IEnumerable<ListaPagos> listarPagos()
        {
            List<ListaPagos> ListPagos = new List<ListaPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("listaPagos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaPagos lsp = new ListaPagos();
                    lsp.ID_Pago = dr["ID_Pago"].ToString();
                    lsp.FK_ID_Cliente = dr["Cliente"].ToString();
                    lsp.FK_ID_Prestamos = dr["Prestamo"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.CuotasCubiertas = dr["CuotasCubiertas"].ToString();
                    lsp.CuotasFaltantes = dr["CuotasFaltantes"].ToString();
                    
                    ListPagos.Add(lsp);
                }
                con.Close();
            }
            return ListPagos;
        }

        public IEnumerable<ListaPagos> ListaPagosPagados()
        {
            List<ListaPagos> ListaPagosPagados = new List<ListaPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("ListaPagosPagados", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaPagos lsp = new ListaPagos();
                    lsp.ID_Pago = dr["ID_Pago"].ToString();
                    lsp.FK_ID_Cliente = dr["Cliente"].ToString();
                    lsp.FK_ID_Prestamos = dr["Prestamo"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.CuotasCubiertas = dr["CuotasCubiertas"].ToString();
                    lsp.CuotasFaltantes = dr["CuotasFaltantes"].ToString();
                    ListaPagosPagados.Add(lsp);
                }
                con.Close();
            }
            return ListaPagosPagados;
        }

        public IEnumerable<ListaPagos> ListaPagosSin()
        {
            List<ListaPagos> ListaPagosSin = new List<ListaPagos>();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("ListaPagosSin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListaPagos lsp = new ListaPagos();
                    lsp.ID_Pago = dr["ID_Pago"].ToString();
                    lsp.FK_ID_Cliente = dr["Cliente"].ToString();
                    lsp.FK_ID_Prestamos = dr["Prestamo"].ToString();
                    lsp.Monto = dr["Monto"].ToString();
                    lsp.FechaPago = dr["FechaPago"].ToString();
                    lsp.CuotasCubiertas = dr["CuotasCubiertas"].ToString();
                    lsp.CuotasFaltantes = dr["CuotasFaltantes"].ToString();
                    ListaPagosSin.Add(lsp);
                }
                con.Close();
            }
            return ListaPagosSin;
        }


        public void ActualizarPagos(ListaPagos lsp)
        {
            

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("CambiarEstadoPagos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pago", lsp.ID_Pago);
                cmd.Parameters.AddWithValue("@Cliente", lsp.FK_ID_Cliente);
                cmd.Parameters.AddWithValue("@Prestamo", lsp.FK_ID_Prestamos);
                cmd.Parameters.AddWithValue("@Monto", lsp.Monto);
                cmd.Parameters.AddWithValue("@PechaPago", lsp.FechaPago);
                cmd.Parameters.AddWithValue("@CuotasCubiertas", lsp.CuotasCubiertas);
                cmd.Parameters.AddWithValue("@CuotasFaltantes", lsp.CuotasFaltantes);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ListaPagos listarPagosID(int id)
        {
            ListaPagos ListPagos = new ListaPagos();

            using (SqlConnection con = new SqlConnection(conexionSQL.conexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerPagosID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Pago", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListPagos.ID_Pago = dr["ID_Pago"].ToString();
                    ListPagos.FK_ID_Cliente = dr["Cliente"].ToString();
                    ListPagos.FK_ID_Prestamos = dr["Prestamo"].ToString();
                    ListPagos.Monto = dr["Monto"].ToString();
                    ListPagos.FechaPago = dr["FechaPago"].ToString();
                    ListPagos.CuotasCubiertas = dr["CuotasCubiertas"].ToString();
                    ListPagos.CuotasFaltantes = dr["CuotasFaltantes"].ToString();
                    
                }
                con.Close();
            }
            return ListPagos;
        }
    }
}
