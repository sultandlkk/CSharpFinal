using FinancalCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancalCrm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }
        FinancalCmrDBEntities db = new FinancalCmrDBEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            

            // Sabit kullanıcı adı ve şifre kontrolü
            if (username == "admin" && password == "1234")
            {
                // Giriş başarılı, Dashboard formunu açıyoruz
                FrmDashboard frm = new FrmDashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                // Giriş başarısız, aynı sayfada kalıyoruz
                MessageBox.Show("Geçersiz şifre yada kullanıcı adı girdiniz!");
            }

        }
    }
}
