using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace depo_menu_ekle
{
    public partial class Form2 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public Form2()
        {
            InitializeComponent();
          //bakabileceğiniz bir şekilde connect ayarlandı 
            con = new MySqlConnection("Server=localhost;Database=depotakip;user=root;Pwd=;SslMode=none");                    
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string k_adi = textBox1.Text;
            string sifre = textBox2.Text;

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from kullanici where kullanici_adi='" + k_adi + "' and sifre ='"+sifre+ "'";
            reader = cmd.ExecuteReader();
            if (reader.Read() )
            {
                MessageBox.Show("giriş başarılı");
                menu fa= new menu();
                fa.Show();
                this.Hide();
                
                
                
            }
            else
            {
                MessageBox.Show("yanlış");
            }
            con.Close();
            
        }
        public void kapat()
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
