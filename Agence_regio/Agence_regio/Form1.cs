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

namespace Agence_regio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ObjetsAdo OA = new ObjetsAdo();
        void afficher()
        {
            OA.cmd.CommandText = "select * from Appartement";
            OA.dr = OA.cmd.ExecuteReader();
            OA.dt = new DataTable();
            OA.dt.Load(OA.dr);
            dgv.DataSource = null;
            dgv.DataSource = OA.dt;
            OA.dr.Close();
           
        }
        bool existe()
        {
            int cpt;
            OA.cmd.CommandText = "select * from Appartement where Code_appt ='"+txtCode.Text+"'";
            cpt = Convert.ToInt32(OA.cmd.ExecuteScalar());
            if(cpt==0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OA.cmd.Connection = OA.cnx;
            OA.Connecter();
            try
            {
                afficher();
            }
            catch { OA.dr.Close(); }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCode.Text == "" || txtAddress.Text=="" || txtprix.Text =="" || CB.SelectedItem == "")
            {
                MessageBox.Show("remplire tout les champs");
                return;
            }if(existe()==true)
            { 
            OA.cmd.CommandText = "insert into Appartement values( '"+txtCode.Text+"','"+txtAddress.Text+"','"+CB.SelectedItem+"','"+txtprix.Text+"')";
            OA.cmd.ExecuteNonQuery();
                MessageBox.Show("Ajoute bien fait !!");
                afficher();
            }
            else
            {
                MessageBox.Show("Donner autre Code n'est pas existe");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtAddress.Text == "" || txtprix.Text == "" || CB.SelectedItem == "")
            {
                MessageBox.Show("remplire tout les champs");
                return;
            }
            if (existe() == false)
            {
                OA.cmd.CommandText = "update Appartement set Address = '" + txtAddress.Text + "',Type = '" + CB.SelectedItem + "',Prix_loyer ='" + txtprix.Text + "' where Code_appt = '"+txtCode.Text+ "' ";
                OA.cmd.ExecuteNonQuery();
                MessageBox.Show("Modification bien fait !!");
                afficher();
            }
            else
            {
                MessageBox.Show(" Code n'est pas existe");
            }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("remplire tout les champs");
                return;
            }

            else
            {
                if (existe() == false)
                {

                    DialogResult d = MessageBox.Show("voulez vous vraiment supprimer cette appartemt ?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d.Equals(DialogResult.Yes))
                    {
                        OA.cmd.CommandText = "delete from Appartement where  Code_appt = '" + txtCode.Text + "' ";
                        OA.cmd.ExecuteNonQuery();
                        MessageBox.Show("Suppression bien fait !!");
                        
                        afficher();
                    }
                }
                else
                {
                    MessageBox.Show(" Code n'est pas existe");
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtAddress.Clear();
            txtprix.Clear();
            CB.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("voulez vous quiter?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d.Equals(DialogResult.Yes))
            { 
                this.Close();
            }
        }
    }
}
