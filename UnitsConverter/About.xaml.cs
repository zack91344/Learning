using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace UnitsConverter
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
            this.textBlock1.Text = "Version 1.0\r\n\r\nBuilt by DreamTimeStudioZ, LLC for Lynda.com";
        }

        private void Suggestion_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Tasks.EmailComposeTask emailTask = new Microsoft.Phone.Tasks.EmailComposeTask();
            emailTask.Subject = "Suggestion for UNITS CONVERTER V1.0";
            emailTask.To = "support@email.com";
            emailTask.Show();
        }

        private void Company_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri("http://jimmypage.com", UriKind.Absolute);
            task.Show();
        }


    }
}