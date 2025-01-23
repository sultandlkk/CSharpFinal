using FinancalCrm.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FinancalCrm
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        FinancalCmrDBEntities db = new FinancalCmrDBEntities();

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            var values = db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();
            dataGridView2.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtCategoryName.Text;


            Categories categories = new Categories();
            categories.CategoryName = title;
            db.Categories.Add(categories);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Kategoriler", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var values = db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();
            dataGridView2.DataSource = values;
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı Bir Şekilde Gerçekleşti.", "Kategoriler", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var values = db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();
            dataGridView2.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string title = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);
            var values = db.Categories.Find(id);


            values.CategoryName = title;

            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı Bir Şekilde Güncellendi.", "Kategoriler", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            var values2 = db.Categories.Select(x => new { x.CategoryId, x.CategoryName }).ToList();
            dataGridView2.DataSource = values2;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }


    }
    }

