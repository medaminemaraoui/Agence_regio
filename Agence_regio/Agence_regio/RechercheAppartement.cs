using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Agence_regio
{
    public partial class RechercheAppartement : Form
    {
        public RechercheAppartement()
        {
            InitializeComponent();
        }
        ObjetsAdo OA = new ObjetsAdo();
        private void RechercheAppartement_Load(object sender, EventArgs e)
        {
            OA.Connecter();
            OA.cmd.Connection = OA.cnx;
            OA.cmd.CommandText = "select * from Appartement";
            OA.dr = OA.cmd.ExecuteReader();
            OA.dt = new DataTable();
            OA.dt.Load(OA.dr);
            CB.DataSource = OA.dt;
            CB.DisplayMember = "Type";
            CB.ValueMember = "Type";
            CB.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OA.cmd.CommandText = "select * from Appartement where Type = '" + CB.SelectedValue + "'";
            OA.dr = OA.cmd.ExecuteReader();
            OA.dt = new DataTable();
            OA.dt.Load(OA.dr);
            dgv.DataSource = OA.dt;
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            OA.cmd.CommandText = "select * from Appartement where Type = '" + CB.SelectedValue + "'";
            OA.dr = OA.cmd.ExecuteReader();
            OA.dt = new DataTable { TableName="Apps"};
            OA.dt.Load(OA.dr);
            string filename = @"C:\Users\IBIZA-PC\Desktop\xml try\rappot_XML.xml";
            OA.dt.WriteXml(filename);
            MessageBox.Show("export bien fait !");
            OA.dr.Close();
        }
    }
}
