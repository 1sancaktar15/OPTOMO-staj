using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace StepMotorControl
{
    public partial class Form1 : Form
    {
        public SerialPort port;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string indata = port.ReadLine();
            MessageBox.Show("tamamlandı");
        }

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            port = new SerialPort();
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void InitializeComboBox()
        {
            var ports = Directory.GetFiles("/dev/", "tty*")
                .Where(portName => portName.StartsWith("/dev/ttyUSB") || portName.StartsWith("/dev/ttyACM"))
                .Distinct()
                .ToList();

            foreach (var portName in ports)
            {
                using (var testPort = new SerialPort(portName))
                {
                    try
                    {
                        testPort.Open();
                        comboBoxPorts.Items.Add(portName);
                        testPort.Close();
                    }
                    catch
                    {
                        // Ignore ports that cannot be opened
                    }
                }
            }

            if (comboBoxPorts.Items.Count > 0)
            {
                comboBoxPorts.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No available serial ports found.");
            }
        }

        public void btnConnect_Click(object sender, EventArgs e)
        {
            if (comboBoxPorts.SelectedItem != null)
            {
                port.PortName = comboBoxPorts.SelectedItem.ToString();
                port.BaudRate = 9600;

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
            else
            {
                MessageBox.Show("Please select a port first.");
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

        public void btnSolaDon_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                int steps = (int)numericUpDownAdim.Value;
                port.WriteLine("1 " + steps);
                String gelenVeri = port.ReadLine();
                ProcessReceivedData(gelenVeri);
            }
            else
            {
                MessageBox.Show("Serial port is not connected.");
            }
        }

        public void btnSagaDon_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                int steps = (int)numericUpDownAdim.Value;
                port.WriteLine("0 " + steps);
                String gelenVeri = port.ReadLine();
                ProcessReceivedData(gelenVeri);
            }
            else
            {
                MessageBox.Show("Serial port is not connected.");
            }
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null && port.IsOpen)
                port.Close();
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

        private void ProcessReceivedData(string data)
        {
            if (data.Contains("bir"))
            {
                MessageBox.Show("Sola döndürülme işlemi tamamlandı.");
            }
            else if (data.Contains("sifir"))
            {
                MessageBox.Show("Sağa döndürülme işlemi tamamlandı.");
            }
            else if (data.Contains("Invalid command received."))
            {
                MessageBox.Show("Geçersiz komut alındı.");
            }
        }
    }
}
