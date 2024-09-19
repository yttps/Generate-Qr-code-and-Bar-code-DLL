using ClassLibrary1_dll; //ต้องเรียกเสมอ
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallSimplaeDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simple simple = new Simple();
            
            string sayHello = simple.sayHello(textBox1.Text);
            MessageBox.Show(sayHello);
        }
    }
}
