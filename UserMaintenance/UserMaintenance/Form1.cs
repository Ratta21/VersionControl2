using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {

        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource.FullName;
            button1.Text = Resource.Add;
            button2.Text = Resource.Save;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Adatok elmentése";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream1 = new FileStream(saveFileDialog1.FileName, FileMode.CreateNew);
                using (StreamWriter streamWriter1 = new StreamWriter(fileStream1, Encoding.Unicode))
                {
                    foreach (var item in users)
                    {
                        streamWriter1.WriteLine(item.ID + "," + item.FullName + ",");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IReadOnlyList<User> usersToRemove = users.Where(x => (x.FullName == listBox1.GetItemText(listBox1.SelectedItem))).ToList();
            foreach (var item in usersToRemove)
            {
                users.Remove(item);
            }
        }
        }
    }
