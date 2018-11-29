using System;
using System.Windows.Forms;

namespace Matemator {

    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            lefts[0] = left_00;
            lefts[1] = left_01;
            lefts[2] = left_02;
            lefts[3] = left_03;
            lefts[4] = left_04;
            lefts[5] = left_05;
            lefts[6] = left_06;
            lefts[7] = left_07;

            ops[0] = op_00;
            ops[1] = op_01;
            ops[2] = op_02;
            ops[3] = op_03;
            ops[4] = op_04;
            ops[5] = op_05;
            ops[6] = op_06;
            ops[7] = op_07;

            rights[0] = right_00;
            rights[1] = right_01;
            rights[2] = right_02;
            rights[3] = right_03;
            rights[4] = right_04;
            rights[5] = right_05;
            rights[6] = right_06;
            rights[7] = right_07;

            results[0] = result_00;
            results[1] = result_01;
            results[2] = result_02;
            results[3] = result_03;
            results[4] = result_04;
            results[5] = result_05;
            results[6] = result_06;
            results[7] = result_07;

            for (int k = 0; k < challenges.Length; k++) {
                challenges[k] = new Challenge(100, false);
                ops[k].Text = "" + challenges[k].Operator;

                if (challenges[k].ShowLeft) {
                    lefts[k].Text = "" + challenges[k].Left;
                    lefts[k].ReadOnly = true;
                }

                if (challenges[k].ShowRight) {
                    rights[k].Text = "" + challenges[k].Right;
                    rights[k].ReadOnly = true;
                }

                if (challenges[k].ShowResult) {
                    results[k].Text = "" + challenges[k].Result;
                    results[k].ReadOnly = true;
                }
            }
        }

        private Challenge[] challenges = new Challenge[8];
        private TextBox[] lefts = new TextBox[8];
        private Label[] ops = new Label[8];
        private TextBox[] rights = new TextBox[8];
        private TextBox[] results = new TextBox[8];

        private void AnyTextChanged(object sender, EventArgs e) {
            bool any_red = false;

            for (int k = 0; k < challenges.Length; ++k) {

                if (!int.TryParse(lefts[k].Text, out int left)) {
                    lefts[k].ForeColor = System.Drawing.Color.Red;
                    any_red = true;
                    continue;
                }

                if (!int.TryParse(rights[k].Text, out int right)) {
                    rights[k].ForeColor = System.Drawing.Color.Red;
                    any_red = true;
                    continue;
                }

                if (!int.TryParse(results[k].Text, out int result)) {
                    results[k].ForeColor = System.Drawing.Color.Red;
                    any_red = true;
                    continue;
                }

                System.Drawing.Color color = challenges[k].Check(left, right, result) ?
                    System.Drawing.Color.Green : System.Drawing.Color.Red;
                any_red |= color == System.Drawing.Color.Red;

                if (!challenges[k].ShowLeft) {
                    lefts[k].ForeColor = color;
                }

                if (!challenges[k].ShowRight) {
                    rights[k].ForeColor = color;
                }

                if (!challenges[k].ShowResult) {
                    results[k].ForeColor = color;
                }

            }

            if (!any_red) {

                for (int k = 0; k < challenges.Length; ++k) {
                    lefts[k].ReadOnly = true;
                    rights[k].ReadOnly = true;
                    results[k].ReadOnly = true;
                }

            }

        }
    }

}
