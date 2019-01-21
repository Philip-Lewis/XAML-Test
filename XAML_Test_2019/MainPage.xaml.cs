using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XAML_Test_2019
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnSampleMessage_Click(object sender, RoutedEventArgs e)
        {
            String strParameter = String.Empty;
            strParameter += "Message:" + txtMessage.Text + ",";
            strParameter += "NightMode:" + (togNightMode.IsOn ? "Night" : "Day") + ",";
            strParameter += "Size:" + slrSizePicker.Value.ToString();
            this.Frame.Navigate(typeof(SampleMessage), strParameter);
        }
    }
}
