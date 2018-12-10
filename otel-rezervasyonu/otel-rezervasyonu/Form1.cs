using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace otel_rezervasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            csb = new MySqlConnectionStringBuilder();
            csb.Server = "localhost";
            csb.UserID = "root";
            csb.Password = "";
            csb.Database = "otel-otomasyonu";
            baglanti = new MySqlConnection(csb.ConnectionString);// Veritabanı bağlantı ayarları
        }

        /*
         * C# Otel Otomasyonu - Proje ve Kod Paylaşım Platformu
         * https://www.projevekod.com/
         */

        MySqlConnectionStringBuilder csb;
        MySqlConnection baglanti;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        DataTable dt;
        Button b;

        void kontrol()
        {
            baglanti.Open();
            cmd = new MySqlCommand("select * from musteriler", baglanti);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in panel_butonlar.Controls)
                {
                    if (item is Button)
                    {
                        if (dr["oda_numarasi"].ToString() == item.Text)
                        {
                            item.BackColor = Color.Red;
                        }
                    }
                }
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kontrol();
        }

        private void Butons_Click(object sender, EventArgs e)
        {
            b = sender as Button;
            textBox_Musteri_No.Text = b.Text;
            textBox_Ad_Soyad.Text = "";
            textBox_Tel.Text = "";
            baglanti.Open();
            cmd = new MySqlCommand("select * from musteriler where oda_numarasi=@m_no", baglanti);
            cmd.Parameters.Add("@m_no",b.Text);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in panel_butonlar.Controls)
                {
                    if (item is Button)
                    {
                        if (dr["oda_numarasi"].ToString() == item.Text)
                        {
                            textBox_Musteri_No.Text = dr["oda_numarasi"].ToString();
                            textBox_Ad_Soyad.Text = dr["musteri_adi_soyadi"].ToString();
                            textBox_Tel.Text = dr["musteri_tel"].ToString();
                        }
                    }
                }
            }
            baglanti.Close();
            baglanti.Open();
            cmd = new MySqlCommand("select * from odalar", baglanti);
            cmd.Parameters.Add("@m_no", b.Text);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["oda_no"].ToString() == b.Text)
                {
                    label_oda_no.Text = "Oda numarası : " + dr["oda_no"].ToString();
                    label_oda_sayisi.Text = "Oda sayısı : " + dr["oda_sayisi"].ToString();
                    label_oda_yatak_sayisi.Text = "Yatak sayısı : " + dr["oda_yatak_sayisi"].ToString();
                    label_oda_cift_kisilik_yatak.Text = "Çift Kişilik Yatak : " + dr["oda_cift_kisilik_yatak"].ToString();
                }
            }
            baglanti.Close();
        }

        private void button_musteri_ekle_Click(object sender, EventArgs e)
        {
            if (textBox_Ad_Soyad.Text != "" && textBox_Musteri_No.Text != "" && textBox_Tel.Text != "")
            {
                baglanti.Open();
            cmd = new MySqlCommand("insert into musteriler(oda_numarasi,musteri_adi_soyadi,musteri_tel)values(@m_no,@m_ad,@m_tel)", baglanti);
            cmd.Parameters.Add("@m_no", textBox_Musteri_No.Text);
            cmd.Parameters.Add("@m_ad", textBox_Ad_Soyad.Text);
            cmd.Parameters.Add("@m_tel", textBox_Tel.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();
            kontrol();
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Ad_Soyad.Text != "" && textBox_Musteri_No.Text != "" && textBox_Tel.Text != "")
                {
                    baglanti.Open();
                cmd = new MySqlCommand("delete from musteriler where oda_numarasi=@m_no", baglanti);
                cmd.Parameters.Add("@m_no", textBox_Musteri_No.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Silindi");
                baglanti.Close();
                b.BackColor = Color.Black;
                    textBox_Musteri_No.Text = b.Text;
                    textBox_Ad_Soyad.Text = "";
                    textBox_Tel.Text = "";
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zaten silinmiş" + ex);
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Ad_Soyad.Text!="" && textBox_Musteri_No.Text!="" && textBox_Tel.Text!="")
                {
                    baglanti.Open();
                    cmd = new MySqlCommand("update musteriler set musteri_adi_soyadi=@m_ad,musteri_tel=@m_tel where oda_numarasi=@m_no", baglanti);
                    cmd.Parameters.Add("@m_no", textBox_Musteri_No.Text);
                    cmd.Parameters.Add("@m_ad", textBox_Ad_Soyad.Text);
                    cmd.Parameters.Add("@m_tel", textBox_Tel.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Güncellendi");
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }
        }
    }
}
