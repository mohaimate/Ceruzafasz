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

            Connection.port.DataReceived += port_DataReceived;
            Connection.port.Open();
        }

        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string line = Connection.port.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
        }
        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            string data = line;
            label1.Text = line.Substring(0, line.IndexOf(".")+3);
            label11.Text = line.Substring(line.IndexOf("k")+1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When the button is pressed the code gets executed (----serialPort1.Write("")--- is the call to send a message to Arduino
            //serialPort1.Write("arduino code goes here");
            Connection.port.Write(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
        }   

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            Connection.port.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            /*Connection.port.WriteLine("1"+textBox1.Text+"2"+textBox2.Text+"3"+textBox3.Text);
            Connection.port.WriteLine(textBox1.Text);
            Connection.port.WriteLine("2");
            Connection.port.WriteLine(textBox2.Text);
            Connection.port.WriteLine("3");
            Connection.port.WriteLine(textBox3.Text);*/

            WriteByte("10");
        }

        public void WriteByte(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            Connection.port.Write(bytes, 0, data.Length);
        }
    }
}
