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
    public partial class Stats : Form
    {
       
        public Stats()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Stats_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stockDataSet1.Sales1' table. You can move, or remove it, as needed.
            this.sales1TableAdapter.Fill(this.stockDataSet1.Sales1);
            // TODO: This line of code loads data into the 'stockDataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.stockDataSet.Stock);
            // TODO: This line of code loads data into the 'database1DataSet.ProLos' table. You can move, or remove it, as needed.
            this.proLosTableAdapter.Fill(this.database1DataSet.ProLos);
            // TODO: This line of code loads data into the 'databaseDataSet.SoldCount' table. You can move, or remove it, as needed.
            this.soldCountTableAdapter.Fill(this.databaseDataSet.SoldCount);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                soldCountBindingSource.EndEdit();
                soldCountTableAdapter.Update(databaseDataSet.SoldCount);
                MessageBox.Show("Your data has been successfully saved. ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Sold"].XValueMember = "Sold";
            chart1.Series["Sold"].YValueMembers = "Purchased";
            chart1.DataSource = databaseDataSet.SoldCount;
            chart1.DataBind();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                proLosBindingSource.EndEdit();
                proLosTableAdapter.Update(database1DataSet.ProLos);
                MessageBox.Show("Your data has been successfully saved. ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chart2.Series["Profit"].XValueMember = "Profit";
            chart2.Series["Profit"].YValueMembers = "Profit";
            chart2.DataSource = database1DataSet.ProLos;
            chart2.DataBind();

            chart2.Series["Loss"].XValueMember = "Loss";
            chart2.Series["Loss"].YValueMembers = "Loss";
            chart2.DataSource = database1DataSet.ProLos;
            chart2.DataBind();
        }
    }
}
