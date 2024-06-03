using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // SQL Server local DB

namespace ModelisationBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_List();
        }
        private void load_List()
        {
            string cn_string = Properties.Settings.Default.DatabaseConnectionString;
            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();
            string sql_Text = "SELECT * FROM Table";
            DataTable tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);

            listData.DisplayMember = "Car";
            listData.ValueMember = "IdCar";
            listData.DataSource = tbl;
        }

    }
}
