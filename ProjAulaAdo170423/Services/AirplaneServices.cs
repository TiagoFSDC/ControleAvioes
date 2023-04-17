using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjAulaAdo170423.Model;
using ProjAulaAdo170423.Models;

namespace ProjAulaAdo170423.Services
{
    public class AirplaneServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Banco\Sql.mdf";
        readonly SqlConnection Conn;

        public AirplaneServices()
        {
            Conn = new SqlConnection(strconn);
            Conn.Open();
        }


        public bool Insert(Airplane airplane)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Airplane (Name, NumberofPassangers, Description, IdEngine) " +
                    "values (@Name, @NumberofPassangers, @Description, @IdEngine)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", airplane.Name));
                commandInsert.Parameters.Add(new SqlParameter("@NumberofPassangers", airplane.NumberofPassangers));
                commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Description));
                commandInsert.Parameters.Add(new SqlParameter("@IdEngine", InsertEngine(airplane)));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return status;
        }

        private int InsertEngine(Airplane airplane)
        {
            string strInsert = "insert into Engine (Description) values (@Description); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Engine.Description));

            return (int)commandInsert.ExecuteScalar();
        }
        public List<Airplane> FindAll()
        {
            List<Airplane> airplanes = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select a.Id,");
            sb.Append("       a.Name,");
            sb.Append("       a.Description,");
            sb.Append("       a.NumberofPassangers,");
            sb.Append("       e.Description Engine  ");
            sb.Append("  from Airplane a,");
            sb.Append("      Engine e");
            sb.Append(" where a.IdEngine = e.Id");


            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Airplane airplane = new();

                airplane.Id = (int)dr["Id"];
                airplane.Name = (string)dr["Name"];
                airplane.NumberofPassangers = (int)dr["NumberofPassangers"];
                airplane.Description = (string)dr["Description"];
                airplane.Engine = new Engine() { Description = (string)dr["Engine"] };

                airplanes.Add(airplane);
            }
            return airplanes;
        }
    }
}
