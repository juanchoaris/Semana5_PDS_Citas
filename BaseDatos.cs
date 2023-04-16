using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioMedico.Modelo;
using MySql.Data.MySqlClient;

namespace ConsultorioMedico
{
    public class BaseDatos
    {
        static string server = "localhost";
        static string user = "root";
        static string pass = "123456";
        static string port = "3306";
        static string db = "citasmedicas";

        string cadenaConexion = "server=" + server + ";" + "port=" + port + ";" + "user id=" + user + ";" + "password=" + pass + ";" + "database=" + db + ";";

        public void insertRecord(AsignacionCitas asignacionCitas)
        {
            MySqlConnection cnx = new MySqlConnection();
            try
            {

                cnx.ConnectionString = cadenaConexion;


                string instructionSQL = string.Format("INSERT INTO citas (`Nombres`, `Apellidos`, `TipoDocumento`, `NroDocumento`, `CorreoElectronico`, `Edad`, `Genero`, `Especialidad`, `Medico`, `FechaCita`, `Observaciones`) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                        asignacionCitas.Nombres, asignacionCitas.Apellidos, asignacionCitas.TipoDocumento, asignacionCitas.NroDocumento,
                        asignacionCitas.CorreoElectronico, asignacionCitas.Edad, asignacionCitas.Genero, asignacionCitas.Especialidad, asignacionCitas.Medico,
                        asignacionCitas.FechaCita, asignacionCitas.Observaciones);

                MySqlCommand cmd = new MySqlCommand(instructionSQL, cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("¡¡¡Cita asignada exitosamente...!!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }

        public List<AsignacionCitas> consultTable()
        {
            MySqlConnection cnx = new MySqlConnection();
            try
            {
                List<AsignacionCitas> asignacionCitas = new List<AsignacionCitas>();
                cnx.ConnectionString = cadenaConexion;
                string instructionSQL = "SELECT * FROM citas";

                cnx.Open();
                MySqlCommand cmd = new MySqlCommand(instructionSQL, cnx);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                DataTable dT = new DataTable();
                mySqlDataAdapter.Fill(dT);

                if (dT.Rows.Count > 0)
                {
                    foreach (DataRow item in dT.Rows)
                    {
                        asignacionCitas.Add(new AsignacionCitas()
                        {
                            Id = Convert.ToInt32(item["Id"]),
                            Nombres = item["Nombres"].ToString(),
                            Apellidos = item["Nombres"].ToString(),
                            TipoDocumento = item["TipoDocumento"].ToString(),
                            NroDocumento = item["NroDocumento"].ToString(),
                            CorreoElectronico = item["CorreoElectronico"].ToString(),
                            Edad = Convert.ToInt32(item["Edad"]),
                            Genero = item["Genero"].ToString(),
                            Especialidad = item["Especialidad"].ToString(),
                            Medico = item["Medico"].ToString(),
                            Observaciones = item["Observaciones"].ToString(),
                            FechaCita = item["FechaCita"].ToString()
                        });
                    }
                }

                return asignacionCitas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<AsignacionCitas>();
            }
            finally
            {
                cnx.Close();
            }
        }


    }
}
