using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace StepMotorControl
{
    public partial class Form1 : Form
    {
        public SerialPort port;

        public Form1()
        {
            InitializeComponent();
        }

        public void btnConnect_Click(object sender, EventArgs e)
        {
            port = new SerialPort("/dev/ttyACM0", 9600);
            port.DataReceived += SerialPort_DataReceived;
            try
            {
                port.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Connection Failed \nError: {exception.Message}", "Oke", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (port.IsOpen)
            {
                enableControls();
                MessageBox.Show("Bağlantı Başarılı");
            }
        }

        public void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                    MessageBox.Show("Disconnected!");
                    disableControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnection error: " + ex.Message);
            }
        }

        public void btnSagaDon_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                try
                {
                    int steps = (int)numericUpDownAdim.Value;
                    port.WriteLine("SAGA " + steps);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Serial port is not connected.");
            }
        }

        public void btnSolaDon_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                try
                {
                    int steps = (int)numericUpDownAdim.Value;
                    port.WriteLine("SOLA " + steps);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Serial port is not connected.");
            }
        }

        public void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e){
        }

        public void Form1_Load(object sender, EventArgs e)
        {
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null && port.IsOpen)
                port.Close(); // Form kapatıldığında COM portu kapat
        }

        private void enableControls()
        {
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnSagaDon.Enabled = true;
            btnSolaDon.Enabled = true;
        }

        private void disableControls()
        {
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSagaDon.Enabled = false;
            btnSolaDon.Enabled = false;
        }
    }
}
