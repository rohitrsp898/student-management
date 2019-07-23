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

namespace loginform
{
    public partial class sign : Form
    {
        public sign()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\MycollegeDoc\loginform\loginform\Data.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from data1 where username ='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(int.Parse(dt.Rows[0][0].ToString())==0)
            {
                label4.Text = textBox1.Text + " is Available";
                this.label4.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label4.Text = textBox1.Text + " is Not Available";
                this.label4.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\MycollegeDoc\loginform\loginform\Data.mdf;Integrated Security=True");
            con.Open();
            if (label4.ForeColor == System.Drawing.Color.Green)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlCommand cmd = new SqlCommand("Insert into data1(username,password) Values('" + textBox1.Text + "','" + textBox3.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Signup!","New Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Your Password is Missmatched !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
              
            }
            else
            {
                MessageBox.Show("This Username is Already Exist !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            
        }
    }
}
