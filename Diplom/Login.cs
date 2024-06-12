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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Diplom;

namespace Diplom
{
    public partial class Login : Form
    {

        db database = new db();

        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '•';
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var LoginUser = textBox1.Text;
            var LoginPassword = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{LoginUser}' and password_user = '{LoginPassword}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();
                this.Show();

            }
            else
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration frm_sign = new Registration();
            frm_sign.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}