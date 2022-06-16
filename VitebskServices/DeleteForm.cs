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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }
        string name;
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string service = textBox2.Text;
            string address = textBox3.Text;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("DELETE FROM `side` WHERE `side`.`Name` = '{0}' AND `Service` = '{1}' AND  `Address` = '{2}';", name, service, address);
                MySqlDataReader thisReader = thisCommand.ExecuteReader();
                MessageBox.Show("Удаление прошло успешно", "Уведомление");
            }
            else if (result == DialogResult.No)
            {

            }
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    textBox2.Text = thisReader["Service"].ToString();
                    textBox1.Text = thisReader["Name"].ToString();
                    textBox3.Text = thisReader["Address"].ToString();
                }
            }
        }
    }
}
