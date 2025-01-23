﻿using FinancalCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinancalCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancalCmrDBEntities db = new FinancalCmrDBEntities();
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //BankaBakiyeleri
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifbankBalance = db.Banks.Where(x => x.BankTitle == "Vakıfbankası").Select(y => y.BankBalance).FirstOrDefault();
            var isbankasiBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() +" ₺";
            lblVakifbankBalance.Text = vakifbankBalance.ToString() + " ₺";
            lblIsbankasiBalance.Text = isbankasiBalance.ToString() + " ₺";

            //BankaHareketleri
            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

    }
}
