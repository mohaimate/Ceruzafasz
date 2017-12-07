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

        /*private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Anything here is triggered when data is received from the port (---serialPort1.ReadLine()--- is the call to read the received message)
            //label1.Text = serialPort1.ReadLine();
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            //When the button is pressed the code gets executed (----serialPort1.Write("")--- is the call to send a message to Arduino
            //serialPort1.Write("arduino code goes here");
            SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("kurva élet");
        } // igen oki megnézem, de akkor bedugva hagyom usbn arduit


        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //check if Enter is pressed
            {
                //serialPort1.Write(textBox1.Text); //send the console textbox command to the port
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //connection is set up and the port to the connection is opened upon program start
            //setupConn();
        }

        private void textBox1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text.Equals("Press ENTER to send")) textBox1.Text = "";
        }

       

       /* public void setupConn()
        {
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
            serialPort1.Encoding = System.Text.Encoding.Default;
        }*/

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
