using System.Data;
using System.Data.SqlClient;
using WebApiCL3.Entidad;

namespace WebApiCL3.DAO
{
    public class ArticulosDAO
    {
        private readonly string cad_conex;

        public ArticulosDAO(IConfiguration _conf)
        {
            cad_conex = _conf.GetConnectionString("cn1");
        }

        public List<Articulos> ListarArticulosNo()
        {
            var listado = new List<Articulos>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conex, "LISTA_ARTICULOS");
            while (dr.Read())
            {
                listado.Add(new Articulos()
                {
                    cod_art = dr.GetString(0),
                    nom_art = dr.GetString(1),
                    uni_med = dr.GetString(2),
                    pre_art = dr.GetDecimal(3),
                    stk_art = dr.GetInt32(4)
                });
            }
            dr.Close();

            return listado;
        }

        public List<Articulos> ListarArticulosCodigo(string codart)
        {
            var listado = new List<Articulos>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conex, "FILTRAR_CODIGO_ARTICULO", codart);
            while (dr.Read())
            {
                listado.Add(new Articulos()
                {
                    cod_art = dr.GetString(0),
                    nom_art = dr.GetString(1),
                    uni_med = dr.GetString(2),
                    pre_art = dr.GetDecimal(3),
                    stk_art = dr.GetInt32(4)
                });
            }
            dr.Close(); 
            return listado;
        }

        public List<Articulos> ListarFiltroArticulosNombre(string nomart)
        {
            var listado = new List<Articulos>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conex, "FILTRAR_ARTICULOS_NOMBRE", nomart);
            while (dr.Read())
            {
                listado.Add(new Articulos()
                {
                    cod_art = dr.GetString(0),
                    nom_art = dr.GetString(1),
                    uni_med = dr.GetString(2),
                    pre_art = dr.GetDecimal(3),
                    stk_art = dr.GetInt32(4)
                });
            }
            dr.Close();

            return listado;
        }

        public string LiquidacionArticulo(string codart)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_conex, "LIQUIDACION_ARTICULO_BAJA", codart);

                return $"Producto Liquidado/Baja";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
