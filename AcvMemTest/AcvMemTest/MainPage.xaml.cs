//using Microsoft.Toolkit.Uwp.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AcvMemTest
{
    class SomeObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _val;
        public int val
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
                onPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                onPropertyChanged();
            }
        }

        public SomeObject(int val, DateTime date)
        {
            this.val = val;
            this.date = date;
        }

        private void onPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<SomeObject> COL;
        //private readonly AdvancedCollectionView ACV;
        private readonly Random RAND = new Random();
        private ThreadPoolTimer timer;

        public MainPage()
        {
            this.COL = new ObservableCollection<SomeObject>();
            /*this.ACV = new AdvancedCollectionView(COL, true);
            this.ACV.SortDescriptions.Add(new SortDescription(nameof(SomeObject.date), SortDirection.Descending));*/
            this.InitializeComponent();
        }
        
        DateTime randomDate()
        {
            int range = (DateTime.MaxValue - DateTime.MinValue).Days;
            return DateTime.MinValue.AddDays(RAND.Next(range));
        }

        private async void add_btn_Click(object sender, RoutedEventArgs args)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();
            await dialog.ShowAsync();

            /*Task.Run(async () =>
            {
                List<SomeObject> l = new List<SomeObject>();
                for (int e = 0; e < 10; e++)
                {
                    l.Add(new SomeObject(e, randomDate()));
                }
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    foreach (var item in l)
                    {
                        COL.Add(item);
                    }
                });
            });*/
        }

        private void update_btn_Click(object sender, RoutedEventArgs args)
        {
            if(timer == null)
            {
                timer = ThreadPoolTimer.CreateTimer(onTimeout, TimeSpan.FromSeconds(5));
            }
            else
            {
                timer.Cancel();
                timer = null;
            }
        }

        private void onTimeout(ThreadPoolTimer timer)
        {
            int i = 5;
        }
    }
}
