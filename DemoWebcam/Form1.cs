using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //

namespace DemoWebcam
{
    public partial class Form1 : Form
    {
        FilterInfoCollection webcams;
        VideoCaptureDevice videoIn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //input cam in laptop
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //display webcam in combobox
            foreach (FilterInfo webcam in webcams)
            {
                comboBox1.Items.Add(webcam.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //on btn
            int selectCamIndex = comboBox1.SelectedIndex;
            //MonikerString object to str
            videoIn = new VideoCaptureDevice(webcams[selectCamIndex].MonikerString); 
            videoSourcePlayer1.VideoSource = videoIn;
            videoSourcePlayer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //กดปิดต้องปิดกล้องด้วย
            //off btn
            if (videoIn != null && videoIn.IsRunning) { 
                videoSourcePlayer1.Stop();  
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoIn != null && videoIn.IsRunning)
            {
                videoSourcePlayer1.Stop();
            }
        }
    }
}
