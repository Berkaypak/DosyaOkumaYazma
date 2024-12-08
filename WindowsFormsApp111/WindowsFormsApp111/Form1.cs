using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<char> harfler = new List<char>()
        {
          ' ', 'a','b','c','ç','d','e','f','g','ğ','h','ı','i','j','k','l','m','n','o','ö','p',
           'r','s','ş','t','u','ü','v','y','z'
        };
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < harfler.Count; i++)
            {
                treeView1.Nodes.Add(harfler[i].ToString());
            }
            StreamReader sr = new StreamReader("hikaye.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] dizi = line.Split(' ');
                foreach (string d in dizi)
                {
                  string tl=  d.ToLower();
                    foreach (char s in tl)
                    {
                        if (harfler.Contains(s))
                        {
                            int io = harfler.IndexOf(s);
                            treeView1.Nodes[io].Nodes.Add("1");
                        }
                    }
                }
            }
            foreach (TreeNode tn in treeView1.Nodes)
            {
                int sayac = 0;
                foreach (TreeNode tn2 in tn.Nodes)
                {
                    sayac++;
                }
                tn.Nodes.Clear();
                tn.Nodes.Add(sayac.ToString());
            }
        }
    }
}
