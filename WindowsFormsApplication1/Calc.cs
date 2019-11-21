using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Calc : Form
    {
        public Calc()
        {
            InitializeComponent();
        }


        int rec(Nod n)
        {
            int c = 1;
            for (int i = 0; i < n.Nodes.Count; i++)
            {
                c += rec((Nod)n.Nodes[i]);
            }
            textBox1.Text = c.ToString();
            return c;
            
        }

        int gmd(Nod n, int md)
        {
            if (md < n.Level) { md = n.Level; }
            for (int i = 0; i < n.Nodes.Count; i++)
            {
                if (md < gmd((Nod)n.Nodes[i], md))
                    md = gmd((Nod)n.Nodes[i], md);
            }
            textBox2.Text = md.ToString();
            return md;
        }

        void calc()
        {
            Form1 main = this.Owner as Form1;
            int c = 1;
            int md = 1;

            // for (int i = 0; i< treeView1.Nodes.Count; i++)
            c += rec((Nod)main.treeView1.Nodes[0]);
            md = gmd((Nod)main.treeView1.Nodes[0], md);

            textBox1.Text = (c-1).ToString();
            textBox2.Text = md.ToString();

        }



        private void Calc_Load(object sender, EventArgs e)
        {
            calc();
        }

    }
}
