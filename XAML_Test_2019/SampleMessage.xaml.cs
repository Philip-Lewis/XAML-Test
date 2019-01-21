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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace XAML_Test_2019
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SampleMessage : Page
    {
        private Dictionary<String, String> dicMessageParameters;

        public SampleMessage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dicMessageParameters = new Dictionary<string, string>();

            if(e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                String strParameter = (string)e.Parameter;

                String[] objVariables = strParameter.Split(',');
                foreach(String strParam in objVariables)
                {
                    String[] objParam = strParam.Split(':');
                    dicMessageParameters.Add(objParam.ElementAt(0), objParam.ElementAt(1));
                }
            }
            else
            {
                lblMessage.Text = "Error!";
            }

            LoadMessage();

            base.OnNavigatedTo(e);
        }

        private void LoadMessage()
        {
            Boolean blnNight = false;
            double dblFontSize = 0;

            foreach(var Parameter in dicMessageParameters)
            {
                switch(Parameter.Key)
                {
                    case "Message":
                        lblMessage.Text = Parameter.Value;
                        break;
                    case "NightMode":
                        if(Parameter.Value == "Night")
                        {
                            blnNight = true;
                        }
                        else
                        {
                            blnNight = false;
                        }
                        break;
                    case "Size":
                        dblFontSize = Double.Parse(Parameter.Value);
                        lblMessage.FontSize = dblFontSize;
                        break;
                }
            }

            SolidColorBrush objForeBrush;
            SolidColorBrush objBackBrush;
            if (!blnNight)
            {
                objForeBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                objBackBrush = new SolidColorBrush(Windows.UI.Colors.White);
            }
            else
            {
                objForeBrush = new SolidColorBrush(Windows.UI.Colors.White);
                objBackBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                
            }

            lblMessage.Foreground = objForeBrush;
            btnBack.Background = objForeBrush;
            grdBackground.Background = objBackBrush;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
