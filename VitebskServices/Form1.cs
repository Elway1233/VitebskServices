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

namespace VitebskServices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Head_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `hairdressing` WHERE `Service` = 'Парикмахерская'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
            }       
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;       
        }

        private void Products_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `Products` WHERE `Service` = 'Продукты'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
        }

        private void Entertainment_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT * FROM `Entertainment` WHERE `Service` = 'Развлечения'";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            string res = string.Empty;
            while (thisReader.Read())
            {
                res += ("Название: ") + thisReader["Name"] + Environment.NewLine;
                res += ("Адрес: ") + thisReader["Address"] + Environment.NewLine;
                res += ("Номер телефона: ") + thisReader["Telephone"] + Environment.NewLine;
                res += ("График работ: ") + thisReader["WorkTime"] + Environment.NewLine;
                res += ("Сайт: ") + thisReader["WebSite"] + Environment.NewLine + Environment.NewLine;
            }
            thisReader.Close();
            ThisConnection.Close();
            textBox1.Text += res;
        }

        private void buttonMap_Click(object sender, EventArgs e)
        {
            MapForm f = new MapForm();
            f.Show();
        }
    }
}
