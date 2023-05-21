
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace depo_menu_ekle
{     
    public partial class urun_guncelle : Form
    {
        MySqlCommand cmd;
        MySqlConnection con;
        public string urun_id;
        public string urun_adi;
        public string urun_ozelligi;
        public string urun_adet;
        public string bulundugu_depo;
        public urun_guncelle()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=depotakip;user=root;Pwd=;SslMode=none");
            //192.168.1.105


        }
       
        
        private void urun_guncelle_Load(object sender, EventArgs e)
        {
            textBox6.Text = urun_adi;
            textBox5.Text = urun_ozelligi;
            textBox3.Text = urun_adet;
            textBox4.Text = bulundugu_depo;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.CommandText = "UPDATE `urun_takip` SET `urun_adi`='" + textBox6.Text + "',`urun_ozelligi`='" + textBox5.Text + "',`urun_adet`='" + textBox3.Text + "',`bulundugu_depo`='" + textBox4.Text + "' where urun_id ='" + urun_id + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("ÜRÜN BAŞARIYLA GÜNCELLENDİ");
            con.Close();
            menu guncelle = (menu)Application.OpenForms["menu"];
            guncelle.listele();
            this.Close();
        }
    }
}
