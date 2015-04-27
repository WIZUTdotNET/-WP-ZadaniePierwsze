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
            var clickedButtonContent = ((Button) sender).Content.ToString();
            DigitalDisplay.Text = clickedButtonContent;

            if (clickedButtonContent == "*") clickedButtonContent = "star";
            else if (clickedButtonContent == "#") clickedButtonContent = "hash";

            var fileToPlay = "/Assets/Sounds/keyNumber_" + clickedButtonContent + ".mp3";

            PressedButtonPlayer.Source = new Uri(fileToPlay, UriKind.Relative);
            PressedButtonPlayer.Play();
        }
    }
}
