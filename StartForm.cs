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
        
            string str, log, npas;
            int space1, space2, space3;
            int spaceCount;
            bool b = false, l = false, admPass = false;
            int count = File.ReadAllLines("Info.txt").Length;
            string[] pas = new string[count];
            string[] name = new string[count];
            string[] p1 = new string[count];
            string[] p2 = new string[count];
            int n = 0;

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
            /*  for (int i = 0; i < count; i++)
              {
                  if (log == name[i])
                  {
                      l = true;
                      n = i;
                  }
              }
              if (l == false)
                  MessageBox.Show(" Неправильное имя пользователя!");
              else
              {
                  if (p1[n] == "1")
                      MessageBox.Show(" Пользователь заблокирован!");
                  else
                  {
                      if (npas != pas[n])
                      {
                          MessageBox.Show(" Не верный пароль!");
                          er++;
                          if (er == 3)
                          {
                              MessageBox.Show(" Завершение работы");
                              Close();
                          }
                      }
                      if (npas == pas[n])
                      {
                          Form2 f2 = new Form2();
                          f2.ShowDialog();

                      }
                  }
              }*/
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1;
            ab1 = new AboutBox1();
            ab1.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*StartForm f1 = new StartForm();
            if (!(File.Exists("Info.txt")))
            {
                FileStream file = new FileStream("Info.txt", FileMode.Create);
                StreamWriter fnew = new StreamWriter(file);
                fnew.WriteLine("admin" + ' ' + "" + ' ' + "1" + ' ' + "0");
                fnew.Close();
            }*/
        }

        private void ОПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }
    }
}
