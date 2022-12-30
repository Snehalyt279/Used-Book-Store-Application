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
    public partial class Users : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ADMIN-PC\\SQLSERVER;Initial Catalog=Stock;Integrated Security=True");
        public Users()
        {
            InitializeComponent();
            show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.gmail.com");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String id = textBox1.Text.ToString();
                int iid = Int32.Parse(id);
                String name = textBox2.Text.ToString();
                String email = textBox3.Text.ToString();
                String phone = textBox4.Text.ToString();
                long iphone = long.Parse(phone);
                String transac = textBox5.Text.ToString();
                int itransac = Int32.Parse(transac);
                String donate = textBox6.Text.ToString();
                int idonate = Int32.Parse(donate);

                String qry = "insert into Users1 values(" + iid + ",'" + name + "','" + email + "'," + iphone + "," + itransac + "," + idonate + ")";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "User added successfully : " + name);
                }
                else
                {
                    MessageBox.Show("User not added ! ");
                }

                con.Close();

                show();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Users1", con);

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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String id = textBox1.Text.ToString();
                int iid = Int32.Parse(id);
                String name = textBox2.Text.ToString();
                String email = textBox3.Text.ToString();
                String phone = textBox4.Text.ToString();
                long iphone = long.Parse(phone);
                String transac = textBox5.Text.ToString();
                int itransac = Int32.Parse(transac);
                String donate = textBox6.Text.ToString();
                int idonate = Int32.Parse(donate);

                String qry = "update Users1 set  Name='" + name + "', EMail='" + email + "', PhoneNo=" + iphone + ", Transactions=" + itransac + ", Donations=" + idonate + " where ID=" + iid + "";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "User updated successfully : " + name);
                }
                else
                {
                    MessageBox.Show("User updation failed ! ");
                }

                con.Close();


                show();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show("Error is " + exp.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String id = textBox1.Text.ToString();
                int iid = Int32.Parse(id);
                String name = textBox2.Text.ToString();

                String qry = "delete from Users1 where ID=" + iid + "";
                SqlCommand sc = new SqlCommand(qry, con);
                int i = sc.ExecuteNonQuery();
                if (i >= 1)
                {
                    MessageBox.Show(i + "User deleted successfully : " + name);
                }
                else
                {
                    MessageBox.Show("User deletion failed ! ");
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
            SqlDataAdapter sda = new SqlDataAdapter("select * from Users1 where Name like'%" + textBox7.Text.ToString() + "%'", con);

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

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    
}
