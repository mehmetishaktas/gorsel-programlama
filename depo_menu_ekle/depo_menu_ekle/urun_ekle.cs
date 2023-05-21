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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace depo_menu_ekle
{
   
    public partial class urun_ekle : Form
    {
        MySqlCommand cmd;
        MySqlConnection con;
        public urun_ekle()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=depotakip;user=root;Pwd=;SslMode=none");
            //192.168.1.105
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.CommandText = "INSERT INTO `urun_takip`(`urun_adi`, `urun_ozelligi`, `urun_adet`,  `bulundugu_depo`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("ÜRÜN BAŞARIYLA EKLENDİ");
            con.Close();
            menu guncelle = (menu)Application.OpenForms["menu"];
            guncelle.listele();    
            this.Close();
        }

        private void urun_ekle_Load(object sender, EventArgs e)
        {

        }
    }
}
