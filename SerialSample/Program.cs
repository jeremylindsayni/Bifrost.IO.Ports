using Bifrost.IO.Ports;
using Bifrost.IO.Ports.Core;
using System;

namespace SerialSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ports = SerialPort.GetPortNames();

            foreach (var port in ports)
            {
                Console.WriteLine($"Serial port name: {port}");
            }

            var serialPort = new SerialPort()
            {
                PortName = "/dev/ttyACM0",
                BaudRate = 9600
            };

            // Subscribe to the DataReceived event.
            serialPort.DataReceived += SerialPort_DataReceived;

            // Now open the port.
            serialPort.Open();

            Console.ReadKey();

            serialPort.Close();
        }

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;

            // Read the data that's in the serial buffer.
            var serialdata = serialPort.ReadExisting();

            // Write to debug output.
            Console.Write(serialdata);
        }
    }
}