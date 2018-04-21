using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PassGen {
    public partial class Form1 : Form {
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WillMW";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\WillMW\\store.dat";
        public Form1() {
            InitializeComponent();
        }

        private string GetPass() {
            Form2 pw = new Form2();
            pw.ShowDialog();

            string pass = pw.Data();

            return pass;
        }

        private string DeriveKey(string input) {
            return input;
        }

        private void Form1_Load(object sender, EventArgs e) {

            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            
            if (!File.Exists(path)) {
                File.WriteAllText(path, "[]");
            }
            //MessageBox.Show("Your path is : " + path, "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string json = File.ReadAllText(path);
            List<AcctPW> logins = JsonConvert.DeserializeObject<List<AcctPW>>(json);
            for(int i = 0; i < logins.ToArray().Length; i++) {
                dataGridView1.Rows.Add(false, logins.ToArray()[i].accountName, logins.ToArray()[i].password);
            }
            string EncryptKey = "";
            do {
                EncryptKey = GetPass();
                if(EncryptKey == "NULLVALUE1234NOTAPASSWORD!!!THECHANCEOFTHISBEINGCHOSENISEXTREMELYLOWDEARGODIFTHISHAPPENSYOUREASSFUCKED!") {
                    this.Close();
                }
            } while (EncryptKey == "");
            EncryptKey = DeriveKey(EncryptKey);


            //MessageBox.Show("Your key is : " + EncryptKey, "Encryption Key", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            string json = File.ReadAllText(path);
            List<AcctPW> logins = JsonConvert.DeserializeObject<List<AcctPW>>(json);
            if (PWbox.Text != "" && NameBox.Text != "") {
                AcctPW account = new AcctPW();
                account.password = PWbox.Text;
                account.accountName = NameBox.Text;
                dataGridView1.Rows.Add(false, NameBox.Text, PWbox.Text);
                logins.Add(account);

                string output = JsonConvert.SerializeObject(logins);
                File.WriteAllText(path, output);
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
            if(checkBox1.Checked) {
                pw = pw.ToLower();
            };
            PWbox.Text = pw;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right) {
                if(dataGridView1.SelectedCells.Count == 1 && dataGridView1.CurrentCell.ColumnIndex != 0) {
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                };
            };
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            Clipboard.SetText(Convert.ToString(dataGridView1.CurrentCell.Value));
        }
    }
}
