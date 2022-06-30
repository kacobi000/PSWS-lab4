using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Csharp_Login_And_Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `emailaddress`, `username`, `password`, `permission`) VALUES (@fn, @ln, @email, @usn, @pass, @per)", db.getConn());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstname.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastname.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            command.Parameters.Add("@per", MySqlDbType.VarChar).Value = "user";

            db.openConn();

            if (!checkTextBoxesValues())
            {
                if(textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                {
                    if (checkUsername())
                    {
                        MessageBox.Show("Taki użytkownik już istnieje","Błędny login",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Twoje konto zostało stworzone","Stworzono konto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Błąd!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hasło źle powtórzone","Błędne hasło",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Najpierw wpisz dane","Brak danych",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }

            db.closeConn();

        }

        public Boolean checkUsername()
        {
            String username = textBoxUsername.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @username", db.getConn());

            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean checkTextBoxesValues()
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String email = textBoxEmail.Text;
            String uname = textBoxUsername.Text;
            String pass = textBoxPassword.Text;

            if(fname.Equals("Imie") || lname.Equals("Nazwisko") || 
                email.Equals("Adres email") || uname.Equals("Login")|| pass.Equals("Hasło"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void labelGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }
    }
}
