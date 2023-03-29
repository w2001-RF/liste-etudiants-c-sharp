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

            try
            {
                //Ouverture de la connexion
                conn.Open();

                //Requete SQL (select all)
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [etudiants]";
                cmd.ExecuteNonQuery();

                //Contiendre les données
                DataTable dt = new DataTable();

                //Permet de lire les données
                SqlDataAdapter datado = new SqlDataAdapter(cmd.CommandText, conn);

                //Récupère les données
                datado.Fill(dt);

                //Renommer les noms des columns
                dt.Columns["id"].ColumnName = "ID";
                dt.Columns["cne"].ColumnName = "CNE";
                dt.Columns["nom"].ColumnName = "Nom";
                dt.Columns["ville"].ColumnName = "Ville";
                dt.Columns["niveau"].ColumnName = "Niveau";

                //Affiche les données dans la grille = EtdDataGrid
                EtdDataGrid.DataSource = dt;

                //Fermeture de la connexion à la base de donnée
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btn_show_Click(object sender, EventArgs e)
        {
            try
            {
                //Ouverture de la connexion
                conn.Open();

                //Requete SQL (select all)
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [etudiants]";
                cmd.ExecuteNonQuery();

                //Contiendre les données
                DataTable dt = new DataTable();

                //Permet de lire les données
                SqlDataAdapter datado = new SqlDataAdapter(cmd.CommandText, conn);

                //Récupère les données
                datado.Fill(dt);

                //Renommer les noms des columns
                dt.Columns["id"].ColumnName = "ID";
                dt.Columns["cne"].ColumnName = "CNE";
                dt.Columns["nom"].ColumnName = "Nom";
                dt.Columns["ville"].ColumnName = "Ville";
                dt.Columns["niveau"].ColumnName = "Niveau";

                //Affiche les données dans la grille = EtdDataGrid
                EtdDataGrid.DataSource = dt;

                //Fermeture de la connexion à la base de donnée
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
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
                
                //Prendre ID de l'étudiant sélectionné
                int selectedIndex = EtdDataGrid.SelectedRows[0].Index;
                int rowID = int.Parse(EtdDataGrid.Rows[selectedIndex].Cells["ID"].Value.ToString());

                cmd.CommandText = "update [etudiants] set CNE = '" + cne + "', NOM = '" + nom + "',VILLE = '" + ville + "', NIVEAU = '" + niveau + "' where ID = '" + rowID + "'";

                //Exécution de la requete SQL
                cmd.ExecuteNonQuery();

                //Fermeture de la connexion à la base de donnée
                conn.Close();

                MessageBox.Show("Etudiant mis à jour avec Succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            String cne = txt_cne.Text;
            try
            {
                //Ouverture de la connexion
                conn.Open();

                //Requete SQL (Insert)
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from [etudiants] where cne='" + cne + "'";

                //Exécution de la requete SQL
                cmd.ExecuteNonQuery();

                //Fermeture de la connexion à la base de donnée
                conn.Close();

                MessageBox.Show("Etudiant supprimé avec Succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
