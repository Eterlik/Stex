using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuntoTexteditorExtensionWPF.Pages
{
    /// <summary>
    /// Interaction logic for SupportDevWindow.xaml
    /// </summary>
    public partial class SupportDevWindow : Window
    {
        public SupportDevWindow()
        {
            Owner = App.Current.MainWindow;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void coffeeButton_clik(object sender, RoutedEventArgs e)
        {
            string url = "https://www.paypal.com/paypalme/EmanuelHeitmann";
            OpenUrl(url);
            
        }

        private void spotifyButton_click(object sender, MouseButtonEventArgs e)
        {
            string url = "https://open.spotify.com/intl-de/artist/0Vis9RFuHgTzy7auLje3QP";
            OpenUrl(url);
        }

        private void youtubeButton_click(object sender, MouseButtonEventArgs e)
        {
            string url = "https://www.youtube.com/@LunasDreams-g6z";
            OpenUrl(url);
        }

        private void youtubeMusicButton_click(object sender, MouseButtonEventArgs e)
        {
            string url = "https://music.youtube.com/channel/UCGam1ElkLxTunZbsfLBm52Q";
            OpenUrl(url);
        }

        private void appleMusicButton_click(object sender, MouseButtonEventArgs e)
        {
            string url = "https://music.apple.com/de/artist/lunas-dreams/1759352979";
            OpenUrl(url);
        }

        private void amazonMusicButton_click(object sender, MouseButtonEventArgs e)
        {
            string url = "https://music.amazon.de/artists/B0DB66RD6K/lunas-dreams";
            OpenUrl(url);
        }

        private void OpenUrl(string _url)
        {
            var sInfo = new System.Diagnostics.ProcessStartInfo(_url)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }
    }
}
