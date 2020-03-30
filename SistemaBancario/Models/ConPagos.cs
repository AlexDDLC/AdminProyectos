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
                    lsp.CuotasCubiertas = dr["CuotasCubiertas"].ToString();
                    lsp.CuotasFaltantes = dr["CuotasFaltantes"].ToString();
                    
                    ListPagos.Add(lsp);
                }
                con.Close();
            }
            return ListPagos;
        }
    }
}
