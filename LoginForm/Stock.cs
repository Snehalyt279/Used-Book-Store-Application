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
    public partial class Stock : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ADMIN-PC\\SQLSERVER;Initial Catalog=Stock;Integrated Security=True");
        public Stock()
        {
            InitializeComponent();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String id = textBox1.Text.ToString();
                int iid = Int32.Parse(id);
                String bname = textBox2.Text.ToString();
                String auth = textBox3.Text.ToString();
                String pub = textBox4.Text.ToString();
                String price = textBox5.Text.ToString();
                int iprice = Int32.Parse(price);
                String descr = textBox6.Text.ToString();

                String qry = "insert into Stock values(" + iid + ",'" + bname + "','" + auth + "','" + pub + "'," + iprice + ",'" + descr + "')" ;
                SqlCommand sc = new SqlCommand(qry,con);
                int i = sc.ExecuteNonQuery();
                if (i>=1)
                {
                    MessageBox.Show(i + "Book added successfully : " + bname);
                }
                else
                {
                    MessageBox.Show("Book not added ! ");
                }

                con.Close();

                show();
                
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is "+exp.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String id = textBox1.Text.ToString();
                int iid = Int32.Parse(id);
                String bname = textBox2.Text.ToString();
                String auth = textBox3.Text.ToString();
                String pub = textBox4.Text.ToString();
                String price = textBox5.Text.ToString();
                int iprice = Int32.Parse(price);
                String descr = textBox6.Text.ToString();

                String qry = "update Stock set  Bname='" + bname + "', Auth='" + auth + "', Pub='" + pub + "', Price=" + iprice + ", Descr='" + descr + "' where ID=" + iid + "";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Book updated successfully : " + bname);
                }
                else
                {
                    MessageBox.Show("Book updation failed ! ");
                }

                con.Close();


                show();
                
            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }

        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Stock",con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String id = textBox1.Text.ToString();
                int iid = Int32.Parse(id);
                String bname = textBox2.Text.ToString();

                String qry = "delete from Stock where ID=" + iid + "";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "Book deleted successfully : " + bname);
                }
                else
                {
                    MessageBox.Show("Book deletion failed ! ");
                }

                con.Close();

                show();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Stock where Bname like'%"+textBox7.Text.ToString()+"%'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();

               
                
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Stock_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
