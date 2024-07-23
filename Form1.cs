using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace StepMotorControl
{
    public partial class Form1 : Form
    {
        public SerialPort port;

        private  void DataReceivedHandler(
            object sender,
            SerialDataReceivedEventArgs e)
        {
            
            string indata = port.ReadLine();
            MessageBox.Show("tamamlandı");

        }
        
        public Form1()
        {
            InitializeComponent();
            port = new SerialPort("/dev/ttyACM0", 9600);
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        public void btnConnect_Click(object sender, EventArgs e)
        {
            
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
                    port.WriteLine("0 " + steps); // coercion
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
        
        private void ProcessReceivedData(string data)
        {
            // Gelen veri doğrulanır ve uygun pop-up mesajı gösterilir
            if (data.Contains("bir")) //string şeklinde verdiğimde algıladı
            {
                MessageBox.Show("Sola döndürülme işlemi tamamlandı.");
            }
            else if (data.Contains("sifir")) // türkçe karakter kullanılmamalı
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




