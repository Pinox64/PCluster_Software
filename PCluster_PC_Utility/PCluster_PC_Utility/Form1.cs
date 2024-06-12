using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HidLibrary;
using System.Management;
using System.IO;
using OpenHardwareMonitor.Hardware;
using System.Threading;
using PCluster;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;
using Newtonsoft.Json;
using static PCluster_PC_Utility.Form1;


namespace PCluster_PC_Utility
{
  
  public partial class Form1 : Form
  {
    PClusterDevice PCluster1;
    private ManualResetEvent pClusterInitialized = new ManualResetEvent(false);
    string[] DisplayItemsValues = { "OFF", "CPU Usage", "CPU Temp", "Memory Usage", "GPU Usage", "GPU Temp", "Disk Speed", "Disk Usage", "Internet Speed" };
    static float cpuTemp;
    // CPU Usage
    static float cpuUsage;
    // CPU Power Draw (Package)
    static float cpuPowerDrawPackage;
    // CPU Frequency
    static float cpuFrequency;
    // GPU Temperature
    static float gpuTemp;
    // GPU Usage
    static float gpuUsage;
    // GPU Core Frequency
    static float gpuCoreFrequency;
    // GPU Memory Frequency
    static float gpuMemoryFrequency;
    // Memory Usage (RAM)
    static float memoryUsage;
    // Disk Usage
    static float HDDUsage;
    HidDevice device;
    static Computer c = new Computer()
    {
      GPUEnabled = true,
      CPUEnabled = true,
      RAMEnabled = true
      //RAMEnabled = true, // uncomment for RAM reports
      //MainboardEnabled = true, // uncomment for Motherboard reports
      //FanControllerEnabled = true, // uncomment for FAN Reports
      //HDDEnabled = true, // uncomment for HDD Report
    };
    private bool applicationExiting = false;
    public Form1()
    {
      InitializeComponent();



    }

    private void Form1_Load(object sender, EventArgs e)
    {
      device = HidDevices.Enumerate(0x1A86, 0xE429).FirstOrDefault();
    Thread hardwareUpdater = new Thread(ReportSystemInfo);
      hardwareUpdater.Priority = ThreadPriority.Highest;
      hardwareUpdater.Start();
      //Console.WriteLine(device.Capabilities.FeatureReportByteLength);
      pClusterInitialized.WaitOne();

      comboBox1.Items.Clear();
      comboBox2.Items.Clear();
      comboBox3.Items.Clear();
      comboBox4.Items.Clear();

      
        
          
  
      


      // Load JSON file
      string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
      string jsonContent = File.ReadAllText(jsonFilePath);

      // Deserialize JSON to Config object
      var config = JsonConvert.DeserializeObject<Config>(jsonContent);

      // Access parameters
      Console.WriteLine("Display1: " + config.Display1);
      Console.WriteLine("Display2: " + config.Display2);
      Console.WriteLine("Display3: " + config.Display3);
      Console.WriteLine("Display4: " + config.Display4);

      foreach (string displayInfo in DisplayItemsValues)
      {
        comboBox1.Items.Add(displayInfo);
        comboBox1.SelectedIndex = 0;
        comboBox2.Items.Add(displayInfo);
        comboBox2.SelectedIndex = 0;
        comboBox3.Items.Add(displayInfo);
        comboBox3.SelectedIndex = 0;
        comboBox4.Items.Add(displayInfo);
        comboBox4.SelectedIndex = 0;
      }
      comboBox1.SelectedIndex = config.Display1;
      comboBox2.SelectedIndex = config.Display2;
      comboBox3.SelectedIndex = config.Display3;
      comboBox4.SelectedIndex = config.Display4;
      comboBox5.SelectedIndex = 3;

      c.Open();
      


      
      
      

    }

    public class Config //Configuration save of the values to show on each display
    {
      public int Display1 { get; set; }
      public int Display2 { get; set; }
      public int Display3 { get; set; }
      public int Display4 { get; set; }
    }

    void ReportSystemInfo()
    {
      PCluster1 = new PClusterDevice(device);
      byte[] displayableValues = new byte[9];
      PerformanceCounter bytesSentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec");
      PerformanceCounter bytesReceivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec");
      pClusterInitialized.Set(); // Signal that PCluster1 is initialized

      while (true)
      {
        Thread.Sleep(100);
        foreach (var hardware in c.Hardware)
        {

          if (hardware.HardwareType == HardwareType.CPU)
          {
            // only fire the update when found
            hardware.Update();

            // loop through the data
            foreach (var sensor in hardware.Sensors)
              if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Package"))
              {
                // store
                cpuTemp = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("cpuTemp: " + sensor.Value.GetValueOrDefault());

              }
              else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
              {
                // store
                cpuUsage = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("cpuUsage: " + sensor.Value.GetValueOrDefault());
              }
              else if (sensor.SensorType == SensorType.Power && sensor.Name.Contains("CPU Package"))
              {
                // store
                cpuPowerDrawPackage = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("CPU Power Draw - Package: " + sensor.Value.GetValueOrDefault());


              }
              else if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("CPU Core #1"))
              {
                // store
                cpuFrequency = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("cpuFrequency: " + sensor.Value.GetValueOrDefault());
              }
          }


          // Targets AMD & Nvidia GPUS
          if (hardware.HardwareType == HardwareType.GpuAti || hardware.HardwareType == HardwareType.GpuNvidia)
          {
            // only fire the update when found
            hardware.Update();

            // loop through the data
            foreach (var sensor in hardware.Sensors)
              if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
              {
                // store
                gpuTemp = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("gpuTemp: " + sensor.Value.GetValueOrDefault());
              }
              else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
              {
                // store
                gpuUsage = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("gpuUsage: " + sensor.Value.GetValueOrDefault());
              }
              else if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("GPU Core"))
              {
                // store
                gpuCoreFrequency = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("gpuCoreFrequency: " + sensor.Value.GetValueOrDefault());
              }
              else if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("GPU Memory"))
              {
                // store
                gpuMemoryFrequency = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("gpuMemoryFrequency: " + sensor.Value.GetValueOrDefault());
              }

          }

          if (hardware.HardwareType == HardwareType.RAM)
          {
            // only fire the update when found
            hardware.Update();

            // loop through the data
            foreach (var sensor in hardware.Sensors)
              if (sensor.SensorType == SensorType.Load)
              {
                // store
                memoryUsage = sensor.Value.GetValueOrDefault();
                // print to console
                System.Diagnostics.Debug.WriteLine("RAM Usage: " + sensor.Value.GetValueOrDefault());
              }


          }

          // ... you can access any other system information you want here
          try
          {
            
            
              PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == "CPU Usage").Value = (byte)cpuUsage;
              PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == "CPU Temp").Value = (byte)cpuTemp;
              PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == "GPU Usage").Value = (byte)gpuUsage;
              PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == "GPU Temp").Value = (byte)gpuTemp;
              PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == "Memory Usage").Value = (byte)memoryUsage;
              //PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == "Internet Speed").Value = (byte)(bytesSentCounter.NextValue() + bytesReceivedCounter.NextValue()) ;
              PCluster1.update();
            
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex);
              Thread.CurrentThread.Abort();
          }


        }

        /*
         HidReport report = new HidReport(data.Length, new HidDeviceData(data, HidDeviceData.ReadStatus.Success));
         device.WriteReport(report);
        */
      }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new Action(() => comboBox2_SelectedIndexChanged(sender, e)));
      }
      else
      {
        try
        {
          PCluster1.disp1.DisplayedInfo = (byte)PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == comboBox1.Text).ID;
        }
        catch
        {
          Console.WriteLine("PCluster1 was null");
        }
      }
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new Action(() => comboBox2_SelectedIndexChanged(sender, e)));
      }
      else
      {
        try
        {
          PCluster1.disp2.DisplayedInfo = (byte)PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == comboBox2.Text).ID;
        }
        catch
        {
          Console.WriteLine("PCluster1 was null");
        }
      }
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new Action(() => comboBox2_SelectedIndexChanged(sender, e)));
      }
      else
      {
        try
        {
          PCluster1.disp3.DisplayedInfo = (byte)PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == comboBox3.Text).ID;
        }
        catch
        {
          Console.WriteLine("PCluster1 was null");
        }
      }
    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new Action(() => comboBox2_SelectedIndexChanged(sender, e)));
      }
      else
      {
        try
        {
          PCluster1.disp4.DisplayedInfo = (byte)PCluster1.DisplayInfos.FirstOrDefault(item => item.MenuValue == comboBox4.Text).ID;
        }
        catch
        {
          Console.WriteLine("PCluster1 was null");
        }
      }
    }

    private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
    {
      PCluster1.LEDValue = (byte)comboBox5.SelectedIndex;
      Console.WriteLine("LEDValue:  " + (byte)comboBox5.SelectedIndex);
      PCluster1.LEDBrightness = calculateBrightness(trackBar1.Value);
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      PCluster1.LEDBrightness = calculateBrightness(trackBar1.Value);
    }

    private byte calculateBrightness(int value)
    {// Ensure value is within the valid range
      byte[] brightnessValues = { 1, 3, 7, 12, 20, 30, 45, 60, 75, 90, 100 };

      // Ensure value is within the valid range
      if (value < 0)
      {
        value = 0;
      }
      else if (value > 10)
      {
        value = 10;
      }

      // Retrieve the corresponding brightness value from the lookup table
      byte brightness = brightnessValues[value];

      return brightness;
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      if(this.WindowState == FormWindowState.Minimized)
      {
        //notifyIcon1.Icon = SystemIcons.Application;
        //notifyIcon1.BalloonTipText = "The window has been minimized to system tray";
        //notifyIcon1.ShowBalloonTip(1000);
        this.ShowInTaskbar = false;
        notifyIcon1.Visible = true;
      }
      

    }

    private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
    {
      if(e.Button == MouseButtons.Left)
      {
        this.WindowState = FormWindowState.Normal;
        this.ShowInTaskbar = true;
      }

    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (applicationExiting == false)
      {
        e.Cancel = true;
        this.WindowState = FormWindowState.Minimized;
        //notifyIcon1.Icon = SystemIcons.Application;
        //notifyIcon1.BalloonTipText = "The window has been minimized to system tray";
        //notifyIcon1.ShowBalloonTip(1000);
        this.ShowInTaskbar = false;
        notifyIcon1.Visible = true;
      }
      
    }

    private void exitMenuItem2_Click_1(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Normal;
      this.ShowInTaskbar = true;
    }

    private void exitMenuItem1_Click_1(object sender, EventArgs e)
    {
      // Close the application when the exit menu item is clicked
      applicationExiting = true;
      this.Close();
    }

    private void buttonBootloader_Click(object sender, EventArgs e)
    {
      PCluster1.bootLoaderMode = true;
      
    }
  }
}


