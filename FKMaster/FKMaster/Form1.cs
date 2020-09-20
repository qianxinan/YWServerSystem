using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FKMaster
{
    public partial class FKFrom1 : Form
    {
        public static SocketMaster socketMaster;
        public FKFrom1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            socketMaster = new SocketMaster();
            socketMaster.Connect();
        }

        private void FKFrom1_FormClosed(object sender, FormClosedEventArgs e)
        {
            socketMaster.mySocket.Close();
        }

        private void BroadcastButton_Click(object sender, EventArgs e)
        {
            if (!BroadcastTextBox.Text.Equals(""))
            {
                MessageSender.SendMessage(BroadcastTextBox.Text);
                MessageBox.Show("广播成功");
                BroadcastTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("请勿发送空字符");
            }
        }

        private void MouseSeterButton_Click(object sender, EventArgs e)
        {
            if(IsNumberic(MouseXBox.Text) && IsNumberic(MouseYBox.Text))
            {
                MessageSender.SetMouse(int.Parse(MouseXBox.Text),int.Parse(MouseYBox.Text));
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
        }

        private bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
