using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CellPhoneKeypad.Resources;
using Microsoft.Xna.Framework.Media;

namespace CellPhoneKeypad
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void KeypadButtonManipulationStarted(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;

            if (currentButton == null) return;

            String buttonContentValue = currentButton.Content as String;

            if (buttonContentValue == null) return;

            PlayTargetKeypadSound(buttonContentValue);
            RefreshNumber(buttonContentValue);
        }

        private void PlayTargetKeypadSound(string buttonContentValue)
        {
            if (buttonContentValue == "*")
                buttonContentValue = "star";
            if (buttonContentValue == "#")
                buttonContentValue = "hash";

            String path = "/Assets/Sounds/keyNumber_" + buttonContentValue + ".mp3";
            KeySoundMediaElement.MediaOpened += KeySoundMediaElementOnMediaOpened;
            KeySoundMediaElement.Source = new Uri(path, UriKind.RelativeOrAbsolute);
        }

        private void KeySoundMediaElementOnMediaOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            MediaElement sound = sender as MediaElement;
            if (sound != null) sound.Play();
        }

        private void RefreshNumber(string buttonContentValue)
        {
            NumberTextBlock.Text = buttonContentValue;
        }
    }
}