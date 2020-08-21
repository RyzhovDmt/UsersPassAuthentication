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
    public partial class PassCh : Form
    {


        public PassCh()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string changed_user = label1.Text;
            if (MainForm.users.passCheck(changed_user, textBox1.Text))
            {
                if (textBox3.Text == textBox2.Text)
                {

                    if (MainForm.users.isPassComplexity(label1.Text))
                    {
                        if (MainForm.users.passComplexityCheck(textBox2.Text))
                        {
                            MainForm.users.changePass(changed_user, textBox3.Text);
                            MainForm.users.saveToFile();
                            Close();
                        }
                        else MessageBox.Show(" Пароль не удовлетворяет минимальным требованиям");
                    }
                    else
                    {
                        MainForm.users.changePass(changed_user, textBox3.Text);
                        MainForm.users.saveToFile();
                        Close();
                    }

                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
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
