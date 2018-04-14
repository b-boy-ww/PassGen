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
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }
        public string Data() {
            return textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if(checkBox1.Checked) {
                textBox1.UseSystemPasswordChar = false;
            } else {
                textBox1.UseSystemPasswordChar = true;
            };
        }

        private void Form2_Load(object sender, EventArgs e) {
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }
    }
}
