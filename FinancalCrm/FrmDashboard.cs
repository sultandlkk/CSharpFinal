﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinancalCrm.Models;

namespace FinancalCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        FinancalCmrDBEntities db = new FinancalCmrDBEntities();
        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString()+" ₺";

            var lastBankProcessAmount = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmout.Text = lastBankProcessAmount.ToString() + " ₺";
            //chark1 kodları
            var bankdata = db.Banks.Select(x =>new 
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankdata)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }
            //chart2 kodları
            var billData = db.Bills.Select(x =>new

            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Renko;
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
           if (count % 4==1)
            {
                var elektrikFaturasi = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = elektrikFaturasi.ToString()+" ₺";

            }
            if (count % 4 == 2)
            {
                var dogalgazFaturasi = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = dogalgazFaturasi.ToString() + " ₺";

            }
            if (count % 4 == 3)
            {
                var suFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = suFaturasi.ToString() + " ₺";

            }
            if (count % 4 == 0)
            {
                var internetFaturasi = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = internetFaturasi.ToString() + " ₺";

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCategories frm = new FrmCategories();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }
    }
}
