using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace WindowsFormsApp1
{
    public partial class StartForm : Form
    {
        int er = 0;
        public StartForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            int count = File.ReadAllLines("Info.txt").Length;
            string[] pas = new string[count];
            string[] name = new string[count];
            string[] p1 = new string[count];
            string[] p2 = new string[count];

            MainForm.users.AddUsersToDict();

            if (!MainForm.users.isUsExist(textBox1.Text))
            {
                MessageBox.Show("Неправильное имя пользователя!");
            }
            else if (MainForm.users.isUsBlocked(textBox1.Text))
            {
                MessageBox.Show("Пользователь заблокирован!");
            }
            else if (MainForm.users.passCheck(textBox1.Text, textBox2.Text))
            {


                    MainForm f2 = new MainForm();
                    f2.label1.Text = textBox1.Text;
                    f2.ShowDialog();
                    textBox2.Text = null;

            }
            else if (er < 2)
            {
                MessageBox.Show("Не верный пароль!");
                er++;
            }
            else
            {
                MessageBox.Show("Завершение работы");
                Close();
            }
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1;
            ab1 = new AboutBox1();
            ab1.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ОПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }
    }
}
