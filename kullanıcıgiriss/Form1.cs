using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


namespace kullanıcıgiriss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select*From Bilgi where kullanici_adi='"
                +textBox1.Text.ToString()+"'and eposta'"+textBox2.ToString()+"'",bgln.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {

                        bgln.baglanti().Open();

                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresim = ("beyzaeced@gmail.com");
                    String sifre = ("beyza06");
                    String smptserver = "smtp.gmail.com";
                    String kime = (oku["eposta"].ToString());
                    String konu = ("Şifre Hatırlatma Maili");
                    String yaz = ("Sayın, " + oku["ad|soyad"].ToString() + "\n" + "Bizden" + tarih + " Tarihinde Şifre Hatırlatma Talebinde Bulundunuz"
                        + "\n" + "Parolanız:" + oku["sifre"].ToString() + "\nİyi Günler");
                    smtpserver.Credentials = new NetworkCredential(mailadresim, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptserver;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresim);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş olduğunuz bilgiler uyuşuyor.Şifreniz mail adresinize gönderilmiştir");
                    this.Hide();
                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail gönderme hatası!", Hata.Message);
                }
            }

        }
    }
}
