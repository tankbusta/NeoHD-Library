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
using Yamaha.NeoHD;

namespace NeoHDControllerGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NeoHD hd = new NeoHD("192.168.1.107", 33);
        public MainWindow()
        {
            InitializeComponent();

            /* Populate the Device IP box */
            tbDeviceIP.Text = hd.neohd_reciever_ip;
            tbMaxVol.Text = Convert.ToString(hd.volume_limit);
            slVolume.Maximum = hd.volume_limit;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbDeviceIP_LostFocus(object sender, RoutedEventArgs e)
        {
            hd.neohd_reciever_ip = tbDeviceIP.Text;
        }

        private void tbMaxVol_LostFocus(object sender, RoutedEventArgs e)
        {
            hd.volume_limit = Convert.ToInt32(tbMaxVol.Text);
            slVolume.Maximum = Convert.ToInt32(tbMaxVol.Text);
        }

        private void slVolume_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            hd.SetVolume(Convert.ToInt32(slVolume.Value));
        }
    }
}
