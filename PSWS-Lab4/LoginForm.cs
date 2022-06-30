using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Login_And_Register
{
    public partial class LoginForm : Form
    {  
        public LoginForm()
        {
            InitializeComponent();

            this.textBoxPassword.AutoSize = false;
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Size.Width, 50);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @username and `password` = @password", db.getConn());

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();

                if(table.Rows[0][6].ToString() == "user")
                {
                    MainFormUser mainform = new MainFormUser(username);
                    mainform.Show();
                }
                else if(table.Rows[0][6].ToString() == "admin")
                {
                    MainFormAdmin form1 = new MainFormAdmin();
                    form1.Show();
                }

            }
            else
            {
                if(username.Trim().Equals(""))
                {
                    MessageBox.Show("Wpisz login","Błędny login",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Wpisz hasło", "Błędne hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Zły login albo hasło", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerform = new RegisterForm();
            registerform.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }   
        }
        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
