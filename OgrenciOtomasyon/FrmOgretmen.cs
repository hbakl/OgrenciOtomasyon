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

namespace OgrenciOtomasyon
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frk = new FrmKulup();
            frk.numara = numara;
            frk.Show();
            this.Hide();
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-H0C41H8;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;


        private void FrmOgretmen_Load(object sender, EventArgs e)
        {
            //Öğretmen ismini form textine yazdıan kodlar.
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OGRTADSOYAD from TBLOGRETMENLER where OGRTID=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr2;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label2.Text = dr2.GetValue(0).ToString();
            }
            dr2.Close();
            baglanti.Close();
        }


        //  Çıkış butonunun kodları
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDers frd = new FrmDers();
            frd.numara = numara;
            frd.Show();
            this.Hide();
        }
    }
}
