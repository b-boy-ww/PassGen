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
            listView1.Left = (this.ClientSize.Width - listView1.Width) / 2;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if(checkBox1.Checked) {
                button1.Enabled = false;
                PWbox.Enabled = true;
            } else {
                button1.Enabled = true;
                PWbox.Enabled = false;
            };
        }
    }
}
