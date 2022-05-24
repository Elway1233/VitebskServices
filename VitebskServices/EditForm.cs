using GMap.NET.WindowsForms;
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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name;
            name = comboBox1.SelectedItem.ToString();
            if (name != null)
            {
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("SELECT * FROM `side` WHERE  Name = '{0}'", name);
                MySqlDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    textBox6.Text = thisReader["Service"].ToString();
                    textBox1.Text = thisReader["Name"].ToString();
                    textBox2.Text = thisReader["Address"].ToString();
                    textBox3.Text = thisReader["Telephone"].ToString();
                    textBox4.Text = thisReader["WorkTime"].ToString();
                    textBox5.Text = thisReader["WebSite"].ToString();
                }
            }
        }

        private void Get_Click(object sender, EventArgs e)
        {
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = "SELECT Name FROM `side`";
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            List<string> list = new List<string>();
            while (thisReader.Read())
            {
                list.Add(("") + thisReader["Name"]);
            }
            for (var i = 0; i < list.Count; i++)
                comboBox1.Items.Add(list[i]);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string name, address, telephone, service, worktime, website;
            int id = 0;
            name = textBox1.Text;
            address = textBox2.Text;
            telephone = textBox3.Text;
            worktime = textBox4.Text;
            website = textBox5.Text;
            service = textBox6.Text;
            MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
            ThisConnection.Open();
            MySqlCommand thisCommand = ThisConnection.CreateCommand();
            thisCommand.CommandText = String.Format("SELECT id FROM `side` WHERE Name = '{0}'",name);
            MySqlDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read())
            {
                id = Convert.ToInt16(thisReader["id"]);
            }
            thisReader.Close();
            MySqlCommand thisCommand1 = ThisConnection.CreateCommand();
            thisCommand1.CommandText = String.Format("UPDATE `side` SET `Service`= '{0}' ,`Name`= '{1}',`Address`= '{2}',`Telephone`= '{3}',`WorkTime`= '{4}',`WebSite`= '{5}' WHERE id = {6}", service,name,address,telephone,worktime,website,id);
            MySqlDataReader thisReader1 = thisCommand1.ExecuteReader();
            thisReader1.Close();
            ThisConnection.Close();
            Close();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox3.Text;
            if (c.Length >= 0 && c.Length < 13)
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
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox1.Text;
            if (c.Length >= 0 && c.Length < 25)
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
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string c = textBox2.Text;
            if (c.Length >= 0 && c.Length < 50)
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
                errorProvider2.SetError(textBox2, "");
            }
        }
    }
}
