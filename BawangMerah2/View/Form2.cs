using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BawangMerah2.Controller;
using BawangMerah2.Model;

namespace BawangMerah2
{
    public partial class Form2 : Form
    {
        private UserController userController = new UserController();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();

            User user = new User
            {
                Username = username,
                Password = password
            };

            if (userController.Login(user))
            {
                MessageBox.Show("Login Berhasil");
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }
    }
}
