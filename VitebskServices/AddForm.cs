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
        string service;
        int id = 0;
        int k = 0;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name, addres, time, telephone, site;
            float lati, longti;
            service = comboBox1.SelectedItem.ToString();
            id = id + 1;
            name = textBox1.Text;
            addres = textBox2.Text;
            telephone = textBox3.Text;
            time = textBox4.Text;
            site = textBox5.Text;
            lati = 0;
            longti = 0;
            k = 0;
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand1 = ThisConnection.CreateCommand();
            thisCommand1.CommandText = String.Format("SELECT Name, Address FROM `side` IF Name = '{0}' AND Address = '{2}' ", name, addres);
            MySqlDataReader thisReader1 = thisCommand1.ExecuteReader();
            List<string> listN = new List<string>();
            List<string> listA = new List<string>();
            while (thisReader1.Read())
            {
                listN.Add(("") + thisReader1["Name"]);
                listA.Add(("") + thisReader1["Address"]);
            }
            for (var i = 0; i < listN.Count; i++)
            {
                if (name == listN[i] && addres == listA[i])
                {
                    MessageBox.Show("Такое место уже существует");
                    thisReader1.Close();
                    k = 1;

                }
            }
            if (k != 1)
            {
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`,`Latitude`,`Longtitude`) VALUES (000000000{0}, '{8}', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site, lati, longti, service);
                if ((name == string.Empty) || (addres == string.Empty))
                {
                    MessageBox.Show("Заполните все необходимые поля *");
                    textBox1.ForeColor = Color.Red;
                    textBox2.ForeColor = Color.Red;
                    textBox3.ForeColor = Color.Red;
                }
                else
                {
                    MySqlDataReader thisReader = thisCommand.ExecuteReader();
                    thisReader.Close();
                    ThisConnection.Close();
                    MessageBox.Show("Успешно добавлено");
                    Close();
                }
            }
            else
            {
                ThisConnection.Close();
            }
        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Название: Мальвина\n" + "Адресс: улица Правды 39 корп 1, Витебск 210029\n" + "Номер телефона: 80297717222\n" + "График работы: пн-сб 09:00–20:00; вс 10:00–18:00\n" + "Сайт: malvina.by\n" + "Долгота: 55.172962188720700\n" + "Широта: 55.172962188720700");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox1.Text;
            if (c.Length >= 1 && c.Length < 25)
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
                errorProvider1.SetError(textBox1, "Допустимый диапазон 25 символов");
            }
            if (textBox1.Text == string.Empty)
            {
                textBox1.ForeColor = Color.Red;
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Поле не может быть пустым");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox2.Text;
            if (c.Length >= 1 && c.Length < 50)
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
                errorProvider2.SetError(textBox2, "Недопустимый диапазон");
            }
            if (textBox2.Text == string.Empty)
            {
                textBox2.ForeColor = Color.Red;
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Поле не может быть пустым");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            service = comboBox1.SelectedItem.ToString();
            if (service != null)
            {
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT DISTINCT `Service` FROM side";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            List<string> list = new List<string>();
            while (thisReader.Read())
            {
                list.Add(("") + thisReader["Service"]);
            }
            for (var i = 0; i < list.Count; i++)
                comboBox1.Items.Add(list[i]);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox3.Text;
            if (c.Length >= 1 && c.Length < 12)
            {
                e.Cancel = false;
                textBox3.ForeColor = Color.Black;
                errorProvider2.SetError(textBox3, "");

            }
            else
            {
                e.Cancel = true;
                textBox3.ForeColor = Color.Red;
                textBox3.Focus();
                errorProvider2.SetError(textBox3, "Неккоректное значение");
            }
            if (textBox3.Text == string.Empty)
            {
                textBox3.ForeColor = Color.Red;
                e.Cancel = true;
                textBox3.Focus();
                errorProvider2.SetError(textBox3, "Поле не может быть пустым");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }


    }
}
