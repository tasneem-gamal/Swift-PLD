using com.calitha.goldparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace language
{
    
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            this.parser = new MyParser(".\\swift.cgt", listBox2, listBox3);
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();
            this.listBox3.Items.Clear();
            this.parser.Parse(textBox2.Text);
        }

    }
}
