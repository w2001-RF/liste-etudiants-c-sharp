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
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [etudiants]";

                SqlDataReader dr = cmd.ExecuteReader();

                conn.Close();
                MessageBox.Show("Success");
            }
            catch {
                MessageBox.Show("Erreur");
            }
        }
    }
}
