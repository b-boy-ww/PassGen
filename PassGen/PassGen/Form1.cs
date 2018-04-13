using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassGen {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            button1.Left = (this.ClientSize.Width - ((button1.Width + 30) + button1.Width)) / 2;
            button3.Left = (this.ClientSize.Width - (button3.Width - (button3.Width + 30))) / 2;
            button2.Left = (this.ClientSize.Width - button2.Width) / 2;
            dataGridView1.Left = (this.ClientSize.Width - dataGridView1.Width) / 2;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            for(int i = 1; i < dataGridView1.ColumnCount; i++) {
                dataGridView1.Columns[i].Width = (dataGridView1.Width - 27) / 2;
            };
        }

        private void button3_Click(object sender, EventArgs e) {
            if(PWbox.Text != "" && NameBox.Text != "") {
                dataGridView1.Rows.Add(false, NameBox.Text, PWbox.Text);
            } else {
                MessageBox.Show("You have either not generated/inserted a password or you have not inserted an Account Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Random rnd = new Random();
            var list = new List<int>();
            for (int j = 65; j < 90; j++) {
                list.Add(j);
            };
            for (int j = 97; j < 122; j++) {
                list.Add(j);
            };
            string pw = "";
            if (checkBox2.Checked) {
                for (int j = 48; j < 57; j++) {
                    list.Add(j);
                };
            };
            if(checkBox3.Checked) {
                for (int j = 33; j < 47; j++) {
                    list.Add(j);
                };
                for (int j = 58; j < 64; j++) {
                    list.Add(j);
                };
                for (int j = 91; j < 96; j++) {
                    list.Add(j);
                };
                for (int j = 123; j < 126; j++) {
                    list.Add(j);
                };
            }
            for (int i = 0; i < numericUpDown1.Value; i++) {
                pw = pw + Convert.ToString(char.ConvertFromUtf32(list.ToArray()[rnd.Next(0, list.ToArray().Length)]));
            }
            PWbox.Text = pw;
        }
    }
}
