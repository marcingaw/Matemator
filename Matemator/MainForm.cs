using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matemator {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Random r = new Random();
            String[] text = new String[100];
            for (int k = 0; k < text.Length; k++) {
                text[k] = new Challenge(100, r).DebugString();
            }
            textBox1.Lines = text;
        }
    }
}
