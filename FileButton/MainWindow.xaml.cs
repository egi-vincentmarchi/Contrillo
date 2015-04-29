using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;
using System.IO;


namespace FileButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



private void refreshTimer_Tick(object sender, EventArgs e)
{
   if (File.Exists(@"c:\Efund\Control\Reverse\ReverseON.ALL"))
            { rev = true; 
                this.btnReverseAll.Content = "Click to Turn Reverse OFF"; 
                this.lblReverseStatus.Content = "Status: Reverse is ON!";
                this.lblReverseStatus.Foreground = new SolidColorBrush(Colors.LimeGreen);
            }
            else 
            {
                rev = false;
                this.btnReverseAll.Content = "Click to Turn Reverse ON";
                this.lblReverseStatus.Content = "Status: Reverse is OFF!";
                this.lblReverseStatus.Foreground = new SolidColorBrush(Colors.Red);
            }
            
            if (File.Exists(@"C:\EFund\Control\HaltTrading\HaltTrading.ALL")) { lblStatus.Content = "Trading HALTED!!"; }
            else { lblStatus.Content = "Trading LIVE!!"; }
            //MessageBox.Show("Follow the rules! Good luck! God is good! Thank Him now!");
}


        private bool rev = true;
        public MainWindow()
        {
            InitializeComponent();
            
                    DispatcherTimer refreshTimer = new System.Windows.Threading.DispatcherTimer();
                    refreshTimer.Tick += new EventHandler(refreshTimer_Tick);
                    refreshTimer.Interval = new TimeSpan(0,0,5); //Check every 5 seconds for refresh
                    refreshTimer.Start();

           
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(@"C:\EFund\Control\HaltTrading\TradingLIVE.ALL")) 
            {
                FileStream fs1 = new FileStream(@"C:\EFund\Control\HaltTrading\TradingLIVE.ALL", FileMode.CreateNew);
                fs1.Close();
                fs1.Dispose();
            }
            lblStatus.Content = "Trading LIVE!!";
            File.Delete(@"C:\EFund\Control\HaltTrading\HaltTrading.ALL");
            SoundPlayer player = new SoundPlayer(@"C:\Users\Trader\SkyDrive\ECCLESIASTESFUND\Sounds\TradingLive.wav");
            player.Play();
            player.Dispose();
        }

        private void btnHaltTrading_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(@"C:\EFund\Control\HaltTrading\HaltTrading.ALL"))
            {
                FileStream fs = new FileStream(@"C:\EFund\Control\HaltTrading\HaltTrading.ALL", FileMode.CreateNew);
                fs.Close();
                fs.Dispose();
            }
            lblStatus.Content = "Trading HALTED!!";
            File.Delete(@"C:\EFund\Control\HaltTrading\TradingLIVE.ALL");
            SoundPlayer player = new SoundPlayer(@"C:\Users\Trader\SkyDrive\ECCLESIASTESFUND\Sounds\TradingHalted.wav");
            player.Play();
            player.Dispose();
        }

        private void btnFlattenAll_Click(object sender, RoutedEventArgs e)
        {   //http://www.ninjatrader.com/support/helpGuides/nt7/index.html?dll_interface.htm
            string cmd = "FLATTENEVERYTHING;;;;;;;;;;;;";  //http://www.ninjatrader.com/support/helpGuides/nt7/index.html?dll_interface.htm
            StreamWriter fs2 = new StreamWriter (@"C:\Users\Trader\Documents\NinjaTrader 7\incoming\oif.txt",true);
            fs2.WriteLine(cmd);
            fs2.Close();
            fs2.Dispose();

        }
        private void btnReverseAll_Click(object sender, RoutedEventArgs e)
        {
            if (rev == true)
            {
                rev = false;
                btnReverseAll.Content = "Click to Turn Reverse ON";
                lblReverseStatus.Content = "Status: Reverse is OFF!";
                lblReverseStatus.Foreground = new SolidColorBrush(Colors.Red);
                File.Delete(@"C:\EFund\Control\Reverse\ReverseON.ALL");
                StreamWriter fs3b = new StreamWriter(@"C:\EFund\Control\Reverse\ReverseOFF.ALL", true);
                fs3b.Close();
                fs3b.Dispose();
            }
            else
            {
                rev = true;
                btnReverseAll.Content = "Click to Turn Reverse OFF";
                lblReverseStatus.Content = "Status: Reverse is ON!";
                lblReverseStatus.Foreground = new SolidColorBrush(Colors.LimeGreen);
                File.Delete(@"C:\EFund\Control\Reverse\ReverseOFF.ALL");
                StreamWriter fs3 = new StreamWriter(@"C:\EFund\Control\Reverse\ReverseON.ALL", true);
                fs3.Close();
                fs3.Dispose();
            }

            SoundPlayer player = new SoundPlayer(@"C:\Users\Trader\SkyDrive\ECCLESIASTESFUND\Sounds\ReverseChange.wav");
            player.Play();
            player.Dispose(); 

        }
        private void textFileName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
