using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
                fr.numara = textBox1.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Lütfen öğrenci id bilgisini boş bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                FrmOgretmen fro = new FrmOgretmen();
                fro.numara = textBox1.Text;
                fro.Show();
            }
            else
            {
                MessageBox.Show("Lütfen öğretmen id bilgisini boş bırakmayınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
    }
}
