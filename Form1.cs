using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ListeEtude
{
    public partial class Form1 : MetroForm
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\wassim_memory\wassim_COURS-Exames\G_Inf\S8\Dotnet\TP2\ListeEtude\db.mdf;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_test_db_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                conn.Close();
                MessageBox.Show("Success");
            }
            catch {
                MessageBox.Show("Erreur");
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            String cne = txt_cne.Text;
            String nom = txt_nom.Text;
            String ville = txt_ville.Text;
            String niveau = txt_niveau.Text;
            try
            {
                //Ouverture de la connexion
                conn.Open();

                //Requete SQL (Insert)
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into etudiants (cne, nom, ville, niveau) values ('" + cne + "','" + nom + "','" + ville + "','" + niveau + "')";

                //Exécution de la requete SQL
                cmd.ExecuteNonQuery();
                
                //Fermeture de la connexion à la base de donnée
                conn.Close();

                MessageBox.Show("Etudiant ajouté avec Succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
