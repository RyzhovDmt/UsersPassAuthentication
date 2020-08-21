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
    public partial class AddUs : Form
    {
        public AddUs()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!(WindowsFormsApp1.MainForm.users.isUsExist(newUsName.Text)))
            {
                FileStream file2 = new FileStream("Info.txt", FileMode.Append);
                StreamWriter fnew2 = new StreamWriter(file2);
                fnew2.WriteLine(newUsName.Text + ' ' + "" + ' ' + 1 + ' ' + 0);
                fnew2.Close();
                MainForm.users.AddUsersToDict();
                MainForm.users.saveToFile();
                Close();
            }
            else MessageBox.Show("Пользователь с таким именем уже существует");
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1;
            ab1 = new AboutBox1();
            ab1.ShowDialog();
        }
    }
}
