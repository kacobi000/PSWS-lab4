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
    
    public partial class MainFormUser : Form
    {
        DataSet ds = new DataSet();
        String userName;
        public MainFormUser(String user)
        {
            userName = user;
            InitializeComponent();

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `events`", db.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(ds);

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = ds.Tables[0].Columns[1].ToString();
            label5.Text = ds.Tables[0].Rows[0][2].ToString();
            DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0][3].ToString());
            label6.Text = date.ToShortDateString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < ds.Tables[0].Rows.Count;i++)
            {
                if (comboBox1.Text == ds.Tables[0].Rows[i][1].ToString())
                {
                    label5.Text = ds.Tables[0].Rows[i][2].ToString();
                    DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[i][3].ToString());
                    label6.Text = date.ToShortDateString();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `participants`(`eventname`, `participationtype`, `food`, `user`) VALUES (@en, @pt, @food, @user)", db.getConn());

            if(comboBox4.Text == "")
            {
                MessageBox.Show("Nie wybrano typu uczestnictwa", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Nie wybrano jedzenia", "Błędne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                command.Parameters.Add("@eventname", MySqlDbType.VarChar).Value = comboBox1.Text;
                command.Parameters.Add("@participationtype", MySqlDbType.VarChar).Value = comboBox4.Text;
                command.Parameters.Add("@food", MySqlDbType.VarChar).Value = comboBox2.Text;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = userName;
            }

            db.openConn();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Zapisałeś się pomyślnie", "Zapis poprawny", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Błąd!!!");
            }

            db.closeConn();
        }
    }
}
