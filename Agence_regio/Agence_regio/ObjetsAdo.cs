using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Agence_regio
{
    class ObjetsAdo
    {
        public SqlConnection cnx = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        
        public void Connecter()
        {
            if(cnx.State == ConnectionState.Closed || cnx.State == ConnectionState.Broken )
            {
                cnx.ConnectionString = @"Data Source=IBIZA\SQLEXPRESS;Initial Catalog=Agence_regio;Integrated Security=True";
                cnx.Open();
            }
        }
        public void Deconneter()
        {
            if(cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}
