using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace loginform
{
    public partial class main : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\MycollegeDoc\loginform\loginform\rohit1.mdf;Integrated Security=True");
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\loginform\loginform\rohit.mdf;Integrated Security=True");
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Plesae fill all the  * marked area !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
              
                con.Open();
                SqlCommand cmd = new SqlCommand(@"Insert into rohit1(fname,lname,contact,email,address)   Values   ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Save Successfully !", "Done !");
                display();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
        void display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from rohit1",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["srno"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["fname"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["lname"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["contact"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["email"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["Address"].ToString();



            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            display();
        }

        private void main_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\loginform\loginform\rohit.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Delete from rohit1  where   (contact='" + textBox3.Text + "')", con);

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Data Delete Successfully !", "Done !");
            display();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\loginform\loginform\rohit.mdf;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from rohit1 where (fname like '%" + textBox6.Text + "%') or (lname like'%" + textBox6.Text + "%') or (contact like '%" + textBox6.Text + "%')",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["srno"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["fname"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["lname"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["contact"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["email"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["Address"].ToString();



            }

            con.Close();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          

            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
          
                Regex mRegxExpression;

                if (textBox4.Text.Trim() != string.Empty)
                {
                    mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                    if (!mRegxExpression.IsMatch(textBox4.Text.Trim()))
                    {
                        MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        textBox4.Focus();

                    }

                }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 10)
            {
                MessageBox.Show("Please Enter A Valid Phone No !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Desktop\loginform\loginform\rohit.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE rohit1   SET   fname='"+textBox1.Text+"',lname='"+textBox2.Text+"',contact='"+textBox3.Text+"',email='"+textBox4.Text+"',address='"+textBox5.Text+ "' WHERE (fname='" + textBox1.Text + "')", con);

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Data Updated Successfully !", "Done !");
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
