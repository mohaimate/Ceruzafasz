using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Ceruzafasz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            label1.Text = serialPort1.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("arduino code goes here");
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                serialPort1.Write(textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setupConn();
            openPort();
        }

        private void textBox1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text.Equals("Press ENTER to send")) textBox1.Text = "";
        }

        public void openPort()
        {
            if (!serialPort1.IsOpen) serialPort1.Open();
        }

        public void closePort()
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        public void setupConn()
        {
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            /*serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
            serialPort1.Encoding = System.Text.Encoding.Default;*/
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            closePort();
        }
    }
}
