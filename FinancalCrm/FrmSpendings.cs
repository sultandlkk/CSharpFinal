using FinancalCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancalCrm
{
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }
        FinancalCmrDBEntities db = new FinancalCmrDBEntities();

        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var values = (from s in db.Spendings
                          join c in db.Categories on s.CategoryId equals c.CategoryId
                          select new
                          {
                              s.SpendingId,
                              s.SpendingTitle,
                              s.SpendingAmount,
                              s.SpendingDate,
                              CategoryName = c.CategoryName // Kategori adını doğrudan al
                          }).ToList();
            dataGridView1.DataSource = values;



            var mostSpentCategory = (from s in db.Spendings
                                     join c in db.Categories on s.CategoryId equals c.CategoryId
                                     group s by new { s.CategoryId, c.CategoryName } into g
                                     orderby g.Sum(x => x.SpendingAmount) descending
                                     select new
                                     {
                                         CategoryName = g.Key.CategoryName,
                                         TotalAmount = g.Sum(x => x.SpendingAmount)
                                     }).FirstOrDefault();
                lblMostCategory.Text = $"{mostSpentCategory.CategoryName}\n{mostSpentCategory.TotalAmount:C}";

           
            
            
            
            var lastSpendingDate = (from s in db.Spendings
                        orderby s.SpendingDate descending
                        select s.SpendingDate).FirstOrDefault();

            lblMostDate.Text = lastSpendingDate.HasValue ? lastSpendingDate.Value.ToString("yyyy-MM-dd") : "No data available";

           
         


             var totalSpending = (from s in db.Spendings
                                 select s.SpendingAmount).Sum();

            lblSumSpending.Text = totalSpending.ToString();



            var billData = db.Spendings.Select(x => new

            {
                x.SpendingTitle,
                x.SpendingAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("HARCAMALAR");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.SpendingTitle, item.SpendingAmount);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }


    }
}
