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
    public partial class S : Form
    {
        public string name;

        public S()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                name = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите имя узла");
            }
        }
    }
}
