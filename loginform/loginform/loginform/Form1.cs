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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\MycollegeDoc\loginform\loginform\Data.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from data1 where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                main ss = new main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Valid Username ! and Password !", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            sign ss = new sign();
            ss.ShowDialog();
            

        }

    }
}
