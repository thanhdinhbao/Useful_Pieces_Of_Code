﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Data.Utils;
using Helpers;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private const string UrlDefoult = "https://m.sportsbet.com.au/sportsbook/navhierarchy";
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Awesome.Visibility = Visibility.Visible;
            if (Url.Text == string.Empty) Url.Text = UrlDefoult;
            var response = await Helper.SendGetRequest(Url.Text, IpAddress.Text, Port.Text);
            Content.Text = response;
            Awesome.Visibility = Visibility.Hidden;
            Time.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Awesome.Visibility = Visibility.Visible;
            Content.Text = string.Empty;
            Time.Text = string.Empty;
            Awesome.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HidemeParser hidemeParser=new HidemeParser();
            hidemeParser.GetProxy();
        }
    }
}

