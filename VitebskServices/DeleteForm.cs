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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string service = textBox2.Text;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MySqlConnection ThisConnection = new MySqlConnection("server=localhost;port=3307;username=root;password=root;database=is");
                ThisConnection.Open();
                MySqlCommand thisCommand = ThisConnection.CreateCommand();
                thisCommand.CommandText = String.Format("DELETE FROM `side` WHERE `side`.`Name` = '{0}' AND `Service` = '{1}';", name, service);
                MySqlDataReader thisReader = thisCommand.ExecuteReader();
                MessageBox.Show("Удаление прошло успешно", "Уведомление"); 
            }
            else if (result == DialogResult.No)
            {

            }
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
