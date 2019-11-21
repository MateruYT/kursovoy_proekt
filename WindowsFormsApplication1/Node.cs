using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    [Serializable]
    public class Nod:TreeNode
    {
        int id, pid;
        //string name;
        bool isstart;
        

        public Nod(string Text, bool isstart)
        {
            this.isstart = isstart;
            this.Text = Text;
            ContextMenu cm = new ContextMenu();
            MenuItem m1 = new MenuItem("Добавить");
            cm.MenuItems.Add(m1);
            MenuItem m2 = new MenuItem("Переименовать");
            cm.MenuItems.Add(m2);
            MenuItem m3 = new MenuItem("Удалить");
            cm.MenuItems.Add(m3);
            ContextMenu = cm;
            m3.Click += new EventHandler(Del);
            m2.Click += new EventHandler(Ren);
            m1.Click += new EventHandler(Add);
            if (this.isstart == true) { m3.Enabled = false; }
        }

        public void Ren(object a, EventArgs e)
        {
            if (this.Nodes.Count <= 1)
            {
                NN fx = new NN();
                fx.ShowDialog();
                this.Text = fx.name;
                this.Expand();
            }
            else { MessageBox.Show("Дерево бинарное!"); }
        }

        public void Add(object a, EventArgs e)
        {
            if (this.Nodes.Count <= 1)
            {
                NN fx = new NN();
                fx.ShowDialog();
                this.Nodes.Add(new Nod(fx.name,false));
                this.Expand();
            }
            else { MessageBox.Show("Дерево бинарное!"); }
        }

        public void Del(object a, EventArgs e)
        {
            //this.Parent.Nodes[this.Index].Remove();
            this.Remove();
        }



    }
}
