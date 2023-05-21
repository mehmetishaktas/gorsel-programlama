using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace depo_menu_ekle
{
    public partial class Qrcode : Form
    {
        public Qrcode()
        {
            InitializeComponent();
        }
        public string  qrlabel;
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Qrcode_Load(object sender, EventArgs e)
        {
            label1.Text = qrlabel;
            QRCodeEncoder encoder = new QRCodeEncoder();
            pictureBox1.Image= encoder.Encode(qrlabel); 
        }
    }
}
