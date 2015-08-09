using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace project
{
    class avion
    {

        public static DataContext dc = new DataContext(myConnection.getConnection());
        
        public static IQueryable<tablaAvion> verAvionesCriterio(int criterio)
        {
            //DataContext dc = new DataContext(myConnection.getConnection());
            var verAvionesCriterio = dc.GetTable<tablaAvion>();
            var ver = from a in verAvionesCriterio
                      where a.ID_AVION.Equals(criterio)
                      select a;

            return ver;
        }

        public static SqlDataAdapter verAsientos()
        {
            myConnection myConnection = new myConnection();
            string consulta = "select * from ASIENTO";
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

        public static SqlDataAdapter verAsientosCriterio(int idAvion)
        {
            myConnection myConnection = new myConnection();
            string consulta = String.Format("SELECT * FROM ASIENTO WHERE ID_AVION = {0}",idAvion);
            SqlConnection conexion = myConnection.createConnection();
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            return da;

        }

       

        public static IQueryable<tablaAvion> verAviones()
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var verAvionesCriterio = dc.GetTable<tablaAvion>();
            var ver = from a in verAvionesCriterio
                      select a;
            return ver;

        }

        public static void guardarAvion(int ID_AVION,string NOMBRE_AVION)
        {
            DataContext dc = new DataContext(myConnection.getConnection());
            var table = dc.GetTable<tablaAvion>();
            tablaAvion nuevo = new tablaAvion { ID_AVION=ID_AVION,NOMBRE_AVION=NOMBRE_AVION,ESTADO="D",ID_VUELO=null};

            table.InsertOnSubmit(nuevo);
            dc.SubmitChanges();

        }

            public static int ultimoAvion(){
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;
                int ultimoId;
                comando.CommandText = "OBT_ULTIMO_AVION_INGRESADO";
                comando.CommandType = CommandType.StoredProcedure;
                conexion.Open();// abre conexion para leer el ultimo Id de avion
                dr=comando.ExecuteReader();

                if (dr.Read())
	            {
		            ultimoId = Convert.ToInt32(dr.GetValue(0))+1;
	            }else
	                {
                        ultimoId = 1;
	                }
                conexion.Close();

                return ultimoId;

            }

            public static void eliminarAvion(int id)
            {
                //DataContext dc = new DataContext(myConnection.getConnection());
                var elimina = dc.GetTable<tablaAvion>();
                var aviones = from a in elimina
                              where a.ID_AVION.Equals(id)
                              select a;
                foreach (var item in aviones)
                {
                    elimina.DeleteOnSubmit(item);
                    dc.SubmitChanges();
                }
                         

            }

            public static void inactivarAsiento(int idAsiento)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_N_ASIENTO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_ASIENTO", idAsiento);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }

            public static void reservarAsiento(int idAsiento)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_R_ASIENTO";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_ASIENTO", idAsiento);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }

            public static void cambiarEstado(int id)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;
                comando.CommandText = "PRDB_CAMBIO_ESTADO_AVION";
                comando.CommandType = CommandType.StoredProcedure;
                if (estadoAvion(id) == "D")
                {

                    comando.Parameters.AddWithValue("@pID_AVION", id);
                    comando.Parameters.AddWithValue("@pESTADO", "N");
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                else
                {
                    comando.Parameters.AddWithValue("@pID_AVION", id);
                    comando.Parameters.AddWithValue("@pESTADO", "D");
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            //nuevo
            public static string estadoAvion(int id)
            {
                myConnection myConnection = new myConnection();
                SqlConnection conexion = myConnection.createConnection();
                SqlCommand comando = myConnection.createCommand(conexion);
                SqlDataReader dr;

                comando.CommandText = "PRDB_OBT_ESTADO_AVION";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@pID_AVION", id);
                conexion.Open();
                dr = comando.ExecuteReader();
                string estado = "N";
                if (dr.Read())
                {
                    estado = Convert.ToString(dr.GetValue(0));
                }

                conexion.Close();

                return estado;
            }

        
       

    }
}
