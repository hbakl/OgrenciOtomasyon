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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-H0C41H8;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD, SINAV1, SINAV2,SINAV3,PROJE,ORTALAMA,DURUM from TBLNOTLAR inner join TBLDERSLER on TBLNOTLAR.DERSID=TBLDERSLER.DERSID where OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Öğrenci ismini form textine yazdıan kodlar.
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OGRAD+' '+OGRSOYAD from TBLOGRENCILER where OGRID=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr2;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                this.Text = dr2.GetValue(0).ToString();
            }
            dr2.Close();
            baglanti.Close();
        }
    }
}
