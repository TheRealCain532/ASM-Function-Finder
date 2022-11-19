using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_Function_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] funcNames = new string[5000];
        string mFile;
        int g;
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Load Assembly File | *.s";
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.Text = $"{file.SafeFileName} Loaded ~Cain532";
                mFile = File.ReadAllText(file.FileName);
                String[] cheatlist = Regex.Replace(mFile, @"^\s+$[\r\n]*", "", RegexOptions.Multiline).Split('\n');
                for (int i = 0; i < cheatlist.Length; i++)
                {
                    if (cheatlist[i].StartsWith(".global"))
                    {
                        funcNames[g] = cheatlist[i].Remove(0, 8);
                        g++;
                    }
                }
                funcNames = funcNames.Where(c => c != null).ToArray();
                funcLabel.ForeColor = Color.Green;
                funcLabel.Text = $"{funcNames.Length} Functions found!";
                foreach (var item in funcNames) richTextBox1.Text += $"{item}\n";
            }
        }
    }
}
