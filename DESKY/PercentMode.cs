using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKY
{
    public partial class PercentMode : Form
    {
        private float initialV, secondaryV, answer;
        public PercentMode()
        {
            InitializeComponent();
            DeskyAI ai = new DeskyAI(this.WindowState,this,true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setValues();
            answer = secondaryV / initialV * 100;
            lblAnswer.Text = answer + "%";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setValues();
            answer = secondaryV / 100 * initialV;
            answer += initialV;
            lblAnswer.Text = "" + answer;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setValues();
            answer = secondaryV / 100 * initialV;
            answer -= initialV;
            lblAnswer.Text = "" + answer;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setValues();
            answer = secondaryV / 100 * initialV;
            lblAnswer.Text = "" + answer;
        }

        
        public void setValues()
        {
            initialV = float.Parse(tbInitialValue.Text);
            secondaryV = float.Parse(tbSecondaryValue.Text);
        }
    }
}
