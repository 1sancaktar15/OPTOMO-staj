using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StepMotorControl
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;

        public Form1()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            // Bağlantı durumu gösterme kodu eklenebilir
            try
            {
                _serialPort.PortName = "/dev/ttyACM0"; // Arduino'nuzun bağlı olduğu portu kontrol edin
                _serialPort.BaudRate = 9600;
                _serialPort.Open();
                MessageBox.Show("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    MessageBox.Show("Bağlantı kapandı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kapama hatası: " + ex.Message);
            }
        }

        private void btnSagaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    int adim;
                    bool isValidNumber = int.TryParse(txtAdim.Text, out adim);

                    if (isValidNumber)
                    {
                        _serialPort.WriteLine("SAGA " + adim);
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir sayı girin.");
                    }
                }
                else
                {
                    MessageBox.Show("Seri port bağlantısı açık değil.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSolaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    string inputText = txtAdim.ToString(); // TextBox içeriğini al
                    MessageBox.Show("Girdi: " + inputText ); // Girdiyi göster
                    
                   // int adim = int.Parse(txtAdim.Text);
                    int adim = Convert.ToInt32(txtAdim.Text);

                    //MessageBox.Show("girilen adim: " + adim );
                    
                    

                    // Geçerli bir sayı mı kontrol et
                    if (adim is int)
                    {
                        MessageBox.Show("Geçerli bir sayı: " + adim.ToString()); // Sayıyı göster
                        _serialPort.WriteLine("1" + adim);
                    }
                    else
                    {
                        MessageBox.Show("Girdiğiniz değerin tipi:" + adim.GetType() +"\n Geçerli bir sayı girin.");
                    }
                }
                else
                {
                    MessageBox.Show("Seri port bağlantısı açık değil.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = _serialPort.ReadLine();
            // Gelen veriyi işleyin (opsiyonel)
        }
    }
}