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
namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string cs = "Data source=DESKTOP-CQJ6GR7; initial catalog=Prodavnica; integrated security=true";
        public int red = 0;
        DataTable stavka = new DataTable();
        public void osvezi(int x)
        {
            txt_id.Text = stavka.Rows[x]["ID"].ToString();
            txt_artikal.Text = stavka.Rows[x]["artikal"].ToString();
            txt_kom.Text = stavka.Rows[x]["kom"].ToString();
            txt_cena.Text = stavka.Rows[x]["cena"].ToString();
            txt_popust.Text = stavka.Rows[x]["popust"].ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from stavka", veza);
            adapter.Fill(stavka);
            osvezi(red);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            red = 0;
            osvezi(red);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (red != 0)
            {
                red--;
                osvezi(red);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (red != stavka.Rows.Count - 1)
            {
                red++;
                osvezi(red);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            red = stavka.Rows.Count - 1;
            osvezi(red);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Delete from stavka where id=" + txt_id.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from stavka", veza);
            stavka.Clear();
            adapter.Fill(stavka);
            if (red == stavka.Rows.Count)
            {
                red--;
            }
            osvezi(red);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Update stavka set artikal='" + txt_artikal.Text + "' ,kom='" + txt_kom.Text + "',cena='" + txt_cena.Text + "',popust='" + txt_popust.Text + "' where id=" + txt_id.Text, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from stavka", veza);
            stavka.Clear();
            adapter.Fill(stavka);
            osvezi(red);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredba = new SqlCommand("Insert into stavka (artikal,kom,cena,popust) values ('" + txt_artikal.Text + "' ,'" + txt_kom.Text + "' ,'" + txt_cena.Text + "' ,'" + txt_popust.Text + "')", veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from stavka", veza);
            stavka.Clear();
            adapter.Fill(stavka);
            osvezi(red);
        }
    }
}
