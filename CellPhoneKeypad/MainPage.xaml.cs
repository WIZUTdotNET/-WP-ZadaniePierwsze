using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CellPhoneKeypad.Resources;

namespace CellPhoneKeypad
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            var clickedButtonTag = ((Button) sender).Tag.ToString();
            DigitalDisplay.Text = clickedButtonTag;

            if (clickedButtonTag == "*") clickedButtonTag = "star";
            else if (clickedButtonTag == "#") clickedButtonTag = "hash";

            var fileToPlay = "/Assets/Sounds/keyNumber_" + clickedButtonTag + ".mp3";

            PressedButtonPlayer.Source = new Uri(fileToPlay, UriKind.Relative);
            PressedButtonPlayer.Play();
        }
    }
}
