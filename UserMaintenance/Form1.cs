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
using UserMaintenance.Entitites;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            
            button1.Text = Resource1.Add;
            button2.Text = Resource1.export;
            button3.Text = Resource1.remove;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
            listBox1.DataSource = users;
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            var u = new User()
            {
                FullName = textBox1.Text,
               
            };
            users.Add(u);

        }

        public void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (var u in users)
                    {
                        sw.Write(u.ID);
                        sw.Write(";");
                        sw.Write(u.FullName);
                        sw.WriteLine();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var removeID = listBox1.SelectedItem;

            users.Remove((User)removeID);

        }
    }
}
