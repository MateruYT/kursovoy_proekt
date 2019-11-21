using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        


        private void button1_Click(object sender, EventArgs e)
        {

            

            
           
            
            

            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Loader l = new Loader();
            l.ShowDialog();



            Nod nd = new Nod("Start node",true);
            treeView1.Nodes.Add(nd);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calc c = new Calc();
            c.Owner = this;
            c.ShowDialog();
        }

        Nod s(Nod n, string name)
        {
            Nod tmp = null;
            if (n.Text == name)
            {
                tmp = n; treeView1.SelectedNode = tmp;
            }
            else
            {
                for (int i = 0; i < n.Nodes.Count; i++)
                tmp = s((Nod)n.Nodes[i], name); 
            }
            return tmp;

        }


        void search(string name)
        {
           treeView1.SelectedNode = s((Nod)treeView1.Nodes[0], name);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            S s = new S();
            s.ShowDialog();
            search(s.name);

        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Точечный рисунок (*.bmp) |*.bmp";
            saveFileDialog1.FileName = "1.bmp";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {



                Bitmap bmp = new Bitmap(Bitmap.FromFile(Application.StartupPath + "\\1.jpg"));
                Bitmap bm1 = new Bitmap(640, 400);
                                
                treeView1.DrawToBitmap(bm1,new Rectangle(0,0,640,480));
                bm1.MakeTransparent(Color.White);
                
                Graphics gr = Graphics.FromImage(bmp);
                gr.DrawImage(bm1,new Point(0,0));
                bmp.Save(saveFileDialog1.FileName);  
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {


                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "help1.chm";
                SysInfo.Start();
            }
            catch
            {
                MessageBox.Show("Help file is not installed");
            } 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "help2.chm";
                SysInfo.Start();
            }
            catch
            {
                MessageBox.Show("Help file is not installed");
            } 
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "help3.chm";
                SysInfo.Start();
            }
            catch
            {
                MessageBox.Show("Help file is not installed");
            } 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
