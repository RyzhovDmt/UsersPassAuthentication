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
    public partial class UsList : Form
    {
        public UsList()
        {
            InitializeComponent();
            refresh_listBox();

        }

        private void refresh_listBox()
        {
            foreach (string name in MainForm.users.getUsersList())
            {
                listBox1.Items.Add(name);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                
                checkBox1.Checked = MainForm.users.isPassComplexity(listBox1.SelectedItem.ToString());
                checkBox2.Checked = MainForm.users.isUsBlocked(listBox1.SelectedItem.ToString());
            }
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "admin")
            {
                MainForm.users.passComplexityChange(listBox1.SelectedItem.ToString(), checkBox1.Checked);
            }

        }

        private void CheckBox2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "admin")
            {
                MainForm.users.blockingChange(listBox1.SelectedItem.ToString(), checkBox2.Checked);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainForm.users.saveToFile();
            Close();
        }


        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.users.saveToFile();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1;
            ab1 = new AboutBox1();
            ab1.ShowDialog();
        }
    }
}
