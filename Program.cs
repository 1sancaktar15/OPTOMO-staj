using System;
using System.Windows.Forms; // Application sınıfını ekledik

namespace StepMotorControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Form1'i başlat
        }
    }
}