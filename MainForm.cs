using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public static usersList users = new usersList();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PassCh f3 = new PassCh();
            f3.label1.Text = label1.Text;
            f3.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddUs f4 = new AddUs();
            f4.label1.Text = label1.Text;
            f4.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            UsList f5 = new UsList();
            f5.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if ((label1.Text != "admin") || (MainForm.users.passCheck("admin", "")))
            {
                this.button2.Enabled = false;
                this.button3.Enabled = false;
                if (users.passCheck("admin", ""))
                {
                    label2.Text = "Для продолжения работы измените пароль!";
                }
            }


        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1;
            ab1 = new AboutBox1();
            ab1.ShowDialog();
        }


    }
}
