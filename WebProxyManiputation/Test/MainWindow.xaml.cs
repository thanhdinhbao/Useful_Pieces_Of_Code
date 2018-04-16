﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Helpers;
using static System.String;

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

        private const string UrlDefault = "https://www.google.com/";
        private const string FooMessage = "Please input Ip or/and Port";
       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TestClick(object sender, RoutedEventArgs e)
        {
            if (Port.Text == Empty || IpAddress.Text == Empty)
            {
                Content.Text = FooMessage;
                return;
            }
            Awesome.Visibility = Visibility.Visible;
            if (Url.Text == Empty) Url.Text = UrlDefault;
            var response = await Helper.SendGetRequest(Url.Text, IpAddress.Text, Port.Text);
            Content.Text = response;
            Awesome.Visibility = Visibility.Hidden;
            Time.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear(object sender, RoutedEventArgs e)
        {
            Awesome.Visibility = Visibility.Visible;
            Content.Text = Empty;
            Time.Text = Empty;
            Awesome.Visibility = Visibility.Hidden;
        }

        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Url_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) TestClick(null, null);
        }
    }
}
