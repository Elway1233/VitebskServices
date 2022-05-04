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
        private void Hair_Click(object sender, EventArgs e)
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
            numb = 1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (numb == 1)
            {
                id = id + 1;
                string name = textBox1.Text;
                string addres = textBox2.Text;
                string telephone = textBox3.Text;
                string time = textBox4.Text;
                string site = textBox5.Text;
                string lati = textBox6.Text;
                string longti = textBox7.Text;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`, `latitude`, `longtitude`) VALUES (000000000{0}, 'Парикмахерская', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site, lati, longti);
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
                textBox6.Clear();
                textBox7.Clear();
            }
            if (numb == 2)
            {
                id = id + 1;
                string name = textBox1.Text;
                string addres = textBox2.Text;
                string telephone = textBox3.Text;
                string time = textBox4.Text;
                string site = textBox5.Text;
                string lati = textBox6.Text;
                string longti = textBox7.Text;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`, `latitude`, `longtitude`) VALUES (000000000{0}, 'Продукты', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site, lati, longti);
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
                textBox6.Clear();
                textBox7.Clear();
            }
            if (numb == 3)
            {
                id = id + 1;
                string name = textBox1.Text;
                string addres = textBox2.Text;
                string telephone = textBox3.Text;
                string time = textBox4.Text;
                string site = textBox5.Text;
                string lati = textBox6.Text;
                string longti = textBox7.Text;
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("INSERT INTO `side` (`ID`, `Service`, `Name`, `Address`, `Telephone`, `WorkTime`, `WebSite`, `latitude`, `longtitude`) VALUES (000000000{0}, 'Развлечения', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})", id, name, addres, telephone, time, site, lati, longti);
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
                textBox6.Clear();
                textBox7.Clear();
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
    }
}
