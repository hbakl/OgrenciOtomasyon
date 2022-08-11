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
            //datagridviewe dersleri çeken kodlar.
            SqlCommand komut = new SqlCommand("select * from TBLKULUPLER ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "KULÜP İD";
            dataGridView1.Columns[1].HeaderText = "KULÜP ADI";

        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmOgretmen fro = new FrmOgretmen();
            fro.numara = numara;
            fro.Show();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            BtnEkle.Enabled = false;
            BtnGuncelle.Enabled = true;
            BtnSil.Enabled = true;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!="")
            {

                //güncelleme butonu kodları
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update TBLKULUPLER set KULUPAD=@p1 where KULUPID=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kulüp başarı ile günccelelldi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //datagridviewde dersleri yenileyen kodlar.
                SqlCommand komut2 = new SqlCommand("select * from TBLKULUPLER ", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

                //Güncelleme sonrası butonları ve textboxları düzenleyen kısım
                textBox1.Text = "";
                textBox2.Text = "";
                BtnEkle.Enabled = true;
                BtnSil.Enabled = false;
                BtnGuncelle.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lütfen bir ders adı giriniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //ekleme butonu kodları
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TBLDERSLER (DERSAD) values (@p1)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox2.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Yeni ders başarı ile kayıt edildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //datagridviewde dersleri yenileyen kodlar.
                SqlCommand komut2 = new SqlCommand("select * from TBLDERSLER ", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

                //Ekleme sonrası butonları ve textboxları düzenleyen kısım
                textBox1.Text = "";
                textBox2.Text = "";
                BtnEkle.Enabled = true;
                BtnSil.Enabled = false;
                BtnGuncelle.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lütfen bir kulüp adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
