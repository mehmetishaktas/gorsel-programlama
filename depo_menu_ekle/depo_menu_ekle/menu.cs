using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Crmf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace depo_menu_ekle
{   
    public partial class menu : Form
    {
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        MySqlConnection con;
        
        public menu()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=depotakip;user=root;Pwd=;SslMode=none");
            listele();


            //192.168.1.105
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
        }
       
        public void listele()
        {          
            Form2 ff= new Form2();        
            dt = new DataTable();                    
            con.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM urun_takip", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            datagridayar(dataGridView1);
       }
       
        public void datagridayar(DataGridView data)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            
        }      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            urun_ekle ekle = new urun_ekle ();
            ekle.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            urun_guncelle guncelle = new urun_guncelle ();
            guncelle.urun_id=dataGridView1.CurrentRow.Cells[0].Value.ToString();
            guncelle.urun_adi = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            guncelle.urun_ozelligi= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            guncelle.urun_adet= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            guncelle.bulundugu_depo= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            guncelle.Show();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(label1.Text == "")
            {
                MessageBox.Show("ÜRÜN SEÇİNİZ");
            }
            else
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.CommandText = "DELETE FROM `urun_takip` WHERE urun_id='" + label1.Text + "'";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("ÜRÜN BAŞARIYLA SİLİNDİ");
                con.Close();
                listele();
                label1.Text = null;
            }
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           Form2 KAPAT = (Form2)Application.OpenForms["Form2"];
            KAPAT.kapat();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Qrcode qrcode = new Qrcode();
            qrcode.qrlabel= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            qrcode.Show();
        }
    }
}
