using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using UnitsConverter.Resources;
using WPET;

namespace UnitsConverter
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool convertValue1;
        // Constructor

        Settings<string> conversionType = new Settings<string>("ConverstionType", "temperature");

        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void SetupLabels()
        {
            if (conversionType.Value == "temperature")
            {
                this.Title = "temperature";
                textBlock1.Text = "Fahrenheit";
                textBlock2.Text = "Celsius";
                fahrInput.Text = "";
                celInput.Text = "";
            }
            else
            {
                this.Title = "spoons";
                textBlock1.Text = "Teaspoons";
                textBlock2.Text = "Tablespoons";
                fahrInput.Text = "";
                celInput.Text = "";
            }
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            convertValue1 = true;
            SetupLabels();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            switch (conversionType.Value)
            {
                case "temperature":
                    {
                        if(convertValue1)
                        {
                            celInput.Text = "";
                            try
                            {
                                double fahrenheightValue = double.Parse(fahrInput.Text);
                                double celsiusValue = (fahrenheightValue - 32) * (5.0 / 9.0);
                                celInput.Text = celsiusValue.ToString("F");
                            }
                            catch (Exception)
                            {
                                celInput.Text = "Error";
                            }
                        }
                        else
                        {
                            fahrInput.Text = "";
                            try
                            {
                                double celsiusValue = double.Parse(celInput.Text);
                                double fahrenheightValue = (celsiusValue * (9.0 / 5.0)) + 32;
                                fahrInput.Text = fahrenheightValue.ToString("F");
                            }
                            catch (Exception)
                            {
                                celInput.Text = "Error";
                            }

                        }
                        break;
                    }
                case "spoons":
                    {
                        if (convertValue1)
                        {
                            celInput.Text = "";
                            try
                            {
                                double teaspoons = double.Parse(fahrInput.Text);
                                double tablespoons = teaspoons / 3;
                                celInput.Text = tablespoons.ToString("F");
                            }
                            catch (Exception)
                            {
                                celInput.Text = "Error";
                            }
                        }
                        else
                        {
                            fahrInput.Text = "";
                            try
                            {
                                double tablespoons = double.Parse(celInput.Text);
                                double teaspoons = tablespoons * 3;
                                fahrInput.Text = teaspoons.ToString("F");
                            }
                            catch (Exception)
                            {
                                celInput.Text = "Error";
                            }

                        }
                    }
                    break;
              }


            this.Focus();
        }

        private void fahr_gotFocus(object sender, RoutedEventArgs e)
        {
            convertValue1 = true;
            fahrInput.Text = "";
            celInput.Text = "";
        }

        private void cel_gotFocus(object sender, RoutedEventArgs e)
        {
            convertValue1 = false;
            fahrInput.Text = "";
            celInput.Text = "";
        }

        private void ChooseTemperatureConversion_Click(object sender, EventArgs e)
        {
            conversionType.Value = "temperature";
            SetupLabels();
        }

        private void ChooseSpoonConversion_Click(object sender, EventArgs e)
        {
            conversionType.Value = "spoons";
            SetupLabels();
        }

    }
}