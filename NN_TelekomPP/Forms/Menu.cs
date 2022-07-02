using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NN_TelekomPP.Forms
{
    public partial class Menu : Form // меню 
    {
       
        public Menu()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculetionForm CF = new CalculetionForm();
            CF.ShowDialog();
        }

        private void Internet_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            InternetForm IF = new InternetForm();
            IF.ShowDialog();
        }
        public void global_FormClosed(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void Number_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Number N = new Number();
            N.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Organizations OR  = new Organizations();
            OR.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SADD OR = new SADD();
            OR.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubscriptionFee OR = new SubscriptionFee();
            OR.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Services_customers OR = new Services_customers();
            OR.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ADD_customers OR = new ADD_customers();
            OR.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
