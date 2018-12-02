using System;
using System.Windows.Forms;

namespace Matemator {

    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            int range = 100;
            bool withDiv = true;
            foreach (string cmdArg in Environment.GetCommandLineArgs()) {
                if (cmdArg.Equals("nodiv")) {
                    withDiv = false;
                }
                if (cmdArg.StartsWith("range=")) {
                    range = Int32.Parse(cmdArg.Substring(cmdArg.IndexOf('=') + 1));
                }
            }
            Lefts[0] = left00; Ops[0] = op00; Rights[0] = right00; Results[0] = result00;
            Lefts[1] = left01; Ops[1] = op01; Rights[1] = right01; Results[1] = result01;
            Lefts[2] = left02; Ops[2] = op02; Rights[2] = right02; Results[2] = result02;
            Lefts[3] = left03; Ops[3] = op03; Rights[3] = right03; Results[3] = result03;
            Lefts[4] = left04; Ops[4] = op04; Rights[4] = right04; Results[4] = result04;
            Lefts[5] = left05; Ops[5] = op05; Rights[5] = right05; Results[5] = result05;
            Lefts[6] = left06; Ops[6] = op06; Rights[6] = right06; Results[6] = result06;
            Lefts[7] = left07; Ops[7] = op07; Rights[7] = right07; Results[7] = result07;
            Lefts[8] = left08; Ops[8] = op08; Rights[8] = right08; Results[8] = result08;
            Lefts[9] = left09; Ops[9] = op09; Rights[9] = right09; Results[9] = result09;
            Lefts[10] = left10; Ops[10] = op10; Rights[10] = right10; Results[10] = result10;
            Lefts[11] = left11; Ops[11] = op11; Rights[11] = right11; Results[11] = result11;
            for (int k = 0; k < Challenges.Length; k++) {
                Challenges[k] = new Challenge(range, withDiv);
                Ops[k].Text = "" + Challenges[k].Operator;
                if (Challenges[k].ShowLeft) {
                    Lefts[k].Text = "" + Challenges[k].Left;
                    Lefts[k].ReadOnly = true;
                }
                if (Challenges[k].ShowRight) {
                    Rights[k].Text = "" + Challenges[k].Right;
                    Rights[k].ReadOnly = true;
                }
                if (Challenges[k].ShowResult) {
                    Results[k].Text = "" + Challenges[k].Result;
                    Results[k].ReadOnly = true;
                }
            }
        }

        private Challenge[] Challenges = new Challenge[12];
        private TextBox[] Lefts = new TextBox[12];
        private Label[] Ops = new Label[12];
        private TextBox[] Rights = new TextBox[12];
        private TextBox[] Results = new TextBox[12];

        private void AnyTextChanged(object sender, EventArgs e) {
            bool anyRed = false;
            for (int k = 0; k < Challenges.Length; ++k) {
                if (!int.TryParse(Lefts[k].Text, out int left)) {
                    Lefts[k].ForeColor = System.Drawing.Color.Red;
                    anyRed = true;
                    continue;
                }
                if (!int.TryParse(Rights[k].Text, out int right)) {
                    Rights[k].ForeColor = System.Drawing.Color.Red;
                    anyRed = true;
                    continue;
                }
                if (!int.TryParse(Results[k].Text, out int result)) {
                    Results[k].ForeColor = System.Drawing.Color.Red;
                    anyRed = true;
                    continue;
                }
                System.Drawing.Color color = Challenges[k].Check(left, right, result) ?
                    System.Drawing.Color.Green : System.Drawing.Color.Red;
                anyRed |= color == System.Drawing.Color.Red;
                if (!Challenges[k].ShowLeft) {
                    Lefts[k].ForeColor = color;
                }
                if (!Challenges[k].ShowRight) {
                    Rights[k].ForeColor = color;
                }
                if (!Challenges[k].ShowResult) {
                    Results[k].ForeColor = color;
                }
            }
            if (!anyRed) {
                for (int k = 0; k < Challenges.Length; ++k) {
                    Lefts[k].ReadOnly = true;
                    Rights[k].ReadOnly = true;
                    Results[k].ReadOnly = true;
                }
            }
        }

    }

}
