using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKClient
{
    public partial class Form1 : Form
    {
        public static SocketClient socketClient;
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MouseSetter.MoveMouseToPoint(new Point(0,0));
            socketClient = new SocketClient();
            socketClient.Connect();
           
        }

        private void WhenWindowsCloser(object sender, FormClosedEventArgs e)
        {

            socketClient.mySocket.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Bitmap bm = new Bitmap("c:/1.bmp");

            List<string> vs = new List<string>();
            MemoryStream zz = new MemoryStream();
            EncoderParameters eps = new EncoderParameters(1);
            EncoderParameter ep = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 4L);//质量bai等级90%
            eps.Param[0] = ep;
            Image img = DesktopSetter.GetScreenCapture();
            img.Save(zz, DesktopSetter.GetEncoderInfo("image/bmp"),eps);
            
            //bm.Save(zz, ImageFormat.Bmp);
            zz.Flush();
            //Image image = Image.FromStream(zz);
            img.Save("C:\\test.bmp");
            vs.Add("Desktop");
            vs.Add(System.Text.Encoding.UTF8.GetString(zz.ToArray()));
            MessageBox.Show(System.Text.Encoding.UTF8.GetString(zz.ToArray()));
            socketClient.SendMessage(vs);
        }

    }
}
