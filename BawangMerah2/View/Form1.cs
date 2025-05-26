using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BawangMerah2.Controller;
using BawangMerah2.Model;

namespace BawangMerah2
{
    public partial class Form1 : Form
    {
        private TransaksiController transaksiController = new TransaksiController();
        private int id = -1;

        public Form1()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            TampilkanData();
            ResetForm();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                var transaksi = new Transaksi
                {
                    NamaPembeli = textBox1.Text,
                    Jenis = textBox2.Text,
                    HargaJual = Convert.ToDecimal(textBox3.Text),
                    Satuan = textBox4.Text,
                    TotalHarga = Convert.ToDecimal(textBox5.Text)
                };

                transaksiController.Tambah(transaksi);
                MessageBox.Show("Data berhasil disimpan.");
                ResetForm();
                TampilkanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var transaksi = new Transaksi
                {
                    Id = this.id,
                    NamaPembeli = textBox1.Text,
                    Jenis = textBox2.Text,
                    HargaJual = Convert.ToDecimal(textBox3.Text),
                    Satuan = textBox4.Text,
                    TotalHarga = Convert.ToDecimal(textBox5.Text)
                };

                transaksiController.Update(transaksi);
                MessageBox.Show("Data berhasil diperbarui.");
                ResetForm();
                TampilkanData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes && id != -1)
                {
                    transaksiController.Hapus(id);
                    MessageBox.Show("Data berhasil dihapus.");
                    ResetForm();
                    TampilkanData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        

        private void ResetForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            id = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void TampilkanData()
        {
            dataGridView1.DataSource = transaksiController.GetAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells["ID"].Value);
                textBox1.Text = row.Cells["NamaPembeli"].Value.ToString();
                textBox2.Text = row.Cells["Jenis"].Value.ToString();
                textBox3.Text = row.Cells["HargaJual"].Value.ToString();
                textBox4.Text = row.Cells["Satuan"].Value.ToString();
                textBox5.Text = row.Cells["TotalHarga"].Value.ToString();
            }
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBoxCari.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    dataGridView1.DataSource = transaksiController.Cari(keyword);
                }
                else
                {
                    TampilkanData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencari: " + ex.Message);
            }
        }
    }
}
