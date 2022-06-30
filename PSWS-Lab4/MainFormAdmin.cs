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
    public partial class MainFormAdmin : Form
    {
        DataSet ds = new DataSet();
        TextBox txtBox1;
        TextBox txtBox2;
        TextBox txtBox3;
        TextBox txtBox4;
        TextBox txtBox5;
        TextBox txtBox6;
        TextBox txtBox7;
        TextBox txtBox8;
        TextBox txtBox9;
        TextBox txtBox10;
        TextBox txtBox11;
        TextBox txtBox12;
        TextBox txtBox13;
        TextBox txtBox14;
        TextBox txtBox15;
        public MainFormAdmin()
        {
            InitializeComponent();
        }

        private void dodawanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            txtBox1 = new TextBox();
            txtBox1.MinimumSize = new Size(250, 30);
            txtBox1.Margin = new Padding(10, 10, 10, 10);
            txtBox1.Text = "Imie";
            txtBox2 = new TextBox();
            txtBox2.MinimumSize = new Size(250, 30);
            txtBox2.Margin = new Padding(10, 10, 10, 10);
            txtBox2.Text = "Nazwisko";
            txtBox3 = new TextBox();
            txtBox3.MinimumSize = new Size(250, 30);
            txtBox3.Margin = new Padding(10, 10, 10, 10);
            txtBox3.Text = "Email";
            txtBox4 = new TextBox();
            txtBox4.MinimumSize = new Size(250, 30);
            txtBox4.Margin = new Padding(10, 10, 10, 10);
            txtBox4.Text = "Login";
            txtBox5 = new TextBox();
            txtBox5.MinimumSize = new Size(250, 30);
            txtBox5.Margin = new Padding(10, 10, 10, 10);
            txtBox5.Text = "Hasło";
            TextBox txtBox6 = new TextBox();
            txtBox6.MinimumSize = new Size(250, 30);
            txtBox6.Margin = new Padding(10, 10, 10, 10);
            txtBox6.Text = "Powtórz hasło";
            Button add = new Button();
            add.MinimumSize = new Size(250, 30);
            add.Margin = new Padding(10, 10, 10, 10);
            add.Text = "Dodaj";

            tableLayoutPanel1.Controls.Add(txtBox1);
            tableLayoutPanel1.Controls.Add(txtBox2);
            tableLayoutPanel1.Controls.Add(txtBox3);
            tableLayoutPanel1.Controls.Add(txtBox4);
            tableLayoutPanel1.Controls.Add(txtBox5);
            tableLayoutPanel1.Controls.Add(txtBox6);
            tableLayoutPanel1.Controls.Add(add);

            add.Click += handleEventAdd;
        }

        void handleEventAdd(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `emailaddress`, `username`, `password`, `permission`) VALUES (@firstname, @lastname, @email, @usnername, @password, @perrmition)", db.getConn());

            command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = txtBox1.Text;
            command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = txtBox2.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtBox3.Text;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtBox4.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtBox5.Text;
            command.Parameters.Add("@perrmiton", MySqlDbType.VarChar).Value = "user";

            db.openConn();
            command.ExecuteNonQuery();
            MessageBox.Show("Dodano pomyślnie");
            db.closeConn();
        }

        private void usuwanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            txtBox6 = new TextBox();
            txtBox6.MinimumSize = new Size(250, 30);
            txtBox6.Margin = new Padding(10, 10, 10, 10);
            txtBox6.Text = "Wpisz login konta do usunięcia";

            Button del = new Button();
            del.MinimumSize = new Size(250, 30);
            del.Margin = new Padding(10, 10, 10, 10);
            del.Text = "Usuń";

            tableLayoutPanel1.Controls.Add(txtBox6);
            tableLayoutPanel1.Controls.Add(del);

            del.Click += handleEventDelete;
        }

        void handleEventDelete(object sender, EventArgs e)
        {
            String username = txtBox6.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `username` = @username", db.getConn());
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();

            if (username.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz login", "Błędny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (username.Trim().Equals("Wpisz login konta do usunięcia"))
            {
                MessageBox.Show("Wpisz login", "Błędny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.ExecuteNonQuery();
            MessageBox.Show("Usunięto pomyślnie");
            db.closeConn();

        }
    

        private void resetHasłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            txtBox7 = new TextBox();
            txtBox7.MinimumSize = new Size(250, 30);
            txtBox7.Margin = new Padding(10, 10, 10, 10);
            txtBox7.Text = "Wpisz login konta do resetu";
            txtBox8 = new TextBox();
            txtBox8.MinimumSize = new Size(250, 30);
            txtBox8.Margin = new Padding(10, 10, 10, 10);
            txtBox8.Text = "Wpisz nowe hasło";

            Button reset = new Button();
            reset.MinimumSize = new Size(250, 30);
            reset.Margin = new Padding(10, 10, 10, 10);
            reset.Text = "Resetuj";

            tableLayoutPanel1.Controls.Add(txtBox7);
            tableLayoutPanel1.Controls.Add(txtBox8);
            tableLayoutPanel1.Controls.Add(reset);

            reset.Click += handleEventReset;
        }

        void handleEventReset(object sender, EventArgs e)
        {
            String username = txtBox7.Text;
            String newPassword = txtBox8.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `password` = @pass WHERE `username` = @usn; ", db.getConn());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = newPassword;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();

            if (username.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz login", "Błędny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (username.Trim().Equals("Wpisz login konta do resetu"))
            {
                MessageBox.Show("Wpisz login", "Błędny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newPassword.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz hasło", "Błędne hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newPassword.Trim().Equals("Wpisz nowe hasło"))
            {
                MessageBox.Show("Wpisz hasło", "Błędne hasło", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.ExecuteNonQuery();
            MessageBox.Show("Zresetowano pomyślnie");
            db.closeConn();
        }

        private void dodawanieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            txtBox9 = new TextBox();
            txtBox9.MinimumSize = new Size(250, 30);
            txtBox9.Margin = new Padding(10, 10, 10, 10);
            txtBox9.Text = "Wpisz nazwę Wydarzenia";
            txtBox10 = new TextBox();
            txtBox10.MinimumSize = new Size(250, 30);
            txtBox10.Margin = new Padding(10, 10, 10, 10);
            txtBox10.Text = "Wpisz Agende Wydarzenia";
            txtBox11 = new TextBox();
            txtBox11.MinimumSize = new Size(250, 30);
            txtBox11.Margin = new Padding(10, 10, 10, 10);
            txtBox11.Text = "Wpisz datę wydarzenia";

            Button addEvent = new Button();
            addEvent.MinimumSize = new Size(250, 30);
            addEvent.Margin = new Padding(10, 10, 10, 10);
            addEvent.Text = "Dodaj wydarzenie";

            tableLayoutPanel1.Controls.Add(txtBox9);
            tableLayoutPanel1.Controls.Add(txtBox10);
            tableLayoutPanel1.Controls.Add(txtBox11);
            tableLayoutPanel1.Controls.Add(bnt);

            bnt.Click += handleEventAddEvent;
        }

        void handleEventAddEvent(object sender, EventArgs e)
        {
            String eventname = txtBox9.Text;
            String eventagenda = txtBox10.Text;
            String eventdate = txtBox11.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `events`(`eventname`, `eventagenda`, `date`) VALUES (@en, @ea, @date)", db.getConn());
            command.Parameters.Add("@en", MySqlDbType.VarChar).Value = eventname;
            command.Parameters.Add("@ea", MySqlDbType.VarChar).Value = eventagenda;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = eventdate;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();

            if (eventname.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz nazwę", "Błędna nazwa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (eventname.Trim().Equals("Wpisz nazwę Wydarzenia"))
            {
                MessageBox.Show("Wpisz nazwę", "Błędna nazwa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (eventagenda.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz termin", "Błędny termin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (eventagenda.Trim().Equals("Wpisz Agende Wydarzenia"))
            {
                MessageBox.Show("Wpisz termin", "Błędny termin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (eventdate.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz date", "Błędna data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (eventdate.Trim().Equals("Wpisz datę wydarzenia"))
            {
                MessageBox.Show("Wpisz date", "Błędna data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.ExecuteNonQuery();
            MessageBox.Show("Dodano pomyślnie");
            db.closeConn();
        }
        private void usuwanieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            txtBox12 = new TextBox();
            txtBox12.MinimumSize = new Size(250, 30);
            txtBox12.Margin = new Padding(10, 10, 10, 10);
            txtBox12.Text = "Wpisz nazwę Wydarzenia";


            Button bnt = new Button();
            bnt.MinimumSize = new Size(250, 30);
            bnt.Margin = new Padding(10, 10, 10, 10);
            bnt.Text = "Usuń wydarzenie";

            tableLayoutPanel1.Controls.Add(txtBox12);
            tableLayoutPanel1.Controls.Add(bnt);

            bnt.Click += handleEventDeleteEvent;
        }

        void handleEventDeleteEvent(object sender, EventArgs e)
        {
            String username = txtBox12.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `events` WHERE `eventname` = @en", db.getConn());
            command.Parameters.Add("@en", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();

            if (username.Trim().Equals(""))
            {
                MessageBox.Show("Wpisz login", "Błędny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (username.Trim().Equals("Wpisz nazwę Wydarzenia"))
            {
                MessageBox.Show("Wpisz login", "Błędny login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.ExecuteNonQuery();
            MessageBox.Show("Usunięto pomyślnie");
            db.closeConn();
        }

        private void modyfikacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            txtBox13 = new TextBox();
            txtBox13.MinimumSize = new Size(250, 30);
            txtBox13.Margin = new Padding(10, 10, 10, 10);
            txtBox13.Text = "Wpisz nazwę Wydarzenia";
            txtBox14 = new TextBox();
            txtBox14.MinimumSize = new Size(250, 30);
            txtBox14.Margin = new Padding(10, 10, 10, 10);
            txtBox14.Text = "Wpisz nową agende Wydarzenia";
            txtBox15 = new TextBox();
            txtBox15.MinimumSize = new Size(250, 30);
            txtBox15.Margin = new Padding(10, 10, 10, 10);
            txtBox15.Text = "Wpisz nową datę Wydarzenia";
            Button bnt = new Button();
            bnt.MinimumSize = new Size(250, 30);
            bnt.Margin = new Padding(10, 10, 10, 10);
            bnt.Text = "Modyfikuj wydarzenie";

            tableLayoutPanel1.Controls.Add(txtBox13);
            tableLayoutPanel1.Controls.Add(txtBox14);
            tableLayoutPanel1.Controls.Add(txtBox15);
            tableLayoutPanel1.Controls.Add(bnt);

            bnt.Click += handleEventModifyEvent;
        }

        void handleEventModifyEvent(object sender, EventArgs e)
        {
            String eventname = txtBox13.Text;
            String neweventagenda = txtBox14.Text;
            String neweventdate = txtBox15.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `events` SET `eventagenda` = @eventagenda,`date` = @date WHERE `eventname` = @eventname; ", db.getConn());
            command.Parameters.Add("@eventagenda", MySqlDbType.VarChar).Value = neweventagenda;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = neweventdate;
            command.Parameters.Add("@eventname", MySqlDbType.VarChar).Value = eventname;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();

            if(checkEventname())
            {
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Takie wydarzenie nie istnieje");
                return;
            }

            MessageBox.Show("Zmodyfikowano pomyślnie");
            db.closeConn();
        }

        public Boolean checkEventname()
        {
            String eventname = txtBox13.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `events` WHERE `eventname` = @eventname", db.getConn());
            command.Parameters.Add("@eventname", MySqlDbType.VarChar).Value = eventname;
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
        private void obsługaZapisówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `participants` WHERE `status` = ''; ", db.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(ds);

            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                Label label = new Label();
                label.Text = ds.Tables[0].Rows[i][1].ToString();
                label.Font = new Font("Calibri", 8);
                Label label1 = new Label();
                label1.Text = ds.Tables[0].Rows[i][2].ToString();
                label1.Font = new Font("Calibri", 8);
                Label label2 = new Label();
                label2.Text = ds.Tables[0].Rows[i][3].ToString();
                label2.Font = new Font("Calibri", 8);
                Label label3 = new Label();
                label3.Text = ds.Tables[0].Rows[i][4].ToString();
                label3.Font = new Font("Calibri", 8);

                Button acc = new Button();
                acc.Text = "Zatwierdź";
                Button rej= new Button();
                rej.Text = "Odrzuć";

                acc.Name = i.ToString();
                rej.Name = i.ToString();

                tableLayoutPanel1.ColumnCount = 6;

                tableLayoutPanel1.Controls.Add(label);
                tableLayoutPanel1.Controls.Add(label1);
                tableLayoutPanel1.Controls.Add(label2);
                tableLayoutPanel1.Controls.Add(label3);
                tableLayoutPanel1.Controls.Add(bnt);
                tableLayoutPanel1.Controls.Add(bnt1);
                
                rej.Click += odrzuc;
                acc.Click += zatwierdz;
            }
        }

        void odrzuc(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int number = Int32.Parse(clicked.Name);
            String eventname = ds.Tables[0].Rows[number][1].ToString();
            String username = ds.Tables[0].Rows[number][4].ToString();

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `participants` SET `status` = 'odrzucony' WHERE `user` = @username and `eventname` = @eventname; ", db.getConn());
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@eventname", MySqlDbType.VarChar).Value = eventname;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();
            command.ExecuteNonQuery();
            MessageBox.Show("Odrzucono pomyślnie");
            db.closeConn();
        }

        void zatwierdz(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int number = Int32.Parse(clicked.Name);
            String eventname = ds.Tables[0].Rows[number][1].ToString();
            String username = ds.Tables[0].Rows[number][4].ToString();

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `participants` SET `status` = 'potwierdzony' WHERE `user` = @username and `eventname` = @eventname; ", db.getConn());
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@eventname", MySqlDbType.VarChar).Value = eventname;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.openConn();
            command.ExecuteNonQuery();
            MessageBox.Show("Zatwierdzono pomyślnie");
            db.closeConn();
        }
    }
}
