using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using AForge.Video.DirectShow;
using System.Text.RegularExpressions;
using LabCLL_RandomNumber;


namespace DemoBarCodeQRCode
{
    public partial class Form1 : Form
    {
        FilterInfoCollection webcams;
        VideoCaptureDevice videoIn;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //generate image

            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.CharacterSet = "UTF-8";
            options.Width = 200;
            options.Height = 130;

            BarcodeWriter writer = new BarcodeWriter();
            writer.Options = options;

            if (radioButton1.Checked)
                writer.Format = BarcodeFormat.QR_CODE;
            else
                writer.Format = BarcodeFormat.CODE_39;
            var result = writer.Write(textBox1.Text);
            pictureBox1.Image = result;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("code.jpg");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //display webcam in combobox
            foreach (FilterInfo webcam in webcams)
            {
                comboBox1.Items.Add(webcam.Name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //on btn
            int selectCamIndex = comboBox1.SelectedIndex;
            //MonikerString object to str
            videoIn = new VideoCaptureDevice(webcams[selectCamIndex].MonikerString);
            videoSourcePlayer1.VideoSource = videoIn;
            videoSourcePlayer1.Start();
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //กดปิดต้องปิดกล้องด้วย
            //off btn
            if (videoIn != null && videoIn.IsRunning)
            {
                timer1.Stop();
                videoSourcePlayer1.Stop();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoIn != null && videoIn.IsRunning)
            {
                timer1.Stop();
                videoSourcePlayer1.Stop();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var capture = videoSourcePlayer1.GetCurrentVideoFrame();
            if (capture != null)
            {
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(capture);

                if (result != null) {
                    listBox1.Items.Insert(0, result.Text + " "
                        + result.BarcodeFormat.ToString());
                }
            }
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select an Image File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // โหลดรูปภาพจากไฟล์ที่เลือก
                    var barcodeBitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);

                    // สร้าง BarcodeReader และทำการ decode บาร์โค้ด
                    BarcodeReader reader = new BarcodeReader();
                    var result = reader.Decode(barcodeBitmap);

                    // ถ้าบาร์โค้ดถูกอ่านสำเร็จ แสดงผลใน listBox1
                    if (result != null)
                    {
                        listBox1.Items.Insert(0, result.Text + " " + result.BarcodeFormat.ToString());
                    }
                    else
                    {
                        MessageBox.Show("No barcode detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomNumber random = new RandomNumber();

            string result = random.Random();
            textBox1.Text = result;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
