using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VitebskServices
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        int numb = 0;
        int id = 0;
        int click = 1;
        private void Hair_Click(object sender, EventArgs e)
        {
            if (click % 2 == 1)
            {
                Hair.Checked = false;
            }
            else
            {
                Hair.Checked = true;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT id FROM side ORDER BY id DESC LIMIT 1";
                MySqlDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    id = Convert.ToInt16(thisReader["id"]);
                }
                thisReader.Close();
                ThisConnection.Close();
                numb = 1;
            }
            click = click + 1;           
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name, addres, time, telephone, site;
            if (numb == 1)
            {
                id = id + 1;
                name = textBox1.Text;
                addres = textBox2.Text;
                telephone = textBox3.Text;
                time = textBox4.Text;
                site = textBox5.Text;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`) VALUES (000000000{0}, 'Парикмахерская', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site);
                if ((name == string.Empty) || (addres == string.Empty))
                {
                    MessageBox.Show("Заполните все необходимые поля *");
                }
                else
                {
                    MySqlDataReader thisReader = thisCommand.ExecuteReader();
                    thisReader.Close();
                    ThisConnection.Close();
                    MessageBox.Show("Успешно добавлено");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
            }
            if (numb == 2)
            {
                id = id + 1;
                name = textBox1.Text;
                addres = textBox2.Text;
                telephone = textBox3.Text;
                time = textBox4.Text;
                site = textBox5.Text;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`) VALUES (000000000{0}, 'Продукты', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site);
                if ((name == string.Empty) || (addres == string.Empty))
                {
                    MessageBox.Show("Заполните все необходимые поля *");
                }
                else
                {
                    MySqlDataReader thisReader = thisCommand.ExecuteReader();
                    thisReader.Close();
                    ThisConnection.Close();
                    MessageBox.Show("Успешно добавлено");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            if (numb == 3)
            {
                id = id + 1;
                name = textBox1.Text;
                addres = textBox2.Text;
                telephone = textBox3.Text;
                time = textBox4.Text;
                site = textBox5.Text;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`) VALUES (000000000{0}, 'Развлечения', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site);
                if ((name == string.Empty) || (addres == string.Empty))
                {
                    MessageBox.Show("Заполните все необходимые поля *");
                }
                else
                {
                    MySqlDataReader thisReader = thisCommand.ExecuteReader();
                    thisReader.Close();
                    ThisConnection.Close();
                    MessageBox.Show("Успешно добавлено");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT id FROM side ORDER BY id DESC LIMIT 1";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                id = Convert.ToInt16(thisReader["id"]);
            }
            thisReader.Close();
            ThisConnection.Close();
            numb = 2;
        }

        private void Entartainment_Click(object sender, EventArgs e)
        {
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT id FROM side ORDER BY id DESC LIMIT 1";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                id = Convert.ToInt16(thisReader["id"]);
            }
            thisReader.Close();
            ThisConnection.Close();
            numb = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Название: Мальвина\n" + "Адресс: улица Правды 39 корп 1, Витебск 210029\n" + "Номер телефона: 80297717222\n" + "График работы: пн-сб 09:00–20:00; вс 10:00–18:00\n" + "Сайт: malvina.by\n" + "Долгота: 55.172962188720700\n" + "Широта: 55.172962188720700");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox1.Text;
            if (!Regex.Match(c, @"[a-zA-Z]|,|\.|@|[0-9]").Success && c.Length > 0 && c.Length < 50)
            {
                e.Cancel = false;
                textBox1.ForeColor = Color.Black;
                errorProvider1.SetError(textBox1, "");
            }
            else
            {
                textBox1.ForeColor = Color.Red;
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Используйте кириллицу!");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox2.Text;
            if (!Regex.Match(c, @"[a-zA-Z]|,|\.|@").Success && c.Length > 0 && c.Length < 50)
            {
                e.Cancel = false;
                textBox2.ForeColor = Color.Black;
                errorProvider2.SetError(textBox2, "");
            }
            else
            {
                e.Cancel = true;
                textBox2.ForeColor = Color.Red;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Используйте кириллицу!");
            }
        }
    }
}
