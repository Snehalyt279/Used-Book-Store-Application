using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LoginForm
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            timerTime.Start();
            
        }

       
        private void button9_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Stock st = new Stock();
            st.Show();
            moveSidePanel(btnStock);
        }

        private void btnWishList_Click(object sender, EventArgs e)
        {
            Requests rs = new Requests();
            rs.Show();
            moveSidePanel(btnWishList);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users us = new Users();
            us.Show();
            moveSidePanel(btnUsers);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Donate dn = new Donate();
            dn.Show();
            moveSidePanel(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Sales sa = new Sales();
            sa.Show();
            moveSidePanel(button7);
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void panel11_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
 
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Stats ss = new Stats();
            ss.Show();
            moveSidePanel(button8);
        }
    }
}
