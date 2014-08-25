using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Sonnets.Resources;
using System.Xml.Linq;

namespace Sonnets.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            //load xml data from file
            XDocument xdoc = XDocument.Load("Contents/sonnets.xml");

            //select each 'Sonnet' block and build an ivm for each
            var dataEnum = xdoc.Descendants("Sonnet");

            foreach (XElement e in dataEnum)
            {
                //create an empty ItemViewModel
                ItemViewModel ivm = new ItemViewModel();

                //The main item shown in the ListBox is the number of
                // the sonnet
                ivm.LineOne = (string)e.Element("Number").Value;
                ivm.ID = (string)e.Element("Number").Attribute("id");
                //ivm.LineOne = (string)e.Element("Number").
                //ivm.ID = (string)e.Element("Number").Element("id");

                //enabling the processing of each <Line>
                int lineNum = 1;
                string sonnetBody = "";

                var bodyEnum = e.Element("Body").Descendants("Line");

                foreach (XElement line in bodyEnum)
                {
                    if (lineNum == 1)
                        ivm.LineTwo = (string)line.Value;

                    if (lineNum < 13)
                        sonnetBody = sonnetBody + "\r\n" + line.Value;
                    else
                        sonnetBody = sonnetBody + "\r\n   " + line.Value;
                    lineNum++;
                }
                ivm.LineThree = sonnetBody;

                this.Items.Add(ivm);
            }

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}