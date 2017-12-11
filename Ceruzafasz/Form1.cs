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
            if (line.StartsWith("m"))
            {
                label15.Text = line.Substring(1, line.IndexOf("n")-1);
                label16.Text = line.Substring(line.IndexOf("n")+1, line.IndexOf("b")-line.IndexOf("n")-1);
                label17.Text = line.Substring(line.IndexOf("b")+1);
            } else
            {
                try {
                    label1.Text = line.Substring(0, line.IndexOf(".") + 3);
                    label11.Text = line.Substring(line.IndexOf("k") + 1);
                } catch (Exception e)
                {
                    try 
                        {
                        Application.Restart();
                        Environment.Exit(0);
                    } catch (Exception f)
                    {
                        label20.Text = "Error";
                    }
                        
                }
                
            }
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
            byte a = 0;
            if (textBox1.Text.Equals("")) a = byte.Parse(label15.Text); else a = byte.Parse(textBox1.Text);
            byte b = 0;
            if (textBox2.Text.Equals("")) b = byte.Parse(label16.Text); else b = byte.Parse(textBox2.Text);
            byte c = 0;
            if (textBox3.Text.Equals("")) c = byte.Parse(label17.Text); else c = byte.Parse(textBox3.Text);
            WriteByte(a,b,c);
        }

            public void WriteByte(byte data, byte data2, byte data3)
            {
                byte[] bytes = new byte[] { data, data2, data3 };
                Connection.port.Write(bytes, 0, bytes.Length);
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.port.Write("q");
        }
    }
    }
