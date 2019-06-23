using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzizaVKR
{
    public partial class InputRect : Form
    {
        public InputRect(int maxW, int maxH,
            int x=10, int y=10,
            int w=50, int h=50)
        {
            InitializeComponent();
            this.maxH = maxH;
            this.maxW = maxW;

            nuX.Maximum = nuW.Maximum = maxW;
            nuY.Maximum = nuH.Maximum = maxH;


            nuX.Value = x;
            nuY.Value = y;
            nuW.Value = w;
            nuH.Value = h;

        }
        int maxW, maxH;
        public int x, y, w, h;

        private void nuH_ValueChanged(object sender, EventArgs e)
        {
            if (nuY.Value > maxH - nuH.Value)
                nuY.Value = maxH - nuH.Value;

            nuY.Maximum = maxH - nuH.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.DialogResult = DialogResult.Abort;
            this.DialogResult = DialogResult.Abort;
            this.DialogResult = DialogResult.Abort;
        }

        private void nuW_ValueChanged(object sender, EventArgs e)
        {
            if (nuX.Value > maxW - nuW.Value)
                nuX.Value = maxW - nuW.Value;

            nuX.Maximum = maxW - nuW.Value;
        }

        private void nuY_ValueChanged(object sender, EventArgs e)
        {
            if (nuH.Value > maxH - nuY.Value)
                nuH.Value = maxH - nuY.Value;

            nuH.Maximum = maxH - nuY.Value;
        }

        private void nuX_ValueChanged(object sender, EventArgs e)
        {
            if (nuW.Value > maxW - nuX.Value)
                nuW.Value = maxW - nuX.Value;

            nuW.Maximum = maxW - nuX.Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            x = (int)nuX.Value;
            y = (int)nuY.Value;
            w = (int)nuW.Value;
            h = (int)nuH.Value;

            this.DialogResult = DialogResult.OK;
        }
    }
}
