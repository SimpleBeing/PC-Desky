using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESKY
{
    public partial class DeskyMain : Form
    {
         
        public DeskyMain()
        {
            InitializeComponent();

            DeskyAI ai = new DeskyAI(this.WindowState,this, false);

        }

       
    }

}
