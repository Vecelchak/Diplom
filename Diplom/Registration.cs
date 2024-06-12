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
using Diplom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplom
{
    public partial class Registration : Form
    {
        db database = new db();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private Boolean checkuser()
        {
            var loginuser22 = textBox1.Text;
            var passuser22 = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginuser22}' and password_user = '{passuser22}'";
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Аккаунт уже существует!");
                return true;
            }
            else
                return false;
        }

        private void butlog_Click(object sender, EventArgs e)
        {
            Login frm_logn = new Login();
            frm_logn.Show();
            this.Hide();
        }

        private void sign_up_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            var LoginUser2 = textBox1.Text;
            var LoginPassword2 = textBox2.Text;

            string querystring = $"insert into register(login_user, password_user) values('{LoginUser2}', '{LoginPassword2}')";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            database.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегались!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login frm_login = new Login();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
                MessageBox.Show("Аккаунт не создан!");
        }
    }
}