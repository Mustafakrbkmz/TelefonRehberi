using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkTelefonRehberi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TelRehberiDBEntities db = new TelRehberiDBEntities();
        private void btnBilgileriGetir_Click(object sender, EventArgs e)
        {
            VerileriCek();
        }

        private void VerileriCek()
        {
            dgvTelefonlar.DataSource = db.Kisiler.ToList();
            #region Kisiidyi getirmeme
            //dgvTelefonlar.DataSource = db.Kisiler.Select(k => new
            //{
            //    k.KisiAdi,
            //    k.KisiSoyadi,
            //    k.TelefonNo
            //}).ToList(); 
            #endregion
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Mustafa Karabekmez
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        MessageBox.Show("Lutfen tum bilgileri giriniz.");
                        return;
                    }
                }
            }

            //1.Yontem
            //Kisiler yeniKisi = new Kisiler();
            //yeniKisi.KisiAdi = txtAd.Text;
            //yeniKisi.KisiSoyadi = txtSoyad.Text;
            //yeniKisi.TelefonNo = txtTelNo.Text;
            //db.Kisiler.Add(yeniKisi);
            //db.SaveChanges();
            //VerileriCek();

            //2.Yontem
            //Kisiler yeniKisi = new Kisiler
            //{
            //    KisiAdi = txtAd.Text,
            //    KisiSoyadi = txtSoyad.Text,
            //    TelefonNo = txtTelNo.Text
            //};
            //db.Kisiler.Add(yeniKisi);
            //db.SaveChanges();
            //VerileriCek();

            //3.Yontem
            db.Kisiler.Add(new Kisiler
            {
                KisiAdi = txtAd.Text,
                KisiSoyadi = txtSoyad.Text,
                TelefonNo = txtTelNo.Text
            });
            db.SaveChanges();
            VerileriCek();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvTelefonlar.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTelefonlar.SelectedRows[0].Cells[0].Value);
                //Kisiler silinecek = db.Kisiler.FirstOrDefault(kisi => kisi.KisiID == id);

                //Kisiler silinecek = db.Kisiler.Find(id);

                //db.Kisiler.Remove(silinecek);
                //db.SaveChanges();
                //VerileriCek();

                db.Kisiler.Remove(db.Kisiler.Find(id));
                db.SaveChanges();
                VerileriCek();
            }
        }

        private void dgvTelefonlar_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
