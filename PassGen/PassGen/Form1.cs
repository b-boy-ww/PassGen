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

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if(checkBox1.Checked) {
                button1.Enabled = false;
                PWbox.Enabled = true;
                panel1.Enabled = false;
            } else {
                button1.Enabled = true;
                PWbox.Enabled = false;
                panel1.Enabled = true;
            };
        }

        private void button3_Click(object sender, EventArgs e) {
            dataGridView1.Rows.Add(false, NameBox.Text, PWbox.Text);
        }
    }
}
